using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWorkareaApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new workarea
        /// </summary>
        /// <remarks>
        /// Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        WorkareaFolderModel CreateWorkarea (WorkareaCreationModel creationModel);

        /// <summary>
        /// Create a new workarea
        /// </summary>
        /// <remarks>
        /// Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        ApiResponse<WorkareaFolderModel> CreateWorkareaWithHttpInfo (WorkareaCreationModel creationModel);
        /// <summary>
        /// Delete workarea folder
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns></returns>
        void DeleteWorkarea (string workareaFolderId);

        /// <summary>
        /// Delete workarea folder
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteWorkareaWithHttpInfo (string workareaFolderId);
        /// <summary>
        /// Get entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>List&lt;int?&gt;</returns>
        List<int?> GetWorkareaFolderEntityIds (string workareaFolderId);

        /// <summary>
        /// Get entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        ApiResponse<List<int?>> GetWorkareaFolderEntityIdsWithHttpInfo (string workareaFolderId);
        /// <summary>
        /// Set entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>List&lt;int?&gt;</returns>
        List<int?> GetWorkareaFolderEntityIds (string workareaFolderId, List<int?> entityIds);

        /// <summary>
        /// Set entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        ApiResponse<List<int?>> SetWorkareaFolderEntityIdsWithHttpInfo (string workareaFolderId, List<int?> entityIds);
        /// <summary>
        /// Update workarea folder
        /// </summary>
        /// <remarks>
        /// It&#39;s only possible to alter name and index properties
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        WorkareaFolderModel UpdateWorkarea (string workareaFolderId, WorkareaFolderModel workareaFolderModel);

        /// <summary>
        /// Update workarea folder
        /// </summary>
        /// <remarks>
        /// It&#39;s only possible to alter name and index properties
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        ApiResponse<WorkareaFolderModel> UpdateWorkareaWithHttpInfo (string workareaFolderId, WorkareaFolderModel workareaFolderModel);
        /// <summary>
        /// Update workarea query
        /// </summary>
        /// <remarks>
        /// Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>WorkareaFolderModel</returns>
        WorkareaFolderModel UpdateWorkareaQuery (string workareaFolderId, QueryModel queryModel);

        /// <summary>
        /// Update workarea query
        /// </summary>
        /// <remarks>
        /// Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>ApiResponse of WorkareaFolderModel</returns>
        ApiResponse<WorkareaFolderModel> UpdateWorkareaQueryWithHttpInfo (string workareaFolderId, QueryModel queryModel);
        /// <summary>
        /// Get workarea folder tree
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>List&lt;WorkareaTreeFolderModel&gt;</returns>
        List<WorkareaTreeFolderModel> WorkareaFolderTree (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);

        /// <summary>
        /// Get workarea folder tree
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaTreeFolderModel&gt;</returns>
        ApiResponse<List<WorkareaTreeFolderModel>> WorkareaFolderTreeWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);
        /// <summary>
        /// Get workarea folders
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>List&lt;WorkareaFolderModel&gt;</returns>
        List<WorkareaFolderModel> WorkareaFolders (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);

        /// <summary>
        /// Get workarea folders
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkareaFolderModel&gt;</returns>
        ApiResponse<List<WorkareaFolderModel>> WorkareaFoldersWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);
        /// <summary>
        /// Returns a list of entities in a workarea folder
        /// </summary>
        /// <remarks>
        /// Returns an entity list for any type of workarea
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>EntityListModel</returns>
        EntityListModel WorkareaQueryResult (string workareaFolderId);

        /// <summary>
        /// Returns a list of entities in a workarea folder
        /// </summary>
        /// <remarks>
        /// Returns an entity list for any type of workarea
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>ApiResponse of EntityListModel</returns>
        ApiResponse<EntityListModel> WorkareaQueryResultWithHttpInfo (string workareaFolderId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create a new workarea
        /// </summary>
        /// <remarks>
        /// Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        System.Threading.Tasks.Task<WorkareaFolderModel> CreateWorkareaAsync (WorkareaCreationModel creationModel);

        /// <summary>
        /// Create a new workarea
        /// </summary>
        /// <remarks>
        /// Supply either entityIds or query. This determines if the workarea is static or based on a query.    Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="creationModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> CreateWorkareaAsyncWithHttpInfo (WorkareaCreationModel creationModel);
        /// <summary>
        /// Delete workarea folder
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteWorkareaAsync (string workareaFolderId);

        /// <summary>
        /// Delete workarea folder
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteWorkareaAsyncWithHttpInfo (string workareaFolderId);
        /// <summary>
        /// Get entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        System.Threading.Tasks.Task<List<int?>> GetWorkareaFolderEntityIdsAsync (string workareaFolderId);

        /// <summary>
        /// Get entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<int?>>> GetWorkareaFolderEntityIdsAsyncWithHttpInfo (string workareaFolderId);
        /// <summary>
        /// Set entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        System.Threading.Tasks.Task<List<int?>> SetWorkareaFolderEntityIdsAsync (string workareaFolderId, List<int?> entityIds);

        /// <summary>
        /// Set entity id&#39;s in a static workarea
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="entityIds"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<int?>>> SetWorkareaFolderEntityIdsAsyncWithHttpInfo (string workareaFolderId, List<int?> entityIds);
        /// <summary>
        /// Update workarea folder
        /// </summary>
        /// <remarks>
        /// It&#39;s only possible to alter name and index properties
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaAsync (string workareaFolderId, WorkareaFolderModel workareaFolderModel);

        /// <summary>
        /// Update workarea folder
        /// </summary>
        /// <remarks>
        /// It&#39;s only possible to alter name and index properties
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="workareaFolderModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaAsyncWithHttpInfo (string workareaFolderId, WorkareaFolderModel workareaFolderModel);
        /// <summary>
        /// Update workarea query
        /// </summary>
        /// <remarks>
        /// Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of WorkareaFolderModel</returns>
        System.Threading.Tasks.Task<WorkareaFolderModel> UpdateWorkareaQueryAsync (string workareaFolderId, QueryModel queryModel);

        /// <summary>
        /// Update workarea query
        /// </summary>
        /// <remarks>
        /// Check the description for the /query endpoint on how to constuct a query.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <param name="queryModel"></param>
        /// <returns>Task of ApiResponse (WorkareaFolderModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<WorkareaFolderModel>> UpdateWorkareaQueryAsyncWithHttpInfo (string workareaFolderId, QueryModel queryModel);
        /// <summary>
        /// Get workarea folder tree
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of List&lt;WorkareaTreeFolderModel&gt;</returns>
        System.Threading.Tasks.Task<List<WorkareaTreeFolderModel>> WorkareaFolderTreeAsync (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);

        /// <summary>
        /// Get workarea folder tree
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;WorkareaTreeFolderModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<WorkareaTreeFolderModel>>> WorkareaFolderTreeAsyncWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);
        /// <summary>
        /// Get workarea folders
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of List&lt;WorkareaFolderModel&gt;</returns>
        System.Threading.Tasks.Task<List<WorkareaFolderModel>> WorkareaFoldersAsync (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);

        /// <summary>
        /// Get workarea folders
        /// </summary>
        /// <remarks>
        /// The parameter includeCreatedByMe will be ignored if forUsername is set.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="includeCreatedByMe">optional (optional)</param>
        /// <param name="includeShared">optional (optional)</param>
        /// <param name="forUsername">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;WorkareaFolderModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<WorkareaFolderModel>>> WorkareaFoldersAsyncWithHttpInfo (bool? includeCreatedByMe = null, bool? includeShared = null, string forUsername = null);
        /// <summary>
        /// Returns a list of entities in a workarea folder
        /// </summary>
        /// <remarks>
        /// Returns an entity list for any type of workarea
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of EntityListModel</returns>
        System.Threading.Tasks.Task<EntityListModel> WorkareaQueryResultAsync (string workareaFolderId);

        /// <summary>
        /// Returns a list of entities in a workarea folder
        /// </summary>
        /// <remarks>
        /// Returns an entity list for any type of workarea
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="workareaFolderId"></param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntityListModel>> WorkareaQueryResultAsyncWithHttpInfo (string workareaFolderId);
        #endregion Asynchronous Operations
    }
}