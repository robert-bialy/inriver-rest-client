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
    internal class MediaApi : IMediaApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MediaApi(Configuration configuration = null)
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
        /// Add external media url If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel AddExternalUrl (ExternalUrlFileModelWithLink urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = AddExternalUrlWithHttpInfo(urlFileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add external media url If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > AddExternalUrlWithHttpInfo (ExternalUrlFileModelWithLink urlFileModel)
        {
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling MediaApi->MediaAddExternalUrl");

            var localVarPath = "/api/v1.0.0/media:addexternalurl";
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
                Exception exception = ExceptionFactory("MediaAddExternalUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add external media url If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> AddExternalUrlAsync (ExternalUrlFileModelWithLink urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await AddExternalUrlAsyncWithHttpInfo(urlFileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add external media url If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> AddExternalUrlAsyncWithHttpInfo (ExternalUrlFileModelWithLink urlFileModel)
        {
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling MediaApi->MediaAddExternalUrl");

            var localVarPath = "/api/v1.0.0/media:addexternalurl";
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
                Exception exception = ExceptionFactory("MediaAddExternalUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel UploadBase64File (Base64FileModelWithLink base64FileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = UploadBase64FileWithHttpInfo(base64FileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > UploadBase64FileWithHttpInfo (Base64FileModelWithLink base64FileModel)
        {
            // verify the required parameter 'base64FileModel' is set
            if (base64FileModel == null)
                throw new ApiException(400, "Missing required parameter 'base64FileModel' when calling MediaApi->MediaUploadBase64File");

            var localVarPath = "/api/v1.0.0/media:uploadbase64";
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
                Exception exception = ExceptionFactory("MediaUploadBase64File", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> UploadBase64FileAsync (Base64FileModelWithLink base64FileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await UploadBase64FileAsyncWithHttpInfo(base64FileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add Media Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadBase64FileAsyncWithHttpInfo (Base64FileModelWithLink base64FileModel)
        {
            // verify the required parameter 'base64FileModel' is set
            if (base64FileModel == null)
                throw new ApiException(400, "Missing required parameter 'base64FileModel' when calling MediaApi->MediaUploadBase64File");

            var localVarPath = "/api/v1.0.0/media:uploadbase64";
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
                Exception exception = ExceptionFactory("MediaUploadBase64File", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        public MediaInfoModel UploadMediaFromUrl (UrlFileModelWithLink urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = UploadMediaFromUrlWithHttpInfo(urlFileModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add Media Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        public ApiResponse< MediaInfoModel > UploadMediaFromUrlWithHttpInfo (UrlFileModelWithLink urlFileModel)
        {
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling MediaApi->MediaUploadMediaFromUrl");

            var localVarPath = "/api/v1.0.0/media:uploadfromurl";
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
                Exception exception = ExceptionFactory("MediaUploadMediaFromUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

        /// <summary>
        /// Add Media Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        public async System.Threading.Tasks.Task<MediaInfoModel> UploadMediaFromUrlAsync (UrlFileModelWithLink urlFileModel)
        {
             ApiResponse<MediaInfoModel> localVarResponse = await UploadMediaFromUrlAsyncWithHttpInfo(urlFileModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add Media Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadMediaFromUrlAsyncWithHttpInfo (UrlFileModelWithLink urlFileModel)
        {
            // verify the required parameter 'urlFileModel' is set
            if (urlFileModel == null)
                throw new ApiException(400, "Missing required parameter 'urlFileModel' when calling MediaApi->MediaUploadMediaFromUrl");

            var localVarPath = "/api/v1.0.0/media:uploadfromurl";
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
                Exception exception = ExceptionFactory("MediaUploadMediaFromUrl", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MediaInfoModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MediaInfoModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MediaInfoModel)));
        }

    }
}
