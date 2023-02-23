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
    internal sealed class SystemApi : ISystemApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SystemApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
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
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel AddUserRoleForSegment(int? segmentId, UserRoleModel userRoleModel)
        {
             var localVarResponse = AddUserRoleForSegmentWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse<UserRolesModel> AddUserRoleForSegmentWithHttpInfo(int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemAddUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if(userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemAddUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:adduserrole";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRoleModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> AddUserRoleForSegmentAsync(int? segmentId, UserRoleModel userRoleModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = await AddUserRoleForSegmentAsyncWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> AddUserRoleForSegmentAsyncWithHttpInfo(int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemAddUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if(userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemAddUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:adduserrole";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRoleModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetAllImageConfigurations()
        {
             var localVarResponse = GetAllImageConfigurationsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public ApiResponse<List<string>> GetAllImageConfigurationsWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurations";
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

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetAllImageConfigurationsAsync()
        {
             ApiResponse<List<string>> localVarResponse = await GetAllImageConfigurationsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> GetAllImageConfigurationsAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurations";
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

            int localVarStatusCode =(int)localVarResponse.StatusCode;

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<string>) _serializer.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ImageConfigurationDetailsModel</returns>
        public ImageConfigurationDetailsModel GetImageConfigurationDetails()
        {
             var localVarResponse = GetImageConfigurationDetailsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of ImageConfigurationDetailsModel</returns>
        public ApiResponse<ImageConfigurationDetailsModel> GetImageConfigurationDetailsWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurationdetails";
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

            return new ApiResponse<ImageConfigurationDetailsModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (ImageConfigurationDetailsModel) _serializer.Deserialize(localVarResponse, typeof(ImageConfigurationDetailsModel)));
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ImageConfigurationDetailsModel</returns>
        public async System.Threading.Tasks.Task<ImageConfigurationDetailsModel> GetImageConfigurationDetailsAsync()
        {
             var localVarResponse = await GetImageConfigurationDetailsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(ImageConfigurationDetailsModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ImageConfigurationDetailsModel>> GetImageConfigurationDetailsAsyncWithHttpInfo()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurationdetails";
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

            return new ApiResponse<ImageConfigurationDetailsModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (ImageConfigurationDetailsModel) _serializer.Deserialize(localVarResponse, typeof(ImageConfigurationDetailsModel)));
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        public Dictionary<string, string> GetServerSettings(string settingNames = null)
        {
             var localVarResponse = GetServerSettingsWithHttpInfo(settingNames);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        public ApiResponse<Dictionary<string, string>> GetServerSettingsWithHttpInfo(string settingNames = null)
        {
            var localVarPath = "/api/v1.0.0/system/serversettings";
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

            if(settingNames != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "settingNames", settingNames, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (Dictionary<string, string>) _serializer.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Task of Dictionary&lt;string, string&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, string>> GetServerSettingsAsync(string settingNames = null)
        {
             var localVarResponse = await GetServerSettingsAsyncWithHttpInfo(settingNames);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Task of ApiResponse(Dictionary&lt;string, string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, string>>> GetServerSettingsAsyncWithHttpInfo(string settingNames = null)
        {

            var localVarPath = "/api/v1.0.0/system/serversettings";
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

            if(settingNames != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "settingNames", settingNames, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (Dictionary<string, string>) _serializer.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel RemoveUserRoleForSegment(int? segmentId, UserRoleModel userRoleModel)
        {
             var localVarResponse = RemoveUserRoleForSegmentWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse<UserRolesModel> RemoveUserRoleForSegmentWithHttpInfo(int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemRemoveUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if(userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemRemoveUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:removeuserrole";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRoleModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> RemoveUserRoleForSegmentAsync(int? segmentId, UserRoleModel userRoleModel)
        {
             var localVarResponse = await RemoveUserRoleForSegmentAsyncWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> RemoveUserRoleForSegmentAsyncWithHttpInfo(int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemRemoveUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if(userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemRemoveUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:removeuserrole";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRoleModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>List&lt;RoleModel&gt;</returns>
        public List<RoleModel> Roles(string forUsername = null)
        {
             var localVarResponse = RolesWithHttpInfo(forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>ApiResponse of List&lt;RoleModel&gt;</returns>
        public ApiResponse<List<RoleModel>> RolesWithHttpInfo(string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/roles";
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

            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<RoleModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<RoleModel>) _serializer.Deserialize(localVarResponse, typeof(List<RoleModel>)));
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>Task of List&lt;RoleModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<RoleModel>> RolesAsync(string forUsername = null)
        {
             var localVarResponse = await RolesAsyncWithHttpInfo(forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;RoleModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<RoleModel>>> RolesAsyncWithHttpInfo(string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/roles";
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

            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<RoleModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<RoleModel>) _serializer.Deserialize(localVarResponse, typeof(List<RoleModel>)));
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>List&lt;SegmentModel&gt;</returns>
        public List<SegmentModel> Segments(string forUsername = null)
        {
             var localVarResponse = SegmentsWithHttpInfo(forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>ApiResponse of List&lt;SegmentModel&gt;</returns>
        public ApiResponse<List<SegmentModel>> SegmentsWithHttpInfo(string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/segments";
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

            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<SegmentModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SegmentModel>) _serializer.Deserialize(localVarResponse, typeof(List<SegmentModel>)));
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>Task of List&lt;SegmentModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SegmentModel>> SegmentsAsync(string forUsername = null)
        {
             var localVarResponse = await SegmentsAsyncWithHttpInfo(forUsername);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;SegmentModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SegmentModel>>> SegmentsAsyncWithHttpInfo(string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/segments";
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

            if(forUsername != null) localVarQueryParams.AddRange(HttpHelpers.ParameterToKeyValuePairs("", "forUsername", forUsername, Configuration)); // query parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<List<SegmentModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<SegmentModel>) _serializer.Deserialize(localVarResponse, typeof(List<SegmentModel>)));
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel SetUserRolesForSegment(int? segmentId, UserRolesModel userRolesModel)
        {
             var localVarResponse = SetUserRolesForSegmentWithHttpInfo(segmentId, userRolesModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse<UserRolesModel> SetUserRolesForSegmentWithHttpInfo(int? segmentId, UserRolesModel userRolesModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemSetUserRolesForSegment");
            // verify the required parameter 'userRolesModel' is set
            if(userRolesModel == null)
                throw new ApiException(400, "Missing required parameter 'userRolesModel' when calling SystemApi->SystemSetUserRolesForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:setuserroles";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRolesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRolesModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRolesModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> SetUserRolesForSegmentAsync(int? segmentId, UserRolesModel userRolesModel)
        {
             var localVarResponse = await GetUserRolesForSegmentAsyncWithHttpInfo(segmentId, userRolesModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> GetUserRolesForSegmentAsyncWithHttpInfo(int? segmentId, UserRolesModel userRolesModel)
        {
            // verify the required parameter 'segmentId' is set
            if(segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemSetUserRolesForSegment");
            // verify the required parameter 'userRolesModel' is set
            if(userRolesModel == null)
                throw new ApiException(400, "Missing required parameter 'userRolesModel' when calling SystemApi->SystemSetUserRolesForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:setuserroles";
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

            localVarPathParams.Add("segmentId", HttpHelpers.ParameterToString(segmentId, Configuration)); // path parameter
            if(userRolesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(userRolesModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = userRolesModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (UserRolesModel) _serializer.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

    }
}
