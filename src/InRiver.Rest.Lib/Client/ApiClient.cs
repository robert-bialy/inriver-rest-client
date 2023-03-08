using System;
using System.Collections.Generic;
using RestSharp;

namespace InRiver.Rest.Lib.Client
{
    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    internal sealed class ApiClient : IApiClient
    {
        private readonly IRestClientFactory _restClientFactory;
        private readonly Configuration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="restClientFactory"></param>
        public ApiClient(Configuration configuration, IRestClientFactory restClientFactory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _restClientFactory = restClientFactory ?? throw new ArgumentNullException(nameof(restClientFactory));
        }

        // Creates and sets up a RestRequest prior to a call.
        public RestRequest PrepareRequest(
            string path,
            Method method,
            List<KeyValuePair<string, string>> queryParams,
            object postBody,
            IEnumerable<KeyValuePair<string, string>> headerParams,
            Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams,
            Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = new RestRequest(path, method);

            // add path parameter, if any
            foreach(var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            foreach(var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach(var param in queryParams)
                request.AddQueryParameter(param.Key, param.Value);

            // add form parameter, if any
            foreach(var param in formParams)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach(var param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.GetFile, param.Value.FileName, param.Value.ContentType);
            }

            if(postBody != null) // http body(model or byte[]) parameter
            {
                request.AddBody(postBody, contentType);
            }

            return request;
        }

        /// <summary>
        /// Makes the HTTP request(Sync).
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body(POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content Type of the request</param>
        /// <returns>object</returns>
        public object CallApi(
            string path,
            Method method,
            List<KeyValuePair<string, string>> queryParams,
            object postBody,
            Dictionary<string, string> headerParams,
            Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams,
            Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);

            // set timeout
            var configuration = new RestClientOptions
            {
                Timeout = _configuration.Timeout,
                BaseUrl = new Uri(_configuration.BasePath)
            };
            var restClient = _restClientFactory.Create(configuration);
            var response = restClient.ExecuteAsync(request).Result;
            HandleResponseError(path, response);

            return response;
        }

        /// <summary>
        /// Makes the asynchronous HTTP request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body(POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async System.Threading.Tasks.Task<object> CallApiAsync(
            string path,
            Method method,
            List<KeyValuePair<string, string>> queryParams,
            object postBody,
            Dictionary<string, string> headerParams,
            Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams,
            Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = PrepareRequest(
                path,
                method,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                pathParams,
                contentType);
            var configuration = new RestClientOptions
            {
                Timeout = _configuration.Timeout,
                BaseUrl = new Uri(_configuration.BasePath)
            };
            var restClient = _restClientFactory.Create(configuration);
            var response = await restClient.ExecuteAsync(request);
            HandleResponseError(path, response);

            return response;
        }

        private static void HandleResponseError(string path, RestResponseBase response)
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                throw new ApiException(status,
                    $"Error calling {path}: {response.Content}",
                    response.Content);
            }
            if (status == 0)
            {
                throw new ApiException(status,
                    $"Error calling {path}: {response.ErrorMessage}", response.ErrorMessage);
            }
        }
    }
}
