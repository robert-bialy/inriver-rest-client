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
    internal sealed class WorkareaApi : IWorkareaApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer">An instance of Serializer</param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public WorkareaApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
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
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel CreateWorkarea(WorkareaCreationModel creationModel)
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
        public ApiResponse<WorkareaFolderModel> CreateWorkareaWithHttpInfo(WorkareaCreationModel creationModel)
        {
            // verify the required parameter 'creationModel' is set
            if(creationModel == null)
                throw new ApiException(400, "Missing required parameter 'creationModel' when calling WorkareaApi->WorkareaCreateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder:createnew";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if(creationModel != null && creationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(creationModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = creationModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> CreateWorkareaAsync(WorkareaCreationModel creationModel)
        {
             var localVarResponse = await CreateWorkareaAsyncWithHttpInfo(creationModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a new workarea Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of ApiResponse(WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> CreateWorkareaAsyncWithHttpInfo(WorkareaCreationModel creationModel)
        {
            // verify the required parameter 'creationModel' is set
            if(creationModel == null)
                throw new ApiException(400, "Missing required parameter 'creationModel' when calling WorkareaApi->WorkareaCreateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder:createnew";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            if(creationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(creationModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = creationModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns></returns>
        public void DeleteWorkarea(string workareaFolderId)
        {
             DeleteWorkareaWithHttpInfo(workareaFolderId);
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of object(void)</returns>
        public ApiResponse<object> DeleteWorkareaWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaDeleteWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
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
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if(workareaFolderId != null) localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
                null);
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteWorkareaAsync(string workareaFolderId)
        {
             await DeleteWorkareaAsyncWithHttpInfo(workareaFolderId);
        }

        /// <summary>
        /// Delete workarea folder 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteWorkareaAsyncWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaDeleteWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
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
            };
            String localVarHttpHeaderAccept = HttpHelpers.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if(localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if(workareaFolderId != null) localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
                null);
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> GetWorkareaFolderEntityIds(string workareaFolderId)
        {
             var localVarResponse = GetWorkareaFolderEntityIdsWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse<List<int?>> GetWorkareaFolderEntityIdsWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaGetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<int?>) _serializer.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> GetWorkareaFolderEntityIdsAsync(string workareaFolderId)
        {
             var localVarResponse = await GetWorkareaFolderEntityIdsAsyncWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse(List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> GetWorkareaFolderEntityIdsAsyncWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaGetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<int?>) _serializer.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> GetWorkareaFolderEntityIds(string workareaFolderId, List<int?> entityIds)
        {
             var localVarResponse = SetWorkareaFolderEntityIdsWithHttpInfo(workareaFolderId, entityIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse<List<int?>> SetWorkareaFolderEntityIdsWithHttpInfo(string workareaFolderId, List<int?> entityIds)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");
            // verify the required parameter 'entityIds' is set
            if(entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(entityIds.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(entityIds); // http body(model) parameter
            }
            else
            {
                localVarPostBody = entityIds; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<int?>) _serializer.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> SetWorkareaFolderEntityIdsAsync(string workareaFolderId, List<int?> entityIds)
        {
             var localVarResponse = await SetWorkareaFolderEntityIdsAsyncWithHttpInfo(workareaFolderId, entityIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set entity id&#39;s in a static workarea 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of ApiResponse(List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> SetWorkareaFolderEntityIdsAsyncWithHttpInfo(string workareaFolderId, List<int?> entityIds)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");
            // verify the required parameter 'entityIds' is set
            if(entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling WorkareaApi->WorkareaSetWorkareaFolderEntityIds");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entityIds";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(entityIds.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(entityIds); // http body(model) parameter
            }
            else
            {
                localVarPostBody = entityIds; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<int?>) _serializer.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel UpdateWorkarea(string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
             var localVarResponse = UpdateWorkareaWithHttpInfo(workareaFolderId, workareaFolderModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        public ApiResponse<WorkareaFolderModel> UpdateWorkareaWithHttpInfo(string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkarea");
            // verify the required parameter 'workareaFolderModel' is set
            if(workareaFolderModel == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderModel' when calling WorkareaApi->WorkareaUpdateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(workareaFolderModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(workareaFolderModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = workareaFolderModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaAsync(string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
             var localVarResponse = await UpdateWorkareaAsyncWithHttpInfo(workareaFolderId, workareaFolderModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea folder It&#39;s only possible to alter name and index properties
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of ApiResponse(WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaAsyncWithHttpInfo(string workareaFolderId, WorkareaFolderModel workareaFolderModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkarea");
            // verify the required parameter 'workareaFolderModel' is set
            if(workareaFolderModel == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderModel' when calling WorkareaApi->WorkareaUpdateWorkarea");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(workareaFolderModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(workareaFolderModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = workareaFolderModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        public WorkareaFolderModel UpdateWorkareaQuery(string workareaFolderId, QueryModel queryModel)
        {
             var localVarResponse = UpdateWorkareaQueryWithHttpInfo(workareaFolderId, queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        public ApiResponse<WorkareaFolderModel> UpdateWorkareaQueryWithHttpInfo(string workareaFolderId, QueryModel queryModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");
            // verify the required parameter 'queryModel' is set
            if(queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/query";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(queryModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        public async System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaQueryAsync(string workareaFolderId, QueryModel queryModel)
        {
             var localVarResponse = await UpdateWorkareaQueryAsyncWithHttpInfo(workareaFolderId, queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update workarea query Check the description for the /query endpoint on how to constuct a query.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of ApiResponse(WorkareaFolderModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaQueryAsyncWithHttpInfo(string workareaFolderId, QueryModel queryModel)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");
            // verify the required parameter 'queryModel' is set
            if(queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling WorkareaApi->WorkareaUpdateWorkareaQuery");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/query";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =  {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter
            if(queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(queryModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<WorkareaFolderModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (WorkareaFolderModel) _serializer.Deserialize(localVarResponse, typeof(WorkareaFolderModel)));
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>List&lt;WorkareaTreeFolderModel&gt;</returns>
        public List<WorkareaTreeFolderModel> WorkareaFolderTree(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             var localVarResponse = WorkareaFolderTreeWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaTreeFolderModel&gt;</returns>
        public ApiResponse<List<WorkareaTreeFolderModel>> WorkareaFolderTreeWithHttpInfo(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafoldertree";
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

            if(includeCreatedByMe != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe, Configuration)); // query parameter
            if(includeShared != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeShared", includeShared, Configuration)); // query parameter
            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<WorkareaTreeFolderModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<WorkareaTreeFolderModel>) _serializer.Deserialize(localVarResponse, typeof(List<WorkareaTreeFolderModel>)));
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>Task of List&lt;WorkareaTreeFolderModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<WorkareaTreeFolderModel>> WorkareaFolderTreeAsync(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             var localVarResponse = await WorkareaFolderTreeAsyncWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folder tree The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;WorkareaTreeFolderModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<WorkareaTreeFolderModel>>> WorkareaFolderTreeAsyncWithHttpInfo(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafoldertree";
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

            if(includeCreatedByMe != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe, Configuration)); // query parameter
            if(includeShared != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeShared", includeShared, Configuration)); // query parameter
            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<WorkareaTreeFolderModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<WorkareaTreeFolderModel>) _serializer.Deserialize(localVarResponse, typeof(List<WorkareaTreeFolderModel>)));
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>List&lt;WorkareaFolderModel&gt;</returns>
        public List<WorkareaFolderModel> WorkareaFolders(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             var localVarResponse = WorkareaFoldersWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaFolderModel&gt;</returns>
        public ApiResponse<List<WorkareaFolderModel>> WorkareaFoldersWithHttpInfo(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafolders";
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

            if(includeCreatedByMe != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe, Configuration)); // query parameter
            if(includeShared != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeShared", includeShared, Configuration)); // query parameter
            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<WorkareaFolderModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<WorkareaFolderModel>) _serializer.Deserialize(localVarResponse, typeof(List<WorkareaFolderModel>)));
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>Task of List&lt;WorkareaFolderModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<WorkareaFolderModel>> WorkareaFoldersAsync(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {
             var localVarResponse = await WorkareaFoldersAsyncWithHttpInfo(includeCreatedByMe, includeShared, forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get workarea folders The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional(optional)</param>
        /// <param name="includeShared">optional(optional)</param>
        /// <param name="forUsername">optional(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;WorkareaFolderModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<WorkareaFolderModel>>> WorkareaFoldersAsyncWithHttpInfo(bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/workareafolders";
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

            if(includeCreatedByMe != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeCreatedByMe", includeCreatedByMe, Configuration)); // query parameter
            if(includeShared != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "includeShared", includeShared, Configuration)); // query parameter
            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<WorkareaFolderModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<WorkareaFolderModel>) _serializer.Deserialize(localVarResponse, typeof(List<WorkareaFolderModel>)));
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>EntityListModel</returns>
        public EntityListModel WorkareaQueryResult(string workareaFolderId)
        {
             var localVarResponse = WorkareaQueryResultWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse<EntityListModel> WorkareaQueryResultWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaWorkareaQueryResult");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entitylist";
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;
            
            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> WorkareaQueryResultAsync(string workareaFolderId)
        {
             var localVarResponse = await WorkareaQueryResultAsyncWithHttpInfo(workareaFolderId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a list of entities in a workarea folder Returns an entity list for any type of workarea
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse(EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> WorkareaQueryResultAsyncWithHttpInfo(string workareaFolderId)
        {
            // verify the required parameter 'workareaFolderId' is set
            if(workareaFolderId == null)
                throw new ApiException(400, "Missing required parameter 'workareaFolderId' when calling WorkareaApi->WorkareaWorkareaQueryResult");

            var localVarPath = "/api/v1.0.0/workareafolder/{workareaFolderId}/entitylist";
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

            localVarPathParams.Add("workareaFolderId", HttpHelpers.ParameterToString(workareaFolderId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }
    }
}
