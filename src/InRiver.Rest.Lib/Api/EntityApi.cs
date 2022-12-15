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
    internal class EntityApi : IEntityApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityApi"/> class.
        /// </summary>
        /// <returns></returns>
        public EntityApi(String basePath)
        {
            Configuration = new Configuration { BasePath = basePath };
            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public EntityApi(Configuration configuration = null)
        {
            Configuration = configuration ?? Configuration.Default;
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
            set => _exceptionFactory = value;
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
        /// Add external media url Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel AddExternalUrl (int? entityId, ExeternalUrlFileModel urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = AddExternalUrlWithHttpInfo(entityId, urlFileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add external media url Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > AddExternalUrlWithHttpInfo (int? entityId, ExeternalUrlFileModel urlFileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityAddExternalUrl");
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling EntityApi->EntityAddExternalUrl");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:addexternalurl";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (urlFileModel != null && urlFileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(urlFileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = urlFileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityAddExternalUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add external media url Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> AddExternalUrlAsync (int? entityId, ExeternalUrlFileModel urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await AddExternalUrlAsyncWithHttpInfo(entityId, urlFileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add external media url Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> AddExternalUrlAsyncWithHttpInfo (int? entityId, ExeternalUrlFileModel urlFileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityAddExternalUrl");
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling EntityApi->EntityAddExternalUrl");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:addexternalurl";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (urlFileModel != null && urlFileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(urlFileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = urlFileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityAddExternalUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Entity comments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;CommentModel&gt;</returns>
        public List<CommentModel> Comments (int? entityId)
        {
             ApiResponse<List<CommentModel>> localVarResponse = CommentsWithHttpInfo(entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Entity comments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;CommentModel&gt;</returns>
        public ApiResponse< List<CommentModel> > CommentsWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityComments");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityComments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CommentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CommentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CommentModel>)));
        }

        /// <summary>
        /// Entity comments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;CommentModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<CommentModel>> CommentsAsync (int? entityId)
        {
             ApiResponse<List<CommentModel>> localVarResponse = await CommentsAsyncWithHttpInfo(entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Entity comments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;CommentModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<CommentModel>>> CommentsAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityComments");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityComments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CommentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CommentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CommentModel>)));
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;CompletenessDetailsModel&gt;</returns>
        public List<CompletenessDetailsModel> CompletenessDetails(int? entityId)
        {
             ApiResponse<List<CompletenessDetailsModel>> localVarResponse = CompletenessDetailsWithHttpInfo(entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;CompletenessDetailsModel&gt;</returns>
        public ApiResponse< List<CompletenessDetailsModel>> CompletenessDetailsWithHttpInfo(int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityCompletenessDetails");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/completenessdetails";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCompletenessDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CompletenessDetailsModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CompletenessDetailsModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CompletenessDetailsModel>)));
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;CompletenessDetailsModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<CompletenessDetailsModel>> CompletenessDetailsAsync (int? entityId)
        {
             ApiResponse<List<CompletenessDetailsModel>> localVarResponse = await CompletenessDetailsAsyncWithHttpInfo(entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;CompletenessDetailsModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<CompletenessDetailsModel>>> CompletenessDetailsAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityCompletenessDetails");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/completenessdetails";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCompletenessDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CompletenessDetailsModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CompletenessDetailsModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CompletenessDetailsModel>)));
        }

        /// <summary>
        /// Post entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>List&lt;CommentModel&gt;</returns>
        public List<CommentModel> CreateComment (int? entityId, CommentModel commentModel)
        {
             ApiResponse<List<CommentModel>> localVarResponse = CreateCommentWithHttpInfo(entityId, commentModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Post entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>ApiResponse of List&lt;CommentModel&gt;</returns>
        public ApiResponse< List<CommentModel> > CreateCommentWithHttpInfo (int? entityId, CommentModel commentModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityCreateComment");
            // verify the required parameter 'commentModel' is set
            if (commentModel == null)
                throw new ApiException(400, "Missing required parameter 'commentModel' when calling EntityApi->EntityCreateComment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (commentModel != null && commentModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(commentModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = commentModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCreateComment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CommentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CommentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CommentModel>)));
        }

        /// <summary>
        /// Post entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>Task of List&lt;CommentModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<CommentModel>> CreateCommentAsync (int? entityId, CommentModel commentModel)
        {
             ApiResponse<List<CommentModel>> localVarResponse = await CreateCommentAsyncWithHttpInfo(entityId, commentModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Post entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>Task of ApiResponse (List&lt;CommentModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<CommentModel>>> CreateCommentAsyncWithHttpInfo (int? entityId, CommentModel commentModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityCreateComment");
            // verify the required parameter 'commentModel' is set
            if (commentModel == null)
                throw new ApiException(400, "Missing required parameter 'commentModel' when calling EntityApi->EntityCreateComment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (commentModel != null && commentModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(commentModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = commentModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCreateComment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<CommentModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<CommentModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<CommentModel>)));
        }

        /// <summary>
        /// Create a new entity If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>EntitySummaryModel</returns>
        public EntitySummaryModel CreateEntity (EntityCreationModel entityCreationModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = CreateEntityWithHttpInfo(entityCreationModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new entity If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        public ApiResponse< EntitySummaryModel > CreateEntityWithHttpInfo (EntityCreationModel entityCreationModel)
        {
            // verify the required parameter 'entityCreationModel' is set
            if (entityCreationModel == null)
                throw new ApiException(400, "Missing required parameter 'entityCreationModel' when calling EntityApi->EntityCreateEntity");

            var localVarPath = "/api/v1.0.0/entities:createnew";
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

            if (entityCreationModel != null && entityCreationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(entityCreationModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = entityCreationModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCreateEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Create a new entity If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        public async System.Threading.Tasks.Task<EntitySummaryModel> CreateEntityAsync (EntityCreationModel entityCreationModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = await CreateEntityAsyncWithHttpInfo(entityCreationModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a new entity If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> CreateEntityAsyncWithHttpInfo (EntityCreationModel entityCreationModel)
        {
            // verify the required parameter 'entityCreationModel' is set
            if (entityCreationModel == null)
                throw new ApiException(400, "Missing required parameter 'entityCreationModel' when calling EntityApi->EntityCreateEntity");

            var localVarPath = "/api/v1.0.0/entities:createnew";
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

            if (entityCreationModel != null && entityCreationModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(entityCreationModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = entityCreationModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityCreateEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Delete entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public void DeleteComment (int? entityId, int? commentId)
        {
             DeleteCommentWithHttpInfo(entityId, commentId);
        }

        /// <summary>
        /// Delete entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteCommentWithHttpInfo (int? entityId, int? commentId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityDeleteComment");
            // verify the required parameter 'commentId' is set
            if (commentId == null)
                throw new ApiException(400, "Missing required parameter 'commentId' when calling EntityApi->EntityDeleteComment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments/{commentId}";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (commentId != null) localVarPathParams.Add("commentId", this.Configuration.ApiClient.ParameterToString(commentId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityDeleteComment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteCommentAsync (int? entityId, int? commentId)
        {
             await DeleteCommentAsyncWithHttpInfo(entityId, commentId);

        }

        /// <summary>
        /// Delete entity comment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteCommentAsyncWithHttpInfo (int? entityId, int? commentId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityDeleteComment");
            // verify the required parameter 'commentId' is set
            if (commentId == null)
                throw new ApiException(400, "Missing required parameter 'commentId' when calling EntityApi->EntityDeleteComment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/comments/{commentId}";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (commentId != null) localVarPathParams.Add("commentId", this.Configuration.ApiClient.ParameterToString(commentId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityDeleteComment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete an entity 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public void DeleteEntity (int? entityId)
        {
             DeleteEntityWithHttpInfo(entityId);
        }

        /// <summary>
        /// Delete an entity 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteEntityWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityDeleteEntity");

            var localVarPath = "/api/v1.0.0/entities/{entityId}";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityDeleteEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete an entity 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteEntityAsync (int? entityId)
        {
             await DeleteEntityAsyncWithHttpInfo(entityId);

        }

        /// <summary>
        /// Delete an entity 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteEntityAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityDeleteEntity");

            var localVarPath = "/api/v1.0.0/entities/{entityId}";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityDeleteEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Returns various types of entity data Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityObjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityObjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchObjectsModel"></param>
        /// <returns>List&lt;EntityDataModel&gt;</returns>
        public List<EntityDataModel> FetchData (FetchObjectsModel fetchObjectsModel)
        {
             ApiResponse<List<EntityDataModel>> localVarResponse = FetchDataWithHttpInfo(fetchObjectsModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns various types of entity data Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityObjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityObjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchObjectsModel"></param>
        /// <returns>ApiResponse of List&lt;EntityDataModel&gt;</returns>
        public ApiResponse< List<EntityDataModel> > FetchDataWithHttpInfo (FetchObjectsModel fetchObjectsModel)
        {
            // verify the required parameter 'fetchObjectsModel' is set
            if (fetchObjectsModel == null)
                throw new ApiException(400, "Missing required parameter 'fetchObjectsModel' when calling EntityApi->EntityFetchData");

            var localVarPath = "/api/v1.0.1/entities:fetchdata";
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

            if (fetchObjectsModel != null && fetchObjectsModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(fetchObjectsModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = fetchObjectsModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityFetchData", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<EntityDataModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<EntityDataModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<EntityDataModel>)));
        }

        /// <summary>
        /// Returns various types of entity data Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityObjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityObjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchObjectsModel"></param>
        /// <returns>Task of List&lt;EntityDataModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<EntityDataModel>> FetchDataAsync (FetchObjectsModel fetchObjectsModel)
        {
             ApiResponse<List<EntityDataModel>> localVarResponse = await FetchDataAsyncWithHttpInfo(fetchObjectsModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns various types of entity data Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityObjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityObjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchObjectsModel"></param>
        /// <returns>Task of ApiResponse (List&lt;EntityDataModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<EntityDataModel>>> FetchDataAsyncWithHttpInfo (FetchObjectsModel fetchObjectsModel)
        {
            // verify the required parameter 'fetchObjectsModel' is set
            if (fetchObjectsModel == null)
                throw new ApiException(400, "Missing required parameter 'fetchObjectsModel' when calling EntityApi->EntityFetchData");

            var localVarPath = "/api/v1.0.1/entities:fetchdata";
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

            if (fetchObjectsModel != null && fetchObjectsModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(fetchObjectsModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = fetchObjectsModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityFetchData", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<EntityDataModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<EntityDataModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<EntityDataModel>)));
        }

        /// <summary>
        /// Field value revisions 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>FieldRevisionModel</returns>
        public FieldRevisionModel[] FieldHistory(int? entityId, string fieldTypeId)
        {
             ApiResponse<FieldRevisionModel[]> localVarResponse = FieldHistoryWithHttpInfo(entityId, fieldTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Field value revisions 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>ApiResponse of FieldRevisionModel</returns>
        public ApiResponse<FieldRevisionModel[]> FieldHistoryWithHttpInfo(int? entityId, string fieldTypeId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->FieldRevisionModel");
            // verify the required parameter 'fieldTypeId' is set
            if (fieldTypeId == null)
                throw new ApiException(400, "Missing required parameter 'fieldTypeId' when calling EntityApi->FieldRevisionModel");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues/{fieldTypeId}/revisions";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeId != null) localVarPathParams.Add("fieldTypeId", this.Configuration.ApiClient.ParameterToString(fieldTypeId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityFieldHistory", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<FieldRevisionModel[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FieldRevisionModel[]) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(FieldRevisionModel[])));
        }

        /// <summary>
        /// Field value revisions 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>Task of FieldRevisionModel</returns>
        public async System.Threading.Tasks.Task<FieldRevisionModel[]> FieldHistoryAsync (int? entityId, string fieldTypeId)
        {
             ApiResponse<FieldRevisionModel[]> localVarResponse = await FieldHistoryAsyncWithHttpInfo(entityId, fieldTypeId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Field value revisions 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>Task of ApiResponse (FieldRevisionModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FieldRevisionModel[]>> FieldHistoryAsyncWithHttpInfo (int? entityId, string fieldTypeId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityFieldHistory");
            // verify the required parameter 'fieldTypeId' is set
            if (fieldTypeId == null)
                throw new ApiException(400, "Missing required parameter 'fieldTypeId' when calling EntityApi->EntityFieldHistory");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues/{fieldTypeId}/revisions";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeId != null) localVarPathParams.Add("fieldTypeId", this.Configuration.ApiClient.ParameterToString(fieldTypeId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityFieldHistory", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<FieldRevisionModel[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FieldRevisionModel[]) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(FieldRevisionModel[])));
        }

        /// <summary>
        /// Returns a read only list of entity media 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;MediaInfoModel&gt;</returns>
        public List<MediaInfoModel> GetAllMedia (int? entityId)
        {
             ApiResponse<List<MediaInfoModel>> localVarResponse = GetAllMediaWithHttpInfo(entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only list of entity media 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;MediaInfoModel&gt;</returns>
        public ApiResponse< List<MediaInfoModel> > GetAllMediaWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetAllMedia");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetAllMedia", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MediaInfoModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<MediaInfoModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MediaInfoModel>)));
        }

        /// <summary>
        /// Returns a read only list of entity media 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;MediaInfoModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<MediaInfoModel>> GetAllMediaAsync (int? entityId)
        {
             ApiResponse<List<MediaInfoModel>> localVarResponse = await GetAllMediaAsyncWithHttpInfo(entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only list of entity media 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;MediaInfoModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<MediaInfoModel>>> GetAllMediaAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetAllMedia");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetAllMedia", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MediaInfoModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<MediaInfoModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MediaInfoModel>)));
        }

        /// <summary>
        /// Get All Segments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Segment&gt;</returns>
        public List<Segment> GetAllSegments ()
        {
             ApiResponse<List<Segment>> localVarResponse = AllSegmentsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get All Segments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Segment&gt;</returns>
        public ApiResponse< List<Segment> > AllSegmentsWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/entities/segments";
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
                Exception exception = ExceptionFactory("EntityGetAllSegments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Segment>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Segment>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Segment>)));
        }

        /// <summary>
        /// Get All Segments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Segment&gt;</returns>
        public async System.Threading.Tasks.Task<List<Segment>> GetAllSegmentsAsync ()
        {
             ApiResponse<List<Segment>> localVarResponse = await GetAllSegmentsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get All Segments 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Segment&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Segment>>> GetAllSegmentsAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/entities/segments";
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
                Exception exception = ExceptionFactory("EntityGetAllSegments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Segment>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Segment>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Segment>)));
        }

        /// <summary>
        /// Returns an entity creation model The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>EntityCreationModel</returns>
        public EntityCreationModel GetEmptyEntity (string entityTypeId, string fieldSetId = null, bool? allFields = null)
        {
             ApiResponse<EntityCreationModel> localVarResponse = GetEmptyEntityWithHttpInfo(entityTypeId, fieldSetId, allFields);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns an entity creation model The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>ApiResponse of EntityCreationModel</returns>
        public ApiResponse< EntityCreationModel > GetEmptyEntityWithHttpInfo (string entityTypeId, string fieldSetId = null, bool? allFields = null)
        {
            // verify the required parameter 'entityTypeId' is set
            if (entityTypeId == null)
                throw new ApiException(400, "Missing required parameter 'entityTypeId' when calling EntityApi->EntityGetEmptyEntity");

            var localVarPath = "/api/v1.0.0/entities:getempty";
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

            if (entityTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId)); // query parameter
            if (fieldSetId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldSetId", fieldSetId)); // query parameter
            if (allFields != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "allFields", allFields)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEmptyEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityCreationModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityCreationModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityCreationModel)));
        }

        /// <summary>
        /// Returns an entity creation model The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>Task of EntityCreationModel</returns>
        public async System.Threading.Tasks.Task<EntityCreationModel> GetEmptyEntityAsync (string entityTypeId, string fieldSetId = null, bool? allFields = null)
        {
             ApiResponse<EntityCreationModel> localVarResponse = await GetEmptyEntityAsyncWithHttpInfo(entityTypeId, fieldSetId, allFields);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns an entity creation model The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>Task of ApiResponse (EntityCreationModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityCreationModel>> GetEmptyEntityAsyncWithHttpInfo (string entityTypeId, string fieldSetId = null, bool? allFields = null)
        {
            // verify the required parameter 'entityTypeId' is set
            if (entityTypeId == null)
                throw new ApiException(400, "Missing required parameter 'entityTypeId' when calling EntityApi->EntityGetEmptyEntity");

            var localVarPath = "/api/v1.0.0/entities:getempty";
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

            if (entityTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entityTypeId", entityTypeId)); // query parameter
            if (fieldSetId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldSetId", fieldSetId)); // query parameter
            if (allFields != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "allFields", allFields)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEmptyEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityCreationModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityCreationModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityCreationModel)));
        }

        /// <summary>
        /// Returns a bundle of the entity and all linked entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>EntityBundleModel</returns>
        public EntityBundleModel GetEntityBundle (int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null)
        {
             ApiResponse<EntityBundleModel> localVarResponse = GetEntityBundleWithHttpInfo(entityId, fieldTypeIds, linkDirection, linkTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a bundle of the entity and all linked entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of EntityBundleModel</returns>
        public ApiResponse< EntityBundleModel > GetEntityBundleWithHttpInfo (int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetEntityBundle");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/linksandfields";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter
            if (linkDirection != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkDirection", linkDirection)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEntityBundle", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityBundleModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityBundleModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityBundleModel)));
        }

        /// <summary>
        /// Returns a bundle of the entity and all linked entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of EntityBundleModel</returns>
        public async System.Threading.Tasks.Task<EntityBundleModel> GetEntityBundleAsync (int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null)
        {
             ApiResponse<EntityBundleModel> localVarResponse = await GetEntityBundleAsyncWithHttpInfo(entityId, fieldTypeIds, linkDirection, linkTypeId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a bundle of the entity and all linked entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (EntityBundleModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityBundleModel>> GetEntityBundleAsyncWithHttpInfo (int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetEntityBundle");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/linksandfields";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter
            if (linkDirection != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkDirection", linkDirection)); // query parameter
            if (linkTypeId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "linkTypeId", linkTypeId)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEntityBundle", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityBundleModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityBundleModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityBundleModel)));
        }

        /// <summary>
        /// Returns a read only entity summary 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>EntitySummaryModel</returns>
        public EntitySummaryModel GetEntitySummary (int? entityId)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = GetEntitySummaryWithHttpInfo(entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only entity summary 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        public ApiResponse< EntitySummaryModel > GetEntitySummaryWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetEntitySummary");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEntitySummary", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Returns a read only entity summary 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        public async System.Threading.Tasks.Task<EntitySummaryModel> GetEntitySummaryAsync (int? entityId)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = await GetEntitySummaryAsyncWithHttpInfo(entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only entity summary 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> GetEntitySummaryAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetEntitySummary");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetEntitySummary", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Returns a list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;FieldValueModel&gt;</returns>
        public List<FieldValueModel> GetFieldValues (int? entityId, string fieldTypeIds = null)
        {
             ApiResponse<List<FieldValueModel>> localVarResponse = GetFieldValuesWithHttpInfo(entityId, fieldTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;FieldValueModel&gt;</returns>
        public ApiResponse< List<FieldValueModel> > GetFieldValuesWithHttpInfo (int? entityId, string fieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetFieldValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetFieldValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldValueModel>)));
        }

        /// <summary>
        /// Returns a list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;FieldValueModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<FieldValueModel>> GetFieldValuesAsync (int? entityId, string fieldTypeIds = null)
        {
             ApiResponse<List<FieldValueModel>> localVarResponse = await GetFieldValuesAsyncWithHttpInfo(entityId, fieldTypeIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FieldValueModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FieldValueModel>>> GetFieldValuesAsyncWithHttpInfo (int? entityId, string fieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetFieldValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetFieldValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldValueModel>)));
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;FieldSummaryModel&gt;</returns>
        public List<FieldSummaryModel> GetFields (int? entityId, string fieldTypeIds = null)
        {
             ApiResponse<List<FieldSummaryModel>> localVarResponse = GetFieldsWithHttpInfo(entityId, fieldTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;FieldSummaryModel&gt;</returns>
        public ApiResponse< List<FieldSummaryModel> > GetFieldsWithHttpInfo (int? entityId, string fieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetFields");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary/fields";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetFields", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldSummaryModel>)));
        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;FieldSummaryModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<FieldSummaryModel>> GetFieldsAsync (int? entityId, string fieldTypeIds = null)
        {
             ApiResponse<List<FieldSummaryModel>> localVarResponse = await GetFieldsAsyncWithHttpInfo(entityId, fieldTypeIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only list of field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FieldSummaryModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FieldSummaryModel>>> GetFieldsAsyncWithHttpInfo (int? entityId, string fieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetFields");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary/fields";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "fieldTypeIds", fieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetFields", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldSummaryModel>)));
        }

        /// <summary>
        /// Returns a list of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>List&lt;LinkModel&gt;</returns>
        public List<LinkModel> GetLinksForEntity (int? entityId, string linkDirection = null, string linkTypeId = null)
        {
             ApiResponse<List<LinkModel>> localVarResponse = GetLinksForEntityWithHttpInfo(entityId, linkDirection, linkTypeId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a list of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of List&lt;LinkModel&gt;</returns>
        public ApiResponse< List<LinkModel> > GetLinksForEntityWithHttpInfo (int? entityId, string linkDirection = null, string linkTypeId = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetLinksForEntity");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/links";
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
                Exception exception = ExceptionFactory("EntityGetLinksForEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<LinkModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

        /// <summary>
        /// Returns a list of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of List&lt;LinkModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<LinkModel>> GetLinksForEntityAsync (int? entityId, string linkDirection = null, string linkTypeId = null)
        {
             ApiResponse<List<LinkModel>> localVarResponse = await GetLinksForEntityAsyncWithHttpInfo(entityId, linkDirection, linkTypeId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a list of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;LinkModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<LinkModel>>> GetLinksForEntityAsyncWithHttpInfo (int? entityId, string linkDirection = null, string linkTypeId = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetLinksForEntity");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/links";
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
                Exception exception = ExceptionFactory("EntityGetLinksForEntity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<LinkModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

        /// <summary>
        /// Returns a read only list of entity media details 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;MediaInfoModel&gt;</returns>
        public List<MediaInfoModel> GetMediaDetails (int? entityId)
        {
             ApiResponse<List<MediaInfoModel>> localVarResponse = GetMediaDetailsWithHttpInfo(entityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only list of entity media details 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;MediaInfoModel&gt;</returns>
        public ApiResponse< List<MediaInfoModel> > GetMediaDetailsWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetMediaDetails");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/mediadetails";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetMediaDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MediaInfoModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<MediaInfoModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MediaInfoModel>)));
        }

        /// <summary>
        /// Returns a read only list of entity media details 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;MediaInfoModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<MediaInfoModel>> GetMediaDetailsAsync (int? entityId)
        {
             ApiResponse<List<MediaInfoModel>> localVarResponse = await EntityGetMediaDetailsAsyncWithHttpInfo(entityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only list of entity media details 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;MediaInfoModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<MediaInfoModel>>> EntityGetMediaDetailsAsyncWithHttpInfo (int? entityId)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetMediaDetails");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/mediadetails";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetMediaDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MediaInfoModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<MediaInfoModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MediaInfoModel>)));
        }

        /// <summary>
        /// Returns a read only list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;SpecificationValueSummaryModel&gt;</returns>
        public List<SpecificationValueSummaryModel> GetSpecificationSummary (int? entityId, string specificationFieldTypeIds = null)
        {
             ApiResponse<List<SpecificationValueSummaryModel>> localVarResponse = GetSpecificationSummaryWithHttpInfo(entityId, specificationFieldTypeIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a read only list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;SpecificationValueSummaryModel&gt;</returns>
        public ApiResponse< List<SpecificationValueSummaryModel> > GetSpecificationSummaryWithHttpInfo (int? entityId, string specificationFieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetSpecificationSummary");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary/specification";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationFieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "specificationFieldTypeIds", specificationFieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetSpecificationSummary", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueSummaryModel>)));
        }

        /// <summary>
        /// Returns a read only list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;SpecificationValueSummaryModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SpecificationValueSummaryModel>> GetSpecificationSummaryAsync (int? entityId, string specificationFieldTypeIds = null)
        {
             ApiResponse<List<SpecificationValueSummaryModel>> localVarResponse = await GetSpecificationSummaryAsyncWithHttpInfo(entityId, specificationFieldTypeIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a read only list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueSummaryModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueSummaryModel>>> GetSpecificationSummaryAsyncWithHttpInfo (int? entityId, string specificationFieldTypeIds = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetSpecificationSummary");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/summary/specification";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationFieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "specificationFieldTypeIds", specificationFieldTypeIds)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetSpecificationSummary", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueSummaryModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueSummaryModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueSummaryModel>)));
        }

        /// <summary>
        /// Returns a list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>List&lt;SpecificationValueModel&gt;</returns>
        public List<SpecificationValueModel> GetSpecificationValues (int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null)
        {
             ApiResponse<List<SpecificationValueModel>> localVarResponse = GetSpecificationValuesWithHttpInfo(entityId, specificationFieldTypeIds, mandatoryOnly);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;SpecificationValueModel&gt;</returns>
        public ApiResponse< List<SpecificationValueModel> > GetSpecificationValuesWithHttpInfo (int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetSpecificationValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationFieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "specificationFieldTypeIds", specificationFieldTypeIds)); // query parameter
            if (mandatoryOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "mandatoryOnly", mandatoryOnly)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetSpecificationValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueModel>)));
        }

        /// <summary>
        /// Returns a list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>Task of List&lt;SpecificationValueModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SpecificationValueModel>> GetSpecificationValuesAsync (int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null)
        {
             ApiResponse<List<SpecificationValueModel>> localVarResponse = await GetSpecificationValuesAsyncWithHttpInfo(entityId, specificationFieldTypeIds, mandatoryOnly);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a list of specification field values 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueModel>>> GetSpecificationValuesAsyncWithHttpInfo (int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityGetSpecificationValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationFieldTypeIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "specificationFieldTypeIds", specificationFieldTypeIds)); // query parameter
            if (mandatoryOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "mandatoryOnly", mandatoryOnly)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityGetSpecificationValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueModel>)));
        }

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Dictionary&lt;string, int?&gt;</returns>
        public Dictionary<string, int?> MapUniqueValues (MapUniqueValuesModel mapUniqueValuesModel)
        {
             ApiResponse<Dictionary<string, int?>> localVarResponse = MapUniqueValuesWithHttpInfo(mapUniqueValuesModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, int?&gt;</returns>
        public ApiResponse< Dictionary<string, int?> > MapUniqueValuesWithHttpInfo (MapUniqueValuesModel mapUniqueValuesModel)
        {
            // verify the required parameter 'mapUniqueValuesModel' is set
            if (mapUniqueValuesModel == null)
                throw new ApiException(400, "Missing required parameter 'mapUniqueValuesModel' when calling EntityApi->EntityMapUniqueValues");

            var localVarPath = "/api/v1.0.0/entities:mapuniquevalues";
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

            if (mapUniqueValuesModel != null && mapUniqueValuesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(mapUniqueValuesModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = mapUniqueValuesModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityMapUniqueValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, int?>)));
        }

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Task of Dictionary&lt;string, int?&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, int?>> MapUniqueValuesAsync (MapUniqueValuesModel mapUniqueValuesModel)
        {
             ApiResponse<Dictionary<string, int?>> localVarResponse = await MapUniqueValuesAsyncWithHttpInfo(mapUniqueValuesModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, int?>>> MapUniqueValuesAsyncWithHttpInfo (MapUniqueValuesModel mapUniqueValuesModel)
        {
            // verify the required parameter 'mapUniqueValuesModel' is set
            if (mapUniqueValuesModel == null)
                throw new ApiException(400, "Missing required parameter 'mapUniqueValuesModel' when calling EntityApi->EntityMapUniqueValues");

            var localVarPath = "/api/v1.0.0/entities:mapuniquevalues";
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

            if (mapUniqueValuesModel != null && mapUniqueValuesModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(mapUniqueValuesModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = mapUniqueValuesModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityMapUniqueValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Dictionary<string, int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, int?>)));
        }

        /// <summary>
        /// Set field set Set fieldSetId to null to remove the field set
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>EntitySummaryModel</returns>
        public EntitySummaryModel SetFieldSet (int? entityId, SetFieldSetModel setFieldSetModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = SetFieldSetWithHttpInfo(entityId, setFieldSetModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set field set Set fieldSetId to null to remove the field set
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        public ApiResponse< EntitySummaryModel > SetFieldSetWithHttpInfo (int? entityId, SetFieldSetModel setFieldSetModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetFieldSet");
            // verify the required parameter 'setFieldSetModel' is set
            if (setFieldSetModel == null)
                throw new ApiException(400, "Missing required parameter 'setFieldSetModel' when calling EntityApi->EntitySetFieldSet");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldset";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setFieldSetModel != null && setFieldSetModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setFieldSetModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setFieldSetModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetFieldSet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Set field set Set fieldSetId to null to remove the field set
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        public async System.Threading.Tasks.Task<EntitySummaryModel> SetFieldSetAsync (int? entityId, SetFieldSetModel setFieldSetModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = await SetFieldSetAsyncWithHttpInfo(entityId, setFieldSetModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Set field set Set fieldSetId to null to remove the field set
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetFieldSetAsyncWithHttpInfo (int? entityId, SetFieldSetModel setFieldSetModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetFieldSet");
            // verify the required parameter 'setFieldSetModel' is set
            if (setFieldSetModel == null)
                throw new ApiException(400, "Missing required parameter 'setFieldSetModel' when calling EntityApi->EntitySetFieldSet");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldset";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setFieldSetModel != null && setFieldSetModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setFieldSetModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setFieldSetModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetFieldSet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Update field values The list may be an subset of available field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>List&lt;FieldValueModel&gt;</returns>
        public List<FieldValueModel> SetFieldValues (int? entityId, List<FieldValueModel> fieldValueModels)
        {
             ApiResponse<List<FieldValueModel>> localVarResponse = SetFieldValuesWithHttpInfo(entityId, fieldValueModels);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update field values The list may be an subset of available field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>ApiResponse of List&lt;FieldValueModel&gt;</returns>
        public ApiResponse< List<FieldValueModel> > SetFieldValuesWithHttpInfo (int? entityId, List<FieldValueModel> fieldValueModels)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetFieldValues");
            // verify the required parameter 'fieldValueModels' is set
            if (fieldValueModels == null)
                throw new ApiException(400, "Missing required parameter 'fieldValueModels' when calling EntityApi->EntitySetFieldValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldValueModels != null && fieldValueModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(fieldValueModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = fieldValueModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetFieldValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldValueModel>)));
        }

        /// <summary>
        /// Update field values The list may be an subset of available field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>Task of List&lt;FieldValueModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<FieldValueModel>> SetFieldValuesAsync (int? entityId, List<FieldValueModel> fieldValueModels)
        {
             ApiResponse<List<FieldValueModel>> localVarResponse = await SetFieldValuesAsyncWithHttpInfo(entityId, fieldValueModels);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update field values The list may be an subset of available field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>Task of ApiResponse (List&lt;FieldValueModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FieldValueModel>>> SetFieldValuesAsyncWithHttpInfo (int? entityId, List<FieldValueModel> fieldValueModels)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetFieldValues");
            // verify the required parameter 'fieldValueModels' is set
            if (fieldValueModels == null)
                throw new ApiException(400, "Missing required parameter 'fieldValueModels' when calling EntityApi->EntitySetFieldValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/fieldvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (fieldValueModels != null && fieldValueModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(fieldValueModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = fieldValueModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetFieldValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<FieldValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FieldValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FieldValueModel>)));
        }

        /// <summary>
        /// Set entity segment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>EntitySummaryModel</returns>
        public EntitySummaryModel SetSegment (int? entityId, SetSegmentModel setSegmentModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = SetSegmentWithHttpInfo(entityId, setSegmentModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set entity segment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        public ApiResponse< EntitySummaryModel > SetSegmentWithHttpInfo (int? entityId, SetSegmentModel setSegmentModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetSegment");
            // verify the required parameter 'setSegmentModel' is set
            if (setSegmentModel == null)
                throw new ApiException(400, "Missing required parameter 'setSegmentModel' when calling EntityApi->EntitySetSegment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/segment";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setSegmentModel != null && setSegmentModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setSegmentModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setSegmentModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Set entity segment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        public async System.Threading.Tasks.Task<EntitySummaryModel> SetSegmentAsync (int? entityId, SetSegmentModel setSegmentModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = await SetSegmentAsyncWithHttpInfo(entityId, setSegmentModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Set entity segment 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetSegmentAsyncWithHttpInfo (int? entityId, SetSegmentModel setSegmentModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetSegment");
            // verify the required parameter 'setSegmentModel' is set
            if (setSegmentModel == null)
                throw new ApiException(400, "Missing required parameter 'setSegmentModel' when calling EntityApi->EntitySetSegment");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/segment";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setSegmentModel != null && setSegmentModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setSegmentModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setSegmentModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetSegment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Set specification template Set SpecificationId to null for removing specification template
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>EntitySummaryModel</returns>
        public EntitySummaryModel SetSpecificationTemplate (int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = SetSpecificationTemplateWithHttpInfo(entityId, setSpecificationTemplateModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set specification template Set SpecificationId to null for removing specification template
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        public ApiResponse< EntitySummaryModel > SetSpecificationTemplateWithHttpInfo (int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetSpecificationTemplate");
            // verify the required parameter 'setSpecificationTemplateModel' is set
            if (setSpecificationTemplateModel == null)
                throw new ApiException(400, "Missing required parameter 'setSpecificationTemplateModel' when calling EntityApi->EntitySetSpecificationTemplate");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationtemplate";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setSpecificationTemplateModel != null && setSpecificationTemplateModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setSpecificationTemplateModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setSpecificationTemplateModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetSpecificationTemplate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Set specification template Set SpecificationId to null for removing specification template
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        public async System.Threading.Tasks.Task<EntitySummaryModel> SetSpecificationTemplateAsync (int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel)
        {
             ApiResponse<EntitySummaryModel> localVarResponse = await SetSpecificationTemplateAsyncWithHttpInfo(entityId, setSpecificationTemplateModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Set specification template Set SpecificationId to null for removing specification template
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetSpecificationTemplateAsyncWithHttpInfo (int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntitySetSpecificationTemplate");
            // verify the required parameter 'setSpecificationTemplateModel' is set
            if (setSpecificationTemplateModel == null)
                throw new ApiException(400, "Missing required parameter 'setSpecificationTemplateModel' when calling EntityApi->EntitySetSpecificationTemplate");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationtemplate";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (setSpecificationTemplateModel != null && setSpecificationTemplateModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(setSpecificationTemplateModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = setSpecificationTemplateModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntitySetSpecificationTemplate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntitySummaryModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntitySummaryModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntitySummaryModel)));
        }

        /// <summary>
        /// Get list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> StarredEntities ()
        {
             ApiResponse<List<int?>> localVarResponse = StarredEntitiesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse< List<int?> > StarredEntitiesWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/entities/starred";
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
                Exception exception = ExceptionFactory("EntityStarredEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Get list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> StarredEntitiesAsync ()
        {
             ApiResponse<List<int?>> localVarResponse = await StarredEntitiesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> StarredEntitiesAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/v1.0.0/entities/starred";
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
                Exception exception = ExceptionFactory("EntityStarredEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Update specification field values The list may be an subset of available specification field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>List&lt;SpecificationValueModel&gt;</returns>
        public List<SpecificationValueModel> UpdateSpecificationValues (int? entityId, List<SpecificationValueModel> specificationValueModels)
        {
             ApiResponse<List<SpecificationValueModel>> localVarResponse = UpdateSpecificationValuesWithHttpInfo(entityId, specificationValueModels);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update specification field values The list may be an subset of available specification field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>ApiResponse of List&lt;SpecificationValueModel&gt;</returns>
        public ApiResponse< List<SpecificationValueModel> > UpdateSpecificationValuesWithHttpInfo (int? entityId, List<SpecificationValueModel> specificationValueModels)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUpdateSpecificationValues");
            // verify the required parameter 'specificationValueModels' is set
            if (specificationValueModels == null)
                throw new ApiException(400, "Missing required parameter 'specificationValueModels' when calling EntityApi->EntityUpdateSpecificationValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationValueModels != null && specificationValueModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(specificationValueModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = specificationValueModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUpdateSpecificationValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueModel>)));
        }

        /// <summary>
        /// Update specification field values The list may be an subset of available specification field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>Task of List&lt;SpecificationValueModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<SpecificationValueModel>> UpdateSpecificationValuesAsync (int? entityId, List<SpecificationValueModel> specificationValueModels)
        {
             ApiResponse<List<SpecificationValueModel>> localVarResponse = await UpdateSpecificationValuesAsyncWithHttpInfo(entityId, specificationValueModels);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update specification field values The list may be an subset of available specification field values
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueModel>>> UpdateSpecificationValuesAsyncWithHttpInfo (int? entityId, List<SpecificationValueModel> specificationValueModels)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUpdateSpecificationValues");
            // verify the required parameter 'specificationValueModels' is set
            if (specificationValueModels == null)
                throw new ApiException(400, "Missing required parameter 'specificationValueModels' when calling EntityApi->EntityUpdateSpecificationValues");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/specificationvalues";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (specificationValueModels != null && specificationValueModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(specificationValueModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = specificationValueModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUpdateSpecificationValues", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<SpecificationValueModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SpecificationValueModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<SpecificationValueModel>)));
        }

        /// <summary>
        /// Update list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>List&lt;int?&gt;</returns>
        public List<int?> UpdateStarredEntities (List<int?> entityIds)
        {
             ApiResponse<List<int?>> localVarResponse = UpdateStarredEntitiesWithHttpInfo(entityIds);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        public ApiResponse< List<int?> > UpdateStarredEntitiesWithHttpInfo (List<int?> entityIds)
        {
            // verify the required parameter 'entityIds' is set
            if (entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling EntityApi->EntityUpdateStarredEntities");

            var localVarPath = "/api/v1.0.0/entities/starred";
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
                Exception exception = ExceptionFactory("EntityUpdateStarredEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Update list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        public async System.Threading.Tasks.Task<List<int?>> UpdateStarredEntitiesAsync (List<int?> entityIds)
        {
             ApiResponse<List<int?>> localVarResponse = await UpdateStarredEntitiesAsyncWithHttpInfo(entityIds);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update list of starred entities 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<int?>>> UpdateStarredEntitiesAsyncWithHttpInfo (List<int?> entityIds)
        {
            // verify the required parameter 'entityIds' is set
            if (entityIds == null)
                throw new ApiException(400, "Missing required parameter 'entityIds' when calling EntityApi->EntityUpdateStarredEntities");

            var localVarPath = "/api/v1.0.0/entities/starred";
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
                Exception exception = ExceptionFactory("EntityUpdateStarredEntities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<int?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<int?>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<int?>)));
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel UploadBase64File (int? entityId, Base64FileModel base64FileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = UploadBase64FileWithHttpInfo(entityId, base64FileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > UploadBase64FileWithHttpInfo (int? entityId, Base64FileModel base64FileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUploadBase64File");
            // verify the required parameter 'base64FileModel' is set
            if (base64FileModel == null)
                throw new ApiException(400, "Missing required parameter 'base64FileModel' when calling EntityApi->EntityUploadBase64File");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:uploadbase64";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (base64FileModel != null && base64FileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(base64FileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = base64FileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUploadBase64File", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> UploadBase64FileAsync (int? entityId, Base64FileModel base64FileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await UploadBase64FileAsyncWithHttpInfo(entityId, base64FileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add Media Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadBase64FileAsyncWithHttpInfo (int? entityId, Base64FileModel base64FileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUploadBase64File");
            // verify the required parameter 'base64FileModel' is set
            if (base64FileModel == null)
                throw new ApiException(400, "Missing required parameter 'base64FileModel' when calling EntityApi->EntityUploadBase64File");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:uploadbase64";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (base64FileModel != null && base64FileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(base64FileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = base64FileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUploadBase64File", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel UploadMediaFromUrl (int? entityId, UrlFileModel urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = EntityUploadMediaFromUrlWithHttpInfo(entityId, urlFileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add Media Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > EntityUploadMediaFromUrlWithHttpInfo (int? entityId, UrlFileModel urlFileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUploadMediaFromUrl");
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling EntityApi->EntityUploadMediaFromUrl");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:uploadfromurl";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (urlFileModel != null && urlFileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(urlFileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = urlFileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUploadMediaFromUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> UploadMediaFromUrlAsync (int? entityId, UrlFileModel urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await UploadMediaFromUrlAsyncWithHttpInfo(entityId, urlFileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add Media Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadMediaFromUrlAsyncWithHttpInfo (int? entityId, UrlFileModel urlFileModel)
        {
            // verify the required parameter 'entityId' is set
            if (entityId == null)
                throw new ApiException(400, "Missing required parameter 'entityId' when calling EntityApi->EntityUploadMediaFromUrl");
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling EntityApi->EntityUploadMediaFromUrl");

            var localVarPath = "/api/v1.0.0/entities/{entityId}/media:uploadfromurl";
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

            if (entityId != null) localVarPathParams.Add("entityId", this.Configuration.ApiClient.ParameterToString(entityId)); // path parameter
            if (urlFileModel != null && urlFileModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(urlFileModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = urlFileModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("EntityUploadMediaFromUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

    }
}
