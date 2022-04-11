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
    internal class WorkareaApi : IWorkareaApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public WorkareaApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public WorkareaApi(Configuration configuration = null)
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
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel CreateWorkarea (WorkareaCreationModel creationModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = CreateWorkareaWithHttpInfo(creationModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        public ApiResponse< WorkareaFolderModel > CreateWorkareaWithHttpInfo (WorkareaCreationModel creationModel)
        {
            // verify the required parameter 'creationModel' is set
            if (creationModel == null)
                throw new ApiException(400, "Missing required parameter 'creationModel' when calling WorkareaApi->WorkareaCreateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder:createnew";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (creationModel != null && creationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(creationModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = creationModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaCreateWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> CreateWorkareaAsync (WorkareaCreationModel creationModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = await CreateWorkareaAsyncWithHttpInfo(creationModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> CreateWorkareaAsyncWithHttpInfo (WorkareaCreationModel creationModel)
        {
            // verify the required parameter 'creationModel' is set
            if (creationModel == null)
                throw new ApiException(400, "Missing required parameter 'creationModel' when calling WorkareaApi->WorkareaCreateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder:createnew";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (creationModel != null && creationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(creationModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = creationModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaCreateWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns></returns>
        public void DeleteWorkarea (string workareaFolderId)
        {
             DeleteWorkareaWithHttpInfo(workareaFolderId);
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteWorkareaWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaDeleteWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
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
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaDeleteWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteWorkareaAsync (string workareaFolderId)
        {
             await DeleteWorkareaAsyncWithHttpInfo(workareaFolderId);

        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteWorkareaAsyncWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaDeleteWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
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
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaDeleteWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> GetWorkareaFolderEntityIds (string workareaFolderId)
        {
             ApiResponse<List<int?>> localVarResponse = GetWorkareaFolderEntityIdsWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse< List<int?> > GetWorkareaFolderEntityIdsWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaGetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaGetWorkareaFolderEntityIds", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> GetWorkareaFolderEntityIdsAsync (string workareaFolderId)
        {
             ApiResponse<List<int?>> localVarResponse = await GetWorkareaFolderEntityIdsAsyncWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> GetWorkareaFolderEntityIdsAsyncWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaGetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaGetWorkareaFolderEntityIds", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> GetWorkareaFolderEntityIds (string workareaFolderId, List<int?> entityIds)
        {
             ApiResponse<List<int?>> localVarResponse = SetWorkareaFolderEntityIdsWithHttpInfo(workareaFolderId, entityIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse< List<int?> > SetWorkareaFolderEntityIdsWithHttpInfo (string workareaFolderId, List<int?> entityIds)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");
            // verify the required parameter 'entityIds' is set
            if (entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (entityIds != null && entityIds.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(entityIds); // http body (model) parameter
            }
            else
            {
                localVarPostBody = entityIds; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaSetWorkareaFolderEntityIds", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> SetWorkareaFolderEntityIdsAsync (string workareaFolderId, List<int?> entityIds)
        {
             ApiResponse<List<int?>> localVarResponse = await SetWorkareaFolderEntityIdsAsyncWithHttpInfo(workareaFolderId, entityIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> SetWorkareaFolderEntityIdsAsyncWithHttpInfo (string workareaFolderId, List<int?> entityIds)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");
            // verify the required parameter 'entityIds' is set
            if (entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (entityIds != null && entityIds.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(entityIds); // http body (model) parameter
            }
            else
            {
                localVarPostBody = entityIds; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaSetWorkareaFolderEntityIds", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel UpdateWorkarea (string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = UpdateWorkareaWithHttpInfo(workareaFolderId, workareaFolderModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        public ApiResponse< WorkareaFolderModel > UpdateWorkareaWithHttpInfo (string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkarea");
            // verify the required parameter 'workareaFolderModel' is set
            if (workareaFolderModel == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderModel' when calling WorkareaApi->WorkareaUpdateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (workareaFolderModel != null && workareaFolderModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(workareaFolderModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = workareaFolderModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaUpdateWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaAsync (string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = await UpdateWorkareaAsyncWithHttpInfo(workareaFolderId, workareaFolderModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaAsyncWithHttpInfo (string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkarea");
            // verify the required parameter 'workareaFolderModel' is set
            if (workareaFolderModel == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderModel' when calling WorkareaApi->WorkareaUpdateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (workareaFolderModel != null && workareaFolderModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(workareaFolderModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = workareaFolderModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaUpdateWorkarea", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel UpdateWorkareaQuery (string workareaFolderId, QueryModel queryModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = UpdateWorkareaQueryWithHttpInfo(workareaFolderId, queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        public ApiResponse< WorkareaFolderModel > UpdateWorkareaQueryWithHttpInfo (string workareaFolderId, QueryModel queryModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");
            // verify the required parameter 'queryModel' is set
            if (queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/query";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (queryModel != null && queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(queryModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaUpdateWorkareaQuery", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaQueryAsync (string workareaFolderId, QueryModel queryModel)
        {
             ApiResponse<WorkareaFolderModel> localVarResponse = await UpdateWorkareaQueryAsyncWithHttpInfo(workareaFolderId, queryModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaQueryAsyncWithHttpInfo (string workareaFolderId, QueryModel queryModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");
            // verify the required parameter 'queryModel' is set
            if (queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/query";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter
            if (queryModel != null && queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(queryModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaUpdateWorkareaQuery", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (WorkareaFolderModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>List&lt;WorkareaTreeFolderModel&gt;</returns>
        public List<WorkareaTreeFolderModel> WorkareaFolderTree (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             ApiResponse<List<WorkareaTreeFolderModel>> localVarResponse = WorkareaFolderTreeWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaTreeFolderModel&gt;</returns>
        public ApiResponse< List<WorkareaTreeFolderModel> > WorkareaFolderTreeWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafoldertree";
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

            if (includeCreatedByMe != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe)); // query parameter
            if (includeShared != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeShared", includeShared)); // query parameter
            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaFolderTree", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<WorkareaTreeFolderModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<WorkareaTreeFolderModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<WorkareaTreeFolderModel>)));
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of List&lt;WorkareaTreeFolderModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<WorkareaTreeFolderModel>> WorkareaFolderTreeAsync (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             ApiResponse<List<WorkareaTreeFolderModel>> localVarResponse = await WorkareaFolderTreeAsyncWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;WorkareaTreeFolderModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<WorkareaTreeFolderModel>>> WorkareaFolderTreeAsyncWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafoldertree";
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

            if (includeCreatedByMe != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe)); // query parameter
            if (includeShared != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeShared", includeShared)); // query parameter
            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaFolderTree", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<WorkareaTreeFolderModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<WorkareaTreeFolderModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<WorkareaTreeFolderModel>)));
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>List&lt;WorkareaFolderModel&gt;</returns>
        public List<WorkareaFolderModel> WorkareaFolders (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             ApiResponse<List<WorkareaFolderModel>> localVarResponse = WorkareaFoldersWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaFolderModel&gt;</returns>
        public ApiResponse< List<WorkareaFolderModel> > WorkareaFoldersWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafolders";
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

            if (includeCreatedByMe != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe)); // query parameter
            if (includeShared != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeShared", includeShared)); // query parameter
            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaFolders", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<WorkareaFolderModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<WorkareaFolderModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<WorkareaFolderModel>)));
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of List&lt;WorkareaFolderModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<WorkareaFolderModel>> WorkareaFoldersAsync (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             ApiResponse<List<WorkareaFolderModel>> localVarResponse = await WorkareaFoldersAsyncWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;WorkareaFolderModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<WorkareaFolderModel>>> WorkareaFoldersAsyncWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafolders";
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

            if (includeCreatedByMe != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe)); // query parameter
            if (includeShared != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "includeShared", includeShared)); // query parameter
            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaFolders", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<WorkareaFolderModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<WorkareaFolderModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<WorkareaFolderModel>)));
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>EntityListModel</returns>
        public EntityListModel WorkareaQueryResult (string workareaFolderId)
        {
             ApiResponse<EntityListModel> localVarResponse = WorkareaQueryResultWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse< EntityListModel > WorkareaQueryResultWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaWorkareaQueryResult");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entitylist";
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaQueryResult", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> WorkareaQueryResultAsync (string workareaFolderId)
        {
             ApiResponse<EntityListModel> localVarResponse = await WorkareaQueryResultAsyncWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> WorkareaQueryResultAsyncWithHttpInfo (string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if (workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaWorkareaQueryResult");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entitylist";
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

            if (workareaFolderId != null) localVarPathParams.Add("workareaFolderId", this.Configuration.ApiClient.ParameterToString(workareaFolderId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("WorkareaWorkareaQueryResult", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

    }
}
