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
    internal sealed class LinkApi : ILinkApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LinkApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
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
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>LinkModel</returns>
        public LinkModel CreateLink(LinkModel linkModel)
        {
             var localVarResponse = CreateLinkWithHttpInfo(linkModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        public ApiResponse<LinkModel> CreateLinkWithHttpInfo(LinkModel linkModel)
        {
            // verify the required parameter 'linkModel' is set
            if(linkModel == null)
                throw new ApiException(400, "Missing required parameter 'linkModel' when calling LinkApi->LinkCreateLink");

            var localVarPath = "/api/v1.0.0/links";
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

            if(linkModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(linkModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = linkModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (LinkModel) _serializer.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of LinkModel</returns>
        public async System.Threading.Tasks.Task<LinkModel> CreateLinkAsync(LinkModel linkModel)
        {
             var localVarResponse = await CreateLinkAsyncWithHttpInfo(linkModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new link Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of ApiResponse(LinkModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<LinkModel>> CreateLinkAsyncWithHttpInfo(LinkModel linkModel)
        {
            // verify the required parameter 'linkModel' is set
            if(linkModel == null)
                throw new ApiException(400, "Missing required parameter 'linkModel' when calling LinkApi->LinkCreateLink");

            var localVarPath = "/api/v1.0.0/links";
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

            if(linkModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(linkModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = linkModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (LinkModel) _serializer.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns></returns>
        public void DeleteLink(int? linkId)
        {
             DeleteLinkWithHttpInfo(linkId);
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of object(void)</returns>
        public ApiResponse<object> DeleteLinkWithHttpInfo(int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if(linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkDeleteLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            localVarPathParams.Add("linkId", HttpHelpers.ParameterToString(linkId, Configuration)); // path parameter

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
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteLinkAsync(int? linkId)
        {
            await DeleteLinkAsyncWithHttpInfo(linkId);
        }

        /// <summary>
        /// Delete link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteLinkAsyncWithHttpInfo(int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if(linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkDeleteLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            localVarPathParams.Add("linkId", HttpHelpers.ParameterToString(linkId, Configuration)); // path parameter

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
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>LinkModel</returns>
        public LinkModel GetLink(int? linkId)
        {
             var localVarResponse = GetLinkWithHttpInfo(linkId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        public ApiResponse<LinkModel> GetLinkWithHttpInfo(int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if(linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkGetLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            localVarPathParams.Add("linkId", HttpHelpers.ParameterToString(linkId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (LinkModel) _serializer.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of LinkModel</returns>
        public async System.Threading.Tasks.Task<LinkModel> GetLinkAsync(int? linkId)
        {
             var localVarResponse = await GetLinkAsyncWithHttpInfo(linkId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns a link 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse(LinkModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<LinkModel>> GetLinkAsyncWithHttpInfo(int? linkId)
        {
            // verify the required parameter 'linkId' is set
            if(linkId == null)
                throw new ApiException(400, "Missing required parameter 'linkId' when calling LinkApi->LinkGetLink");

            var localVarPath = "/api/v1.0.0/links/{linkId}";
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

            localVarPathParams.Add("linkId", HttpHelpers.ParameterToString(linkId, Configuration)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<LinkModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (LinkModel) _serializer.Deserialize(localVarResponse, typeof(LinkModel)));
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>List&lt;LinkModel&gt;</returns>
        public List<LinkModel> UpdateLink(List<LinkModel> linkModels)
        {
             var localVarResponse = UpdateLinkWithHttpInfo(linkModels);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>ApiResponse of List&lt;LinkModel&gt;</returns>
        public ApiResponse<List<LinkModel>> UpdateLinkWithHttpInfo(List<LinkModel> linkModels)
        {
            // verify the required parameter 'linkModels' is set
            if(linkModels == null)
                throw new ApiException(400, "Missing required parameter 'linkModels' when calling LinkApi->LinkUpdateLink");

            var localVarPath = "/api/v1.0.0/links/sortorder";
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

            if(linkModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(linkModels); // http body(model) parameter
            }
            else
            {
                localVarPostBody = linkModels; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<LinkModel>) _serializer.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of List&lt;LinkModel&gt;</returns>
        public async System.Threading.Tasks.Task<List<LinkModel>> UpdateLinkAsync(List<LinkModel> linkModels)
        {
             var localVarResponse = await UpdateLinkAsyncWithHttpInfo(linkModels);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update sort order of links 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of ApiResponse(List&lt;LinkModel&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<LinkModel>>> UpdateLinkAsyncWithHttpInfo(List<LinkModel> linkModels)
        {
            // verify the required parameter 'linkModels' is set
            if(linkModels == null)
                throw new ApiException(400, "Missing required parameter 'linkModels' when calling LinkApi->LinkUpdateLink");

            var localVarPath = "/api/v1.0.0/links/sortorder";
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

            if(linkModels.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(linkModels); // http body(model) parameter
            }
            else
            {
                localVarPostBody = linkModels; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<List<LinkModel>>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (List<LinkModel>) _serializer.Deserialize(localVarResponse, typeof(List<LinkModel>)));
        }

    }
}
