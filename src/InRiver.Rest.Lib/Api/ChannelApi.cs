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
    internal sealed class ChannelApi : IChannelApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ChannelApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            Configuration = configuration ?? Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }
        
        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ChannelPathContentModel</returns>
        public ChannelPathContentModel ChannelContent(string path, string entityTypeIds = null)
        {
             var localVarResponse = ChannelContentWithHttpInfo(path, entityTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of ChannelPathContentModel</returns>
        public ApiResponse<ChannelPathContentModel> ChannelContentWithHttpInfo(string path, string entityTypeIds = null)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling ChannelApi->ChannelChannelContent");

            var localVarPath = "/api/v1.0.0/channels/content/{path}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("path", HttpHelpers.ParameterToString(path,Configuration)); // path parameter
            if (entityTypeIds != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelChannelContent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<ChannelPathContentModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ChannelPathContentModel) _serializer.Deserialize(localVarResponse, typeof(ChannelPathContentModel)));
        }

        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ChannelPathContentModel</returns>
        public async System.Threading.Tasks.Task<ChannelPathContentModel> ChannelContentAsync (string path, string entityTypeIds = null)
        {
             ApiResponse<ChannelPathContentModel> localVarResponse = await ChannelContentAsyncWithHttpInfo(path, entityTypeIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (ChannelPathContentModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ChannelPathContentModel>> ChannelContentAsyncWithHttpInfo (string path, string entityTypeIds = null)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling ChannelApi->ChannelChannelContent");

            var localVarPath = "/api/v1.0.0/channels/content/{path}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (path != null) localVarPathParams.Add("path", HttpHelpers.ParameterToString(path,Configuration)); // path parameter
            if (entityTypeIds != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds,Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelChannelContent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<ChannelPathContentModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ChannelPathContentModel) _serializer.Deserialize(localVarResponse, typeof(ChannelPathContentModel)));
        }

        /// <summary>
        /// Get entity types for channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> ChannelEntityTypes (int? channelId)
        {
             ApiResponse<List<string>> localVarResponse = EntityTypesWithHttpInfo(channelId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get entity types for channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public ApiResponse<List<string>> EntityTypesWithHttpInfo(int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelEntityTypes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitytypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelEntityTypes", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get entity types for channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> EntityTypesAsync (int? channelId)
        {
             var localVarResponse = await EntityTypesAsyncWithHttpInfo(channelId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get entity types for channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> EntityTypesAsyncWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelEntityTypes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitytypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelEntityTypes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get entity links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>EntityListModel</returns>
        public EntityListModel GetByEntityType(int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
        {
             ApiResponse<EntityListModel> localVarResponse = GetByEntityTypeWithHttpInfo(channelId, entityId, linkDirection, linkTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get entity links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse< EntityListModel > GetByEntityTypeWithHttpInfo(int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetByEntityType");
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling ChannelApi->ChannelGetByEntityType");
            // verify the required parameter 'linkDirection' is set
            if (linkDirection == null)
                throw new ApiException(400, "Missing required parameter 'linkDirection' when calling ChannelApi->ChannelGetByEntityType");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entities/{entityId}/links";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            localVarPathParams.Add("entityId", HttpHelpers.ParameterToString(entityId, Configuration)); // path parameter
            localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "linkDirection", linkDirection, Configuration)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetByEntityType", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Get entity links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> GetByEntityTypeAsync(int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
        {
             var localVarResponse = await GetByEntityTypeAsyncWithHttpInfo(channelId, entityId, linkDirection, linkTypeId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get entity links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> GetByEntityTypeAsyncWithHttpInfo(int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetByEntityType");
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling ChannelApi->ChannelGetByEntityType");
            // verify the required parameter 'linkDirection' is set
            if (linkDirection == null)
                throw new ApiException(400, "Missing required parameter 'linkDirection' when calling ChannelApi->ChannelGetByEntityType");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entities/{entityId}/links";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            localVarPathParams.Add("entityId", HttpHelpers.ParameterToString(entityId, Configuration)); // path parameter
            localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "linkDirection", linkDirection, Configuration)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetByEntityType", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>EntityListModel</returns>
        public EntityListModel GetByLinkEntityType (int? channelId, string entityTypeId = null)
        {
             var localVarResponse = GetByLinkEntityTypeWithHttpInfo(channelId, entityTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse<EntityListModel> GetByLinkEntityTypeWithHttpInfo(int? channelId, string entityTypeId = null)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetByLinkEntityType");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitylist";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            if (entityTypeId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetByLinkEntityType", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> GetByLinkEntityTypeAsync(int? channelId, string entityTypeId = null)
        {
             var localVarResponse = await GetByLinkEntityTypeAsyncWithHttpInfo(channelId, entityTypeId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> GetByLinkEntityTypeAsyncWithHttpInfo (int? channelId, string entityTypeId = null)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetByLinkEntityType");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitylist";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            if (entityTypeId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId, Configuration)); // query parameter


            // make the HTTP request
            var localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetByLinkEntityType", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Dictionary&lt;string, StructureNode&gt;</returns>
        public Dictionary<string, StructureNode> GetChannelNodeTree (int? channelId)
        {
             var localVarResponse = GetChannelNodeTreeWithHttpInfo(channelId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, StructureNode&gt;</returns>
        public ApiResponse<Dictionary<string, StructureNode>> GetChannelNodeTreeWithHttpInfo(int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodeTree");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodetree";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetChannelNodeTree", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) _serializer.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of Dictionary&lt;string, StructureNode&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, StructureNode>> GetChannelNodeTreeAsync(int? channelId)
        {
             var localVarResponse = await GetChannelNodeTreeAsyncWithHttpInfo(channelId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, StructureNode&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, StructureNode>>> GetChannelNodeTreeAsyncWithHttpInfo(int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodeTree");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodetree";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            Exception exception = ExceptionFactory?.Invoke("ChannelGetChannelNodeTree", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) _serializer.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetChannelNodes (int? channelId)
        {
             var localVarResponse = GetChannelNodesWithHttpInfo(channelId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public ApiResponse<List<string>> GetChannelNodesWithHttpInfo(int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelNodes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(
                localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetChannelNodesAsync(int? channelId)
        {
             var localVarResponse = await GetChannelNodesAsyncWithHttpInfo(channelId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> GetChannelNodesAsyncWithHttpInfo(int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetChannelNodes", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>List&lt;StructureEntityModel&gt;</returns>
        public List<StructureEntityModel> GetChannelStructureEntities(int? channelId, int? entityId)
        {
             var localVarResponse = GetChannelStructureEntitiesWithHttpInfo(channelId, entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;StructureEntityModel&gt;</returns>
        public ApiResponse<List<StructureEntityModel>> GetChannelStructureEntitiesWithHttpInfo(int? channelId, int? entityId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelStructureEntities");
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling ChannelApi->ChannelGetChannelStructureEntities");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entities/{entityId}/structureentities";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", HttpHelpers.ParameterToString(entityId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetChannelStructureEntities", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<StructureEntityModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<StructureEntityModel>) _serializer.Deserialize(localVarResponse, typeof(List<StructureEntityModel>)));
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;StructureEntityModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<StructureEntityModel>> GetChannelStructureEntitiesAsync(int? channelId, int? entityId)
        {
             var localVarResponse = await GetChannelStructureEntitiesAsyncWithHttpInfo(channelId, entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;StructureEntityModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<StructureEntityModel>>> GetChannelStructureEntitiesAsyncWithHttpInfo(int? channelId, int? entityId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelStructureEntities");
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling ChannelApi->ChannelGetChannelStructureEntities");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entities/{entityId}/structureentities";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", HttpHelpers.ParameterToString(channelId, Configuration)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", HttpHelpers.ParameterToString(entityId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("ChannelGetChannelStructureEntities", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<StructureEntityModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<StructureEntityModel>) _serializer.Deserialize(localVarResponse, typeof(List<StructureEntityModel>)));
        }

        /// <summary>
        /// Get channel id&#39;s for entity id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>List&lt;ChannelSummaryModel&gt;</returns>
        public List<ChannelSummaryModel> GetChannelsForEntityId(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {
             ApiResponse<List<ChannelSummaryModel>> localVarResponse = GetChannelsForEntityIdWithHttpInfo(forEntityId, includeChannels, includePublications);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get channel id&#39;s for entity id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>ApiResponse of List&lt;ChannelSummaryModel&gt;</returns>
        public ApiResponse<List<ChannelSummaryModel>> GetChannelsForEntityIdWithHttpInfo(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {

            var localVarPath = "/api/v1.0.0/channels";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (forEntityId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forEntityId", forEntityId, Configuration)); // query parameter
            if (includeChannels != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeChannels", includeChannels, Configuration)); // query parameter
            if (includePublications != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includePublications", includePublications, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelsForEntityId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<ChannelSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<ChannelSummaryModel>) _serializer.Deserialize(localVarResponse, typeof(List<ChannelSummaryModel>)));
        }

        /// <summary>
        /// Get channel id&#39;s for entity id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>Task of List&lt;ChannelSummaryModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<ChannelSummaryModel>> GetChannelsForEntityIdAsync (int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {
             var localVarResponse = await GetChannelsForEntityIdAsyncWithHttpInfo(forEntityId, includeChannels, includePublications);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get channel id&#39;s for entity id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;ChannelSummaryModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<ChannelSummaryModel>>> GetChannelsForEntityIdAsyncWithHttpInfo(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {

            var localVarPath = "/api/v1.0.0/channels";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = HttpHelpers.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (forEntityId != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forEntityId", forEntityId, Configuration)); // query parameter
            if (includeChannels != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeChannels", includeChannels, Configuration)); // query parameter
            if (includePublications != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includePublications", includePublications, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelsForEntityId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<ChannelSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<ChannelSummaryModel>) _serializer.Deserialize(localVarResponse, typeof(List<ChannelSummaryModel>)));
        }

    }
}
