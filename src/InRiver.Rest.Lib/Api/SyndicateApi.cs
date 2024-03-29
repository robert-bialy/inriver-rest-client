using System;
using System.Collections.Generic;
using System.Linq;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Helpers;
using InRiver.Rest.Lib.Model;
using InRiver.Rest.Lib.Services;
using RestSharp;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal sealed class SyndicateApi : ISyndicateApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyndicateApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SyndicateApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            // use the default one in Configuration
            Configuration = configuration ?? Configuration.Default;
        }
        
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Run Syndicate 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>object</returns>
        public object RunSyndicate(int? syndicationId)
        {
             var localVarResponse = RunSyndicateWithHttpInfo(syndicationId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Run Syndicate 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>ApiResponse of object</returns>
        public ApiResponse<object> RunSyndicateWithHttpInfo(int? syndicationId)
        {
            // verify the required parameter 'syndicationId' is set
            if(syndicationId == null)
                throw new ApiException(400, "Missing required parameter 'syndicationId' when calling SyndicateApi->SyndicateRunSyndicate");

            var localVarPath = "/api/v1.0.0/syndications/{syndicationId}:run";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =  {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("syndicationId", HttpHelpers.ParameterToString(syndicationId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (object) _serializer.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        /// Run Syndicate 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>Task of object</returns>
        public async System.Threading.Tasks.Task<object> RunSyndicateAsync(int? syndicationId)
        {
             var localVarResponse = await RunSyndicateAsyncWithHttpInfo(syndicationId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Run Syndicate 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>Task of ApiResponse(object)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> RunSyndicateAsyncWithHttpInfo(int? syndicationId)
        {
            // verify the required parameter 'syndicationId' is set
            if(syndicationId == null)
                throw new ApiException(400, "Missing required parameter 'syndicationId' when calling SyndicateApi->SyndicateRunSyndicate");

            var localVarPath = "/api/v1.0.0/syndications/{syndicationId}:run";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =  {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("syndicationId", HttpHelpers.ParameterToString(syndicationId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (object) _serializer.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        /// Get All Syndications 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;SyndicationModel&gt;</returns>
        public List<SyndicationModel> Syndications()
        {
             var localVarResponse = SyndicationsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get All Syndications 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;SyndicationModel&gt;</returns>
        public ApiResponse<List<SyndicationModel>> SyndicationsWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/syndications";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =  {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<List<SyndicationModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SyndicationModel>) _serializer.Deserialize(localVarResponse, typeof(List<SyndicationModel>)));
        }

        /// <summary>
        /// Get All Syndications 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;SyndicationModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SyndicationModel>> SyndicationsAsync()
        {
             var localVarResponse = await SyndicationsAsyncWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get All Syndications 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;SyndicationModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SyndicationModel>>> SyndicationsAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/syndications";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =  {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<List<SyndicationModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SyndicationModel>) _serializer.Deserialize(localVarResponse, typeof(List<SyndicationModel>)));
        }
    }
}
