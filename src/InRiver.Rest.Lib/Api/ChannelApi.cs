using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using RestSharp;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal class ChannelApi : IChannelApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ChannelApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ChannelApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }
        
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
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
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ChannelPathContentModel</returns>
        public ChannelPathContentModel ChannelContent (string path, string entityTypeIds = null)
        {
             ApiResponse<ChannelPathContentModel> localVarResponse = ChannelContentWithHttpInfo(path, entityTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel path content Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of ChannelPathContentModel</returns>
        public ApiResponse< ChannelPathContentModel > ChannelContentWithHttpInfo (string path, string entityTypeIds = null)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling ChannelApi->ChannelChannelContent");

            var localVarPath = "/api/v1.0.0/channels/content/{path}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (path != null) localVarPathParams.Add("path", this.Configuration.ApiClient.ParameterToString(path)); // path parameter
            if (entityTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelChannelContent", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ChannelPathContentModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ChannelPathContentModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ChannelPathContentModel)));
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (path != null) localVarPathParams.Add("path", this.Configuration.ApiClient.ParameterToString(path)); // path parameter
            if (entityTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelChannelContent", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ChannelPathContentModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ChannelPathContentModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ChannelPathContentModel)));
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
        public ApiResponse< List<string> > EntityTypesWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelEntityTypes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitytypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
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
                (List<string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get entity types for channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> EntityTypesAsync (int? channelId)
        {
             ApiResponse<List<string>> localVarResponse = await EntityTypesAsyncWithHttpInfo(channelId);
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
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
                (List<string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
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
        public EntityListModel GetByEntityType (int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
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
        public ApiResponse< EntityListModel > GetByEntityTypeWithHttpInfo (int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (linkDirection != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkDirection", linkDirection)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetByEntityType", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
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
        public async System.Threading.Tasks.Task<EntityListModel> GetByEntityTypeAsync (int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
        {
             ApiResponse<EntityListModel> localVarResponse = await GetByEntityTypeAsyncWithHttpInfo(channelId, entityId, linkDirection, linkTypeId);
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
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> GetByEntityTypeAsyncWithHttpInfo (int? channelId, int? entityId, string linkDirection, string linkTypeId = null)
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (linkDirection != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkDirection", linkDirection)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetByEntityType", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
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
             ApiResponse<EntityListModel> localVarResponse = GetByLinkEntityTypeWithHttpInfo(channelId, entityTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse< EntityListModel > GetByLinkEntityTypeWithHttpInfo (int? channelId, string entityTypeId = null)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetByLinkEntityType");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/entitylist";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
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
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Get a list of entities in a channel 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> GetByLinkEntityTypeAsync (int? channelId, string entityTypeId = null)
        {
             ApiResponse<EntityListModel> localVarResponse = await GetByLinkEntityTypeAsyncWithHttpInfo(channelId, entityTypeId);
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
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
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Dictionary&lt;string, StructureNode&gt;</returns>
        public Dictionary<string, StructureNode> GetChannelNodeTree (int? channelId)
        {
             ApiResponse<Dictionary<string, StructureNode>> localVarResponse = GetChannelNodeTreeWithHttpInfo(channelId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, StructureNode&gt;</returns>
        public ApiResponse< Dictionary<string, StructureNode> > GetChannelNodeTreeWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodeTree");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodetree";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelNodeTree", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of Dictionary&lt;string, StructureNode&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, StructureNode>> GetChannelNodeTreeAsync (int? channelId)
        {
             ApiResponse<Dictionary<string, StructureNode>> localVarResponse = await GetChannelNodeTreeAsyncWithHttpInfo(channelId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Channel structure tree 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, StructureNode&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, StructureNode>>> GetChannelNodeTreeAsyncWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodeTree");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodetree";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelNodeTree", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Dictionary&lt;string, StructureNode&gt;</returns>
        public Dictionary<string, StructureNode> GetChannelNodes (int? channelId)
        {
             ApiResponse<Dictionary<string, StructureNode>> localVarResponse = GetChannelNodesWithHttpInfo(channelId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, StructureNode&gt;</returns>
        public ApiResponse< Dictionary<string, StructureNode> > GetChannelNodesWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelNodes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of Dictionary&lt;string, StructureNode&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, StructureNode>> GetChannelNodesAsync (int? channelId)
        {
             ApiResponse<Dictionary<string, StructureNode>> localVarResponse = await GetChannelNodesAsyncWithHttpInfo(channelId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Channel structure list 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, StructureNode&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, StructureNode>>> GetChannelNodesAsyncWithHttpInfo (int? channelId)
        {
            // verify the required parameter 'channelId' is set
            if (channelId == null)
                throw new ApiException(400, "Missing required parameter 'channelId' when calling ChannelApi->ChannelGetChannelNodes");

            var localVarPath = "/api/v1.0.0/channels/{channelId}/nodes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelNodes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, StructureNode>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, StructureNode>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, StructureNode>)));
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>List&lt;StructureEntityModel&gt;</returns>
        public List<StructureEntityModel> GetChannelStructureEntities (int? channelId, int? entityId)
        {
             ApiResponse<List<StructureEntityModel>> localVarResponse = GetChannelStructureEntitiesWithHttpInfo(channelId, entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;StructureEntityModel&gt;</returns>
        public ApiResponse< List<StructureEntityModel> > GetChannelStructureEntitiesWithHttpInfo (int? channelId, int? entityId)
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelStructureEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<StructureEntityModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<StructureEntityModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<StructureEntityModel>)));
        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;StructureEntityModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<StructureEntityModel>> GetChannelStructureEntitiesAsync (int? channelId, int? entityId)
        {
             ApiResponse<List<StructureEntityModel>> localVarResponse = await GetChannelStructureEntitiesAsyncWithHttpInfo(channelId, entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get structure entities for entity Returns all occurances of an entity in a channel
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;StructureEntityModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<StructureEntityModel>>> GetChannelStructureEntitiesAsyncWithHttpInfo (int? channelId, int? entityId)
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
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (channelId != null) localVarPathParams.Add("channelId", this.Configuration.ApiClient.ParameterToString(channelId)); // path parameter
            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ChannelGetChannelStructureEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<StructureEntityModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<StructureEntityModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<StructureEntityModel>)));
        }

        /// <summary>
        /// Get channel id&#39;s for entity id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>List&lt;ChannelSummaryModel&gt;</returns>
        public List<ChannelSummaryModel> GetChannelsForEntityId (int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
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
        public ApiResponse< List<ChannelSummaryModel> > GetChannelsForEntityIdWithHttpInfo (int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {

            var localVarPath = "/api/v1.0.0/channels";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (forEntityId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forEntityId", forEntityId)); // query parameter
            if (includeChannels != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeChannels", includeChannels)); // query parameter
            if (includePublications != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includePublications", includePublications)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
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
                (List<ChannelSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<ChannelSummaryModel>)));
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
             ApiResponse<List<ChannelSummaryModel>> localVarResponse = await GetChannelsForEntityIdAsyncWithHttpInfo(forEntityId, includeChannels, includePublications);
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
        public async System.Threading.Tasks.Task<ApiResponse<List<ChannelSummaryModel>>> GetChannelsForEntityIdAsyncWithHttpInfo (int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null)
        {

            var localVarPath = "/api/v1.0.0/channels";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (forEntityId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forEntityId", forEntityId)); // query parameter
            if (includeChannels != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeChannels", includeChannels)); // query parameter
            if (includePublications != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includePublications", includePublications)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
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
                (List<ChannelSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<ChannelSummaryModel>)));
        }

    }
}
