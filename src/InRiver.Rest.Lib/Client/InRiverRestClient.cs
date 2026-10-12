using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using InRiver.Rest.Lib.Services;

namespace InRiver.Rest.Lib.Client
{
    /// <summary>Entry point for the inriver REST API. Dispose to release an internally created HttpClient.</summary>
    public sealed partial class InRiverRestClient : IinRiverClient, IDisposable
    {
        private readonly Configuration _configuration;
        private readonly object _lock = new object();
        private ApiClient _apiClient;
        private bool _disposed;

        public InRiverRestClient(string apiKey, string basePath = "https://apieuw.productmarketingcloud.com")
            : this(apiKey, basePath, (Action<Configuration>)null) { }

        public InRiverRestClient(Action<Configuration> configuration)
        {
            if(configuration == null) throw new ArgumentNullException(nameof(configuration));
            _configuration = new Configuration();
            configuration(_configuration);
            ValidateConfiguration();
        }

        public InRiverRestClient(string apiKey, string basePath, Action<Configuration> configuration = null)
        {
            if(string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidDataException("Api key is required and cannot be null or empty");
            _configuration = new Configuration
            {
                BasePath = basePath,
                DefaultHeader = new Dictionary<string, string> { { Configuration.InRiverAPIKeyHeader, apiKey } }
            };
            configuration?.Invoke(_configuration);
            ValidateConfiguration();
        }

        public InRiverRestClient(string apiKey, string basePath, HttpClient httpClient = null, Action<Configuration> configuration = null)
            : this(apiKey, basePath, conf =>
            {
                conf.HttpClientOverride = httpClient;
                configuration?.Invoke(conf);
            }) { }

        private void ValidateConfiguration()
        {
            if(!Uri.TryCreate(_configuration.BasePath, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp))
                throw new InvalidDataException("Base path must be an absolute HTTP or HTTPS URL");
            if(_configuration.DefaultHeader == null ||
                !_configuration.DefaultHeader.TryGetValue(Configuration.InRiverAPIKeyHeader, out var apiKey) ||
                string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidDataException("Api key is required in the X-inRiver-APIKey header");
            if(_configuration.Timeout < -1)
                throw new ArgumentOutOfRangeException(nameof(Configuration.Timeout));
        }

        private ApiClient ApiClient
        {
            get
            {
                lock(_lock)
                {
                    if(_disposed) throw new ObjectDisposedException(nameof(InRiverRestClient));
                    return _apiClient ?? (_apiClient = new ApiClient(_configuration, new Serializer()));
                }
            }
        }

        public void Dispose()
        {
            lock(_lock)
            {
                if(_disposed) return;
                _disposed = true;
                _apiClient?.Dispose();
            }
        }
    }
}
