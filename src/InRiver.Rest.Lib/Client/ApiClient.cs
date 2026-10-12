using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InRiver.Rest.Lib.Services;

namespace InRiver.Rest.Lib.Client
{
    /// <summary>Shared HTTP transport. Caller-supplied clients remain caller-owned.</summary>
    internal sealed class ApiClient : IDisposable
    {
        private readonly Configuration _configuration;
        private readonly Serializer _serializer;
        private readonly HttpClient _httpClient;
        private readonly bool _ownsHttpClient;
        private bool _disposed;

        public ApiClient(Configuration configuration, Serializer serializer)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _ownsHttpClient = configuration.HttpClientOverride == null;
            _httpClient = configuration.HttpClientOverride ?? new HttpClient { Timeout = System.Threading.Timeout.InfiniteTimeSpan };
        }

        public ApiResponse<T> CallApi<T>(string path, HttpMethod method,
            List<KeyValuePair<string, string>> queryParams, object postBody)
        {
            return CallApiAsync<T>(path, method, queryParams, postBody).GetAwaiter().GetResult();
        }

        public async Task<ApiResponse<T>> CallApiAsync<T>(string path, HttpMethod method,
            List<KeyValuePair<string, string>> queryParams, object postBody,
            CancellationToken cancellationToken = default)
        {
            if(_disposed) throw new ObjectDisposedException(nameof(ApiClient));
            cancellationToken.ThrowIfCancellationRequested();
            var url = _configuration.BasePath.TrimEnd('/') + "/" + path.TrimStart('/');
            if(queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams.Select(p =>
                    Uri.EscapeDataString(p.Key) + "=" + Uri.EscapeDataString(p.Value)));

            using(var request = new HttpRequestMessage(method, url))
            using(var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                timeout.CancelAfter(_configuration.Timeout);
                foreach(var header in _configuration.DefaultHeader)
                    request.Headers.Add(header.Key, header.Value);
                if(!request.Headers.Contains("Accept"))
                    request.Headers.Accept.ParseAdd("application/json");
                if(!string.IsNullOrEmpty(_configuration.UserAgent) && !request.Headers.Contains("User-Agent"))
                    request.Headers.UserAgent.ParseAdd(_configuration.UserAgent);
                if(postBody != null)
                    request.Content = new StringContent(_serializer.Serialize(postBody), Encoding.UTF8, "application/json");

                try
                {
                    // ResponseContentRead keeps both receiving headers and buffering the body cancellable on netstandard2.0.
                    using(var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, timeout.Token).ConfigureAwait(false))
                    {
                        var content = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        timeout.Token.ThrowIfCancellationRequested();
                        var status = (int)response.StatusCode;
                        if(status >= 400)
                            throw new ApiException(status, $"Error calling {path}: {content}", content);

                        var headers = response.Headers.ToDictionary(h => h.Key, h => string.Join(",", h.Value), StringComparer.OrdinalIgnoreCase);
                        if(response.Content != null)
                            foreach(var header in response.Content.Headers)
                                headers[header.Key] = string.Join(",", header.Value);

                        var data = string.IsNullOrWhiteSpace(content) ? default(T) :
                            (T)_serializer.Deserialize(content, typeof(T), response.Content?.Headers.ContentType?.MediaType);
                        return new ApiResponse<T>(status, headers, data);
                    }
                }
                catch(HttpRequestException error)
                {
                    throw new ApiException(0, $"Error calling {path}: {error.Message}", error.Message);
                }
            }
        }

        public void Dispose()
        {
            if(_disposed) return;
            _disposed = true;
            if(_ownsHttpClient)
                _httpClient.Dispose();
        }
    }
}
