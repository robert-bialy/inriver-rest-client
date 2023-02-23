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
    internal sealed class ModelApi : IModelApi
    {
        private readonly ISerializer _serializer;
        private ExceptionFactory _exceptionFactory =(name, response) => null;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ModelApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
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
        /// Create new CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>CVLValueModel</returns>
        public CVLValueModel CreateCvlValue(string cvlId, CVLValueModel cvlValueModel)
        {
             var localVarResponse = CreateCvlValueWithHttpInfo(cvlId, cvlValueModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create new CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        public ApiResponse<CVLValueModel> CreateCvlValueWithHttpInfo(string cvlId, CVLValueModel cvlValueModel)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelCreateCvlValue");
            // verify the required parameter 'cvlValueModel' is set
            if(cvlValueModel == null)
                throw new ApiException(400, "Missing required parameter 'cvlValueModel' when calling ModelApi->ModelCreateCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            if(cvlValueModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(cvlValueModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = cvlValueModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

        /// <summary>
        /// Create new CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of CVLValueModel</returns>
        public async System.Threading.Tasks.Task<CVLValueModel> CreateCvlValueAsync(string cvlId, CVLValueModel cvlValueModel)
        {
             ApiResponse<CVLValueModel> localVarResponse = await CreateCvlValueAsyncWithHttpInfo(cvlId, cvlValueModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create new CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of ApiResponse(CVLValueModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> CreateCvlValueAsyncWithHttpInfo(string cvlId, CVLValueModel cvlValueModel)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelCreateCvlValue");
            // verify the required parameter 'cvlValueModel' is set
            if(cvlValueModel == null)
                throw new ApiException(400, "Missing required parameter 'cvlValueModel' when calling ModelApi->ModelCreateCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            if(cvlValueModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(cvlValueModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = cvlValueModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

        /// <summary>
        /// Delete CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns></returns>
        public void DeleteCvlValue(string cvlId, string key)
        {
             DeleteCvlValueWithHttpInfo(cvlId, key);
        }

        /// <summary>
        /// Delete CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>ApiResponse of object(void)</returns>
        public ApiResponse<object> DeleteCvlValueWithHttpInfo(string cvlId, string key)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelDeleteCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelDeleteCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
                null);
        }

        /// <summary>
        /// Delete CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteCvlValueAsync(string cvlId, string key)
        {
            await DeleteCvlValueAsyncWithHttpInfo(cvlId, key);
        }

        /// <summary>
        /// Delete CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteCvlValueAsyncWithHttpInfo(string cvlId, string key)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelDeleteCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelDeleteCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
                null);
        }

        /// <summary>
        /// Returns all values for a CVL 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>List&lt;CVLValueModel&gt;</returns>
        public List<CVLValueModel> GetAllCvlValues(string cvlId)
        {
             ApiResponse<List<CVLValueModel>> localVarResponse = GetAllCvlValuesWithHttpInfo(cvlId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all values for a CVL 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>ApiResponse of List&lt;CVLValueModel&gt;</returns>
        public ApiResponse<List<CVLValueModel>> GetAllCvlValuesWithHttpInfo(string cvlId)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelGetAllCvlValues");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<CVLValueModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<CVLValueModel>) _serializer.Deserialize(localVarResponse, typeof(List<CVLValueModel>)));
        }

        /// <summary>
        /// Returns all values for a CVL 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>Task of List&lt;CVLValueModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<CVLValueModel>> GetAllCvlValuesAsync(string cvlId)
        {
             ApiResponse<List<CVLValueModel>> localVarResponse = await GetAllCvlValuesAsyncWithHttpInfo(cvlId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all values for a CVL 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>Task of ApiResponse(List&lt;CVLValueModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<CVLValueModel>>> GetAllCvlValuesAsyncWithHttpInfo(string cvlId)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelGetAllCvlValues");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<CVLValueModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<CVLValueModel>) _serializer.Deserialize(localVarResponse, typeof(List<CVLValueModel>)));
        }

        /// <summary>
        /// Returns all CVL&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;CVLModel&gt;</returns>
        public List<CVLModel> GetAllCvls()
        {
             var localVarResponse = GetAllCvlsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all CVL&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;CVLModel&gt;</returns>
        public ApiResponse<List<CVLModel>> GetAllCvlsWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/cvls";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<CVLModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<CVLModel>) _serializer.Deserialize(localVarResponse, typeof(List<CVLModel>)));
        }

        /// <summary>
        /// Returns all CVL&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;CVLModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<CVLModel>> GetAllCvlsAsync()
        {
             var localVarResponse = await GetAllCvlsAsyncWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all CVL&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;CVLModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<CVLModel>>> GetAllCvlsAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/cvls";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<CVLModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<CVLModel>) _serializer.Deserialize(localVarResponse, typeof(List<CVLModel>)));
        }

        /// <summary>
        /// Returns available entity types 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list(optional)</param>
        /// <returns>List&lt;EntityTypeModel&gt;</returns>
        public List<EntityTypeModel> GetAllEntityTypes(string entityTypeIds = null)
        {
             var localVarResponse = GetAllEntityTypesWithHttpInfo(entityTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available entity types 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list(optional)</param>
        /// <returns>ApiResponse of List&lt;EntityTypeModel&gt;</returns>
        public ApiResponse<List<EntityTypeModel>> GetAllEntityTypesWithHttpInfo(string entityTypeIds = null)
        {

            var localVarPath = "/api/v1.0.0/model/entitytypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            if(entityTypeIds != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<EntityTypeModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<EntityTypeModel>) _serializer.Deserialize(localVarResponse, typeof(List<EntityTypeModel>)));
        }

        /// <summary>
        /// Returns available entity types 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list(optional)</param>
        /// <returns>Task of List&lt;EntityTypeModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<EntityTypeModel>> GetAllEntityTypesAsync(string entityTypeIds = null)
        {
            var localVarResponse = await GetAllEntityTypesAsyncWithHttpInfo(entityTypeIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available entity types 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;EntityTypeModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<EntityTypeModel>>> GetAllEntityTypesAsyncWithHttpInfo(string entityTypeIds = null)
        {

            var localVarPath = "/api/v1.0.0/model/entitytypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            if(entityTypeIds != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "entityTypeIds", entityTypeIds, Configuration)); // query parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<EntityTypeModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<EntityTypeModel>) _serializer.Deserialize(localVarResponse, typeof(List<EntityTypeModel>)));
        }

        /// <summary>
        /// Returns available field sets 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;FieldSetModel&gt;</returns>
        public List<FieldSetModel> GetAllFieldSets()
        {
             var localVarResponse = GetAllFieldSetsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available field sets 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;FieldSetModel&gt;</returns>
        public ApiResponse<List<FieldSetModel>> GetAllFieldSetsWithHttpInfo()
        {
            var localVarPath = "/api/v1.0.0/model/fieldsets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<FieldSetModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<FieldSetModel>) _serializer.Deserialize(localVarResponse, typeof(List<FieldSetModel>)));
        }

        /// <summary>
        /// Returns available field sets 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;FieldSetModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<FieldSetModel>> GetAllFieldSetsAsync()
        {
             var localVarResponse = await GetAllFieldSetsAsyncWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available field sets 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;FieldSetModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FieldSetModel>>> GetAllFieldSetsAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/fieldsets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<FieldSetModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<FieldSetModel>) _serializer.Deserialize(localVarResponse, typeof(List<FieldSetModel>)));
        }

        /// <summary>
        /// Returns available languages 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;LanguageModel&gt;</returns>
        public List<LanguageModel> GetAllLanguages()
        {
             var localVarResponse = GetAllLanguagesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available languages 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;LanguageModel&gt;</returns>
        public ApiResponse<List<LanguageModel>> GetAllLanguagesWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/languages";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<LanguageModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<LanguageModel>) _serializer.Deserialize(localVarResponse, typeof(List<LanguageModel>)));
        }

        /// <summary>
        /// Returns available languages 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;LanguageModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<LanguageModel>> GetAllLanguagesAsync()
        {
             var localVarResponse = await GetAllLanguagesAsyncWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available languages 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;LanguageModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<LanguageModel>>> GetAllLanguagesAsyncWithHttpInfo()
        {
            var localVarPath = "/api/v1.0.0/model/languages";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<LanguageModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<LanguageModel>) _serializer.Deserialize(localVarResponse, typeof(List<LanguageModel>)));
        }

        /// <summary>
        /// Returns all specification templates 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;EntitySummaryModel&gt;</returns>
        public List<EntitySummaryModel> GetAllSpecificationTemplates()
        {
             var localVarResponse = GetAllSpecificationTemplatesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all specification templates 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;EntitySummaryModel&gt;</returns>
        public ApiResponse<List<EntitySummaryModel>> GetAllSpecificationTemplatesWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/specificationtemplates";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<EntitySummaryModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<EntitySummaryModel>) _serializer.Deserialize(localVarResponse, typeof(List<EntitySummaryModel>)));
        }

        /// <summary>
        /// Returns all specification templates 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;EntitySummaryModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<EntitySummaryModel>> GetAllSpecificationTemplatesAsync()
        {
             var localVarResponse = await GetAllSpecificationTemplatesAsyncWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns all specification templates 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;EntitySummaryModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<EntitySummaryModel>>> GetAllSpecificationTemplatesAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/model/specificationtemplates";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<EntitySummaryModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<EntitySummaryModel>) _serializer.Deserialize(localVarResponse, typeof(List<EntitySummaryModel>)));
        }

        /// <summary>
        /// Get CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>CVLValueModel</returns>
        public CVLValueModel GetCvlValue(string cvlId, string key)
        {
             var localVarResponse = GetCvlValueWithHttpInfo(cvlId, key);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        public ApiResponse<CVLValueModel> GetCvlValueWithHttpInfo(string cvlId, string key)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelGetCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelGetCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

        /// <summary>
        /// Get CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>Task of CVLValueModel</returns>
        public async System.Threading.Tasks.Task<CVLValueModel> GetCvlValueAsync(string cvlId, string key)
        {
             var localVarResponse = await GetCvlValueAsyncWithHttpInfo(cvlId, key);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>Task of ApiResponse(CVLValueModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> GetCvlValueAsyncWithHttpInfo(string cvlId, string key)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelGetCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelGetCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

        /// <summary>
        /// Returns field types for specification template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>List&lt;SpecificationFieldTypeModel&gt;</returns>
        public List<SpecificationFieldTypeModel> GetSpecificationTemplatesields(int? templateId)
        {
             var localVarResponse = GetSpecificationTemplatesieldsWithHttpInfo(templateId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns field types for specification template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>ApiResponse of List&lt;SpecificationFieldTypeModel&gt;</returns>
        public ApiResponse<List<SpecificationFieldTypeModel>> GetSpecificationTemplatesieldsWithHttpInfo(int? templateId)
        {
            // verify the required parameter 'templateId' is set
            if(templateId == null)
                throw new ApiException(400, "Missing required parameter 'templateId' when calling ModelApi->ModelGetSpecificationTemplatesields");

            var localVarPath = "/api/v1.0.0/model/specificationtemplates/{templateId}/fieldtypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("templateId", HttpHelpers.ParameterToString(templateId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<SpecificationFieldTypeModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SpecificationFieldTypeModel>) _serializer.Deserialize(localVarResponse, typeof(List<SpecificationFieldTypeModel>)));
        }

        /// <summary>
        /// Returns field types for specification template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>Task of List&lt;SpecificationFieldTypeModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SpecificationFieldTypeModel>> GetSpecificationTemplatesieldsAsync(int? templateId)
        {
             var localVarResponse = await GetSpecificationTemplatesieldsAsyncWithHttpInfo(templateId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns field types for specification template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>Task of ApiResponse(List&lt;SpecificationFieldTypeModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SpecificationFieldTypeModel>>> GetSpecificationTemplatesieldsAsyncWithHttpInfo(int? templateId)
        {
            // verify the required parameter 'templateId' is set
            if(templateId == null)
                throw new ApiException(400, "Missing required parameter 'templateId' when calling ModelApi->ModelGetSpecificationTemplatesields");

            var localVarPath = "/api/v1.0.0/model/specificationtemplates/{templateId}/fieldtypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("templateId", HttpHelpers.ParameterToString(templateId, Configuration)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<SpecificationFieldTypeModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SpecificationFieldTypeModel>) _serializer.Deserialize(localVarResponse, typeof(List<SpecificationFieldTypeModel>)));
        }

        /// <summary>
        /// Update CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>CVLValueModel</returns>
        public CVLValueModel UpdateCvlValue(string cvlId, string key, CVLValueModel cvlValueModel)
        {
             var localVarResponse = UpdateCvlValueWithHttpInfo(cvlId, key, cvlValueModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        public ApiResponse<CVLValueModel> UpdateCvlValueWithHttpInfo(string cvlId, string key, CVLValueModel cvlValueModel)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelUpdateCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelUpdateCvlValue");
            // verify the required parameter 'cvlValueModel' is set
            if(cvlValueModel == null)
                throw new ApiException(400, "Missing required parameter 'cvlValueModel' when calling ModelApi->ModelUpdateCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter
            if(cvlValueModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(cvlValueModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = cvlValueModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

        /// <summary>
        /// Update CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of CVLValueModel</returns>
        public async System.Threading.Tasks.Task<CVLValueModel> UpdateCvlValueAsync(string cvlId, string key, CVLValueModel cvlValueModel)
        {
             var localVarResponse = await UpdateCvlValueAsyncWithHttpInfo(cvlId, key, cvlValueModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update CVL value 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of ApiResponse(CVLValueModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> UpdateCvlValueAsyncWithHttpInfo(string cvlId, string key, CVLValueModel cvlValueModel)
        {
            // verify the required parameter 'cvlId' is set
            if(cvlId == null)
                throw new ApiException(400, "Missing required parameter 'cvlId' when calling ModelApi->ModelUpdateCvlValue");
            // verify the required parameter 'key' is set
            if(key == null)
                throw new ApiException(400, "Missing required parameter 'key' when calling ModelApi->ModelUpdateCvlValue");
            // verify the required parameter 'cvlValueModel' is set
            if(cvlValueModel == null)
                throw new ApiException(400, "Missing required parameter 'cvlValueModel' when calling ModelApi->ModelUpdateCvlValue");

            var localVarPath = "/api/v1.0.0/model/cvls/{cvlId}/values/{key}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
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

            localVarPathParams.Add("cvlId", HttpHelpers.ParameterToString(cvlId, Configuration)); // path parameter
            localVarPathParams.Add("key", HttpHelpers.ParameterToString(key, Configuration)); // path parameter
            if(cvlValueModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(cvlValueModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = cvlValueModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<CVLValueModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (CVLValueModel) _serializer.Deserialize(localVarResponse, typeof(CVLValueModel)));
        }

    }
}
