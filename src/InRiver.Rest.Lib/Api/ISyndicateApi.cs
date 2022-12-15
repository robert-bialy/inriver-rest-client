using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISyndicateApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Run Syndicate
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>Object</returns>
        Object RunSyndicate(int? syndicationId);

        /// <summary>
        /// Run Syndicate
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> RunSyndicateWithHttpInfo(int? syndicationId);
        /// <summary>
        /// Get All Syndications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;SyndicationModel&gt;</returns>
        List<SyndicationModel> Syndications();

        /// <summary>
        /// Get All Syndications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;SyndicationModel&gt;</returns>
        ApiResponse<List<SyndicationModel>> SyndicationsWithHttpInfo();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Run Syndicate
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> RunSyndicateAsync(int? syndicationId);

        /// <summary>
        /// Run Syndicate
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="syndicationId"></param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RunSyndicateAsyncWithHttpInfo(int? syndicationId);
        /// <summary>
        /// Get All Syndications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;SyndicationModel&gt;</returns>
        System.Threading.Tasks.Task<List<SyndicationModel>> SyndicationsAsync();

        /// <summary>
        /// Get All Syndications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;SyndicationModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SyndicationModel>>> SyndicationsAsyncWithHttpInfo();
        #endregion Asynchronous Operations
    }
}