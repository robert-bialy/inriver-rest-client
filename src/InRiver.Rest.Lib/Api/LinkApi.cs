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
    internal sealed class LinkApi : ILinkApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LinkApi(Configuration configuration = null)
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
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>LinkModel</returns>
        public LinkModel CreateLink (LinkModel linkModel)
        {
             ApiResponse<LinkModel> localVarResponse = CreateLinkWithHttpInfo(linkModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        public ApiResponse< LinkModel > CreateLinkWithHttpInfo (LinkModel linkModel)
        {
            // verify the required parameter 'linkModel' is set
            if (linkModel == null)
                throw new ApiException(400, "Missing required parameter 'linkModel' when calling LinkApi->LinkCreateLink");

            var localVarPath = "/api/v1.0.0/links";
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

            if (linkModel != null && linkModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(linkModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = linkModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkCreateLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (LinkModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of LinkModel</returns>
        public async System.Threading.Tasks.Task<LinkModel> CreateLinkAsync (LinkModel linkModel)
        {
             ApiResponse<LinkModel> localVarResponse = await CreateLinkAsyncWithHttpInfo(linkModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of ApiResponse (LinkModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<LinkModel>> CreateLinkAsyncWithHttpInfo (LinkModel linkModel)
        {
            // verify the required parameter 'linkModel' is set
            if (linkModel == null)
                throw new ApiException(400, "Missing required parameter 'linkModel' when calling LinkApi->LinkCreateLink");

            var localVarPath = "/api/v1.0.0/links";
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

            if (linkModel != null && linkModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(linkModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = linkModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkCreateLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (LinkModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns></returns>
        public void DeleteLink (int? linkId)
        {
             DeleteLinkWithHttpInfo(linkId);
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteLinkWithHttpInfo (int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if (linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkDeleteLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            if (linkId != null) localVarPathParams.Add("linkId", this.Configuration.ApiClient.ParameterToString(linkId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkDeleteLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteLinkAsync (int? linkId)
        {
             await DeleteLinkAsyncWithHttpInfo(linkId);

        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteLinkAsyncWithHttpInfo (int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if (linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkDeleteLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            if (linkId != null) localVarPathParams.Add("linkId", this.Configuration.ApiClient.ParameterToString(linkId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkDeleteLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>LinkModel</returns>
        public LinkModel GetLink (int? linkId)
        {
             ApiResponse<LinkModel> localVarResponse = GetLinkWithHttpInfo(linkId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        public ApiResponse< LinkModel > GetLinkWithHttpInfo (int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if (linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkGetLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            if (linkId != null) localVarPathParams.Add("linkId", this.Configuration.ApiClient.ParameterToString(linkId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkGetLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (LinkModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of LinkModel</returns>
        public async System.Threading.Tasks.Task<LinkModel> GetLinkAsync (int? linkId)
        {
             ApiResponse<LinkModel> localVarResponse = await GetLinkAsyncWithHttpInfo(linkId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse (LinkModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<LinkModel>> GetLinkAsyncWithHttpInfo (int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if (linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkGetLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            if (linkId != null) localVarPathParams.Add("linkId", this.Configuration.ApiClient.ParameterToString(linkId)); // path parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkGetLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (LinkModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>List&lt;LinkModel&gt;</returns>
        public List<LinkModel> UpdateLink (List<LinkModel> linkModels)
        {
             ApiResponse<List<LinkModel>> localVarResponse = UpdateLinkWithHttpInfo(linkModels);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>ApiResponse of List&lt;LinkModel&gt;</returns>
        public ApiResponse< List<LinkModel> > UpdateLinkWithHttpInfo (List<LinkModel> linkModels)
        {
            // verify the required parameter 'linkModels' is set
            if (linkModels == null)
                throw new ApiException(400, "Missing required parameter 'linkModels' when calling LinkApi->LinkUpdateLink");

            var localVarPath = "/api/v1.0.0/links/sortorder";
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

            if (linkModels != null && linkModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(linkModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = linkModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkUpdateLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<LinkModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of List&lt;LinkModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<LinkModel>> UpdateLinkAsync (List<LinkModel> linkModels)
        {
             ApiResponse<List<LinkModel>> localVarResponse = await UpdateLinkAsyncWithHttpInfo(linkModels);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of ApiResponse (List&lt;LinkModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<LinkModel>>> UpdateLinkAsyncWithHttpInfo (List<LinkModel> linkModels)
        {
            // verify the required parameter 'linkModels' is set
            if (linkModels == null)
                throw new ApiException(400, "Missing required parameter 'linkModels' when calling LinkApi->LinkUpdateLink");

            var localVarPath = "/api/v1.0.0/links/sortorder";
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

            if (linkModels != null && linkModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(linkModels); // http body (model) parameter
            }
            else
            {
                localVarPostBody = linkModels; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkUpdateLink", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<LinkModel>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

    }
}
