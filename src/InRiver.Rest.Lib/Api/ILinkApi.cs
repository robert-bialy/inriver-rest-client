using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILinkApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new link
        /// </summary>
        /// <remarks>
        /// Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>LinkModel</returns>
        LinkModel CreateLink(LinkModel linkModel);

        /// <summary>
        /// Create a new link
        /// </summary>
        /// <remarks>
        /// Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        ApiResponse<LinkModel> CreateLinkWithHttpInfo(LinkModel linkModel);
        /// <summary>
        /// Delete link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns></returns>
        void DeleteLink (int? linkId);

        /// <summary>
        /// Delete link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of object(void)</returns>
        ApiResponse<object> DeleteLinkWithHttpInfo(int? linkId);
        /// <summary>
        /// Returns a link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>LinkModel</returns>
        LinkModel GetLink (int? linkId);

        /// <summary>
        /// Returns a link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>ApiResponse of LinkModel</returns>
        ApiResponse<LinkModel> GetLinkWithHttpInfo(int? linkId);
        /// <summary>
        /// Update sort order of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>List&lt;LinkModel&gt;</returns>
        List<LinkModel> UpdateLink(List<LinkModel> linkModels);

        /// <summary>
        /// Update sort order of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>ApiResponse of List&lt;LinkModel&gt;</returns>
        ApiResponse<List<LinkModel>> UpdateLinkWithHttpInfo(List<LinkModel> linkModels);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create a new link
        /// </summary>
        /// <remarks>
        /// Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of LinkModel</returns>
        System.Threading.Tasks.Task<LinkModel> CreateLinkAsync(LinkModel linkModel);

        /// <summary>
        /// Create a new link
        /// </summary>
        /// <remarks>
        /// Set index to 0 to add the link to first position. Set index to null to add the link to last position. Specifying the index will reorganize all link indices.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModel"></param>
        /// <returns>Task of ApiResponse (LinkModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<LinkModel>> CreateLinkAsyncWithHttpInfo(LinkModel linkModel);
        /// <summary>
        /// Delete link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteLinkAsync(int? linkId);

        /// <summary>
        /// Delete link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> DeleteLinkAsyncWithHttpInfo(int? linkId);
        /// <summary>
        /// Returns a link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of LinkModel</returns>
        System.Threading.Tasks.Task<LinkModel> GetLinkAsync(int? linkId);

        /// <summary>
        /// Returns a link
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkId"></param>
        /// <returns>Task of ApiResponse (LinkModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<LinkModel>> GetLinkAsyncWithHttpInfo(int? linkId);
        /// <summary>
        /// Update sort order of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of List&lt;LinkModel&gt;</returns>
        System.Threading.Tasks.Task<List<LinkModel>> UpdateLinkAsync(List<LinkModel> linkModels);

        /// <summary>
        /// Update sort order of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="linkModels"></param>
        /// <returns>Task of ApiResponse (List&lt;LinkModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LinkModel>>> UpdateLinkAsyncWithHttpInfo(List<LinkModel> linkModels);
        #endregion Asynchronous Operations
    }
}