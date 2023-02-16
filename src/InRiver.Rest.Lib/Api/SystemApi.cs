using System;
using System.Collections.Generic;
using System.Linq;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using RestSharp;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal sealed class SystemApi : ISystemApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SystemApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

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
            set { _exceptionFactory = value; }
        }
        
        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel AddUserRoleForSegment (int? segmentId, UserRoleModel userRoleModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = AddUserRoleForSegmentWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse< UserRolesModel > AddUserRoleForSegmentWithHttpInfo (int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemAddUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if (userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemAddUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:adduserrole";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRoleModel != null && userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRoleModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemAddUserRoleForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Assign a role to a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> AddUserRoleForSegmentAsync (int? segmentId, UserRoleModel userRoleModel)
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
        /// <returns>Task of ApiResponse (UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> AddUserRoleForSegmentAsyncWithHttpInfo (int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemAddUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if (userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemAddUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:adduserrole";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRoleModel != null && userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRoleModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemAddUserRoleForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetAllImageConfigurations ()
        {
             ApiResponse<List<string>> localVarResponse = GetAllImageConfigurationsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public ApiResponse< List<string> > GetAllImageConfigurationsWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurations";
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



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetAllImageConfigurations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetAllImageConfigurationsAsync ()
        {
             ApiResponse<List<string>> localVarResponse = await GetAllImageConfigurationsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> GetAllImageConfigurationsAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurations";
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



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetAllImageConfigurations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ImageConfigurationDetailsModel</returns>
        public ImageConfigurationDetailsModel GetImageConfigurationDetails ()
        {
             ApiResponse<ImageConfigurationDetailsModel> localVarResponse = GetImageConfigurationDetailsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of ImageConfigurationDetailsModel</returns>
        public ApiResponse< ImageConfigurationDetailsModel > GetImageConfigurationDetailsWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurationdetails";
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



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetImageConfigurationDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ImageConfigurationDetailsModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ImageConfigurationDetailsModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ImageConfigurationDetailsModel)));
        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ImageConfigurationDetailsModel</returns>
        public async System.Threading.Tasks.Task<ImageConfigurationDetailsModel> GetImageConfigurationDetailsAsync ()
        {
             ApiResponse<ImageConfigurationDetailsModel> localVarResponse = await GetImageConfigurationDetailsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Return full details of available image configurations 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (ImageConfigurationDetailsModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ImageConfigurationDetailsModel>> GetImageConfigurationDetailsAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/system/imageconfigurationdetails";
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



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetImageConfigurationDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ImageConfigurationDetailsModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ImageConfigurationDetailsModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ImageConfigurationDetailsModel)));
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names (optional)</param>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        public Dictionary<string, string> GetServerSettings (string settingNames = null)
        {
             ApiResponse<Dictionary<string, string>> localVarResponse = GetServerSettingsWithHttpInfo(settingNames);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names (optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        public ApiResponse< Dictionary<string, string> > GetServerSettingsWithHttpInfo (string settingNames = null)
        {

            var localVarPath = "/api/v1.0.0/system/serversettings";
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

            if (settingNames != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "settingNames", settingNames)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetServerSettings", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names (optional)</param>
        /// <returns>Task of Dictionary&lt;string, string&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, string>> GetServerSettingsAsync (string settingNames = null)
        {
             ApiResponse<Dictionary<string, string>> localVarResponse = await GetServerSettingsAsyncWithHttpInfo(settingNames);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of server settings Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names (optional)</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, string&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, string>>> GetServerSettingsAsyncWithHttpInfo (string settingNames = null)
        {

            var localVarPath = "/api/v1.0.0/system/serversettings";
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

            if (settingNames != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "settingNames", settingNames)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemGetServerSettings", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, string>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel RemoveUserRoleForSegment (int? segmentId, UserRoleModel userRoleModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = RemoveUserRoleForSegmentWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse< UserRolesModel > RemoveUserRoleForSegmentWithHttpInfo (int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemRemoveUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if (userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemRemoveUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:removeuserrole";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRoleModel != null && userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRoleModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemRemoveUserRoleForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> RemoveUserRoleForSegmentAsync (int? segmentId, UserRoleModel userRoleModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = await RemoveUserRoleForSegmentAsyncWithHttpInfo(segmentId, userRoleModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Remove a role from a user and segment The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of ApiResponse (UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> RemoveUserRoleForSegmentAsyncWithHttpInfo (int? segmentId, UserRoleModel userRoleModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemRemoveUserRoleForSegment");
            // verify the required parameter 'userRoleModel' is set
            if (userRoleModel == null)
                throw new ApiException(400, "Missing required parameter 'userRoleModel' when calling SystemApi->SystemRemoveUserRoleForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:removeuserrole";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRoleModel != null && userRoleModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRoleModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRoleModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemRemoveUserRoleForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user (optional)</param>
        /// <returns>List&lt;RoleModel&gt;</returns>
        public List<RoleModel> Roles (string forUsername = null)
        {
             ApiResponse<List<RoleModel>> localVarResponse = RolesWithHttpInfo(forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user (optional)</param>
        /// <returns>ApiResponse of List&lt;RoleModel&gt;</returns>
        public ApiResponse< List<RoleModel> > RolesWithHttpInfo (string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/roles";
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

            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemRoles", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<RoleModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<RoleModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<RoleModel>)));
        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user (optional)</param>
        /// <returns>Task of List&lt;RoleModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<RoleModel>> RolesAsync (string forUsername = null)
        {
             ApiResponse<List<RoleModel>> localVarResponse = await RolesAsyncWithHttpInfo(forUsername);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of user roles and permissions If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;RoleModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<RoleModel>>> RolesAsyncWithHttpInfo (string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/roles";
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

            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemRoles", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<RoleModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<RoleModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<RoleModel>)));
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user (optional)</param>
        /// <returns>List&lt;SegmentModel&gt;</returns>
        public List<SegmentModel> Segments (string forUsername = null)
        {
             ApiResponse<List<SegmentModel>> localVarResponse = SegmentsWithHttpInfo(forUsername);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user (optional)</param>
        /// <returns>ApiResponse of List&lt;SegmentModel&gt;</returns>
        public ApiResponse< List<SegmentModel> > SegmentsWithHttpInfo (string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/segments";
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

            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemSegments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SegmentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SegmentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SegmentModel>)));
        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user (optional)</param>
        /// <returns>Task of List&lt;SegmentModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SegmentModel>> SegmentsAsync (string forUsername = null)
        {
             ApiResponse<List<SegmentModel>> localVarResponse = await SegmentsAsyncWithHttpInfo(forUsername);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of segments Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;SegmentModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SegmentModel>>> SegmentsAsyncWithHttpInfo (string forUsername = null)
        {

            var localVarPath = "/api/v1.0.0/system/segments";
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

            if (forUsername != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "forUsername", forUsername)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemSegments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SegmentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SegmentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SegmentModel>)));
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>UserRolesModel</returns>
        public UserRolesModel SetUserRolesForSegment (int? segmentId, UserRolesModel userRolesModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = SetUserRolesForSegmentWithHttpInfo(segmentId, userRolesModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        public ApiResponse< UserRolesModel > SetUserRolesForSegmentWithHttpInfo (int? segmentId, UserRolesModel userRolesModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemSetUserRolesForSegment");
            // verify the required parameter 'userRolesModel' is set
            if (userRolesModel == null)
                throw new ApiException(400, "Missing required parameter 'userRolesModel' when calling SystemApi->SystemSetUserRolesForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:setuserroles";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRolesModel != null && userRolesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRolesModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRolesModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemSetUserRolesForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        public async System.Threading.Tasks.Task<UserRolesModel> SetUserRolesForSegmentAsync (int? segmentId, UserRolesModel userRolesModel)
        {
             ApiResponse<UserRolesModel> localVarResponse = await GaetUserRolesForSegmentAsyncWithHttpInfo(segmentId, userRolesModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Modify user access for segment The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of ApiResponse (UserRolesModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> GaetUserRolesForSegmentAsyncWithHttpInfo (int? segmentId, UserRolesModel userRolesModel)
        {
            // verify the required parameter 'segmentId' is set
            if (segmentId == null)
                throw new ApiException(400, "Missing required parameter 'segmentId' when calling SystemApi->SystemSetUserRolesForSegment");
            // verify the required parameter 'userRolesModel' is set
            if (userRolesModel == null)
                throw new ApiException(400, "Missing required parameter 'userRolesModel' when calling SystemApi->SystemSetUserRolesForSegment");

            var localVarPath = "/api/v1.0.0/system/segments/{segmentId}:setuserroles";
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

            if (segmentId != null) localVarPathParams.Add("segmentId", this.Configuration.ApiClient.ParameterToString(segmentId)); // path parameter
            if (userRolesModel != null && userRolesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(userRolesModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userRolesModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SystemSetUserRolesForSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserRolesModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserRolesModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserRolesModel)));
        }

    }
}
