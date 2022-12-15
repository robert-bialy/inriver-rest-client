using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IChannelApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Channel path content
        /// </summary>
        /// <remarks>
        /// Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ChannelPathContentModel</returns>
        ChannelPathContentModel ChannelContent(string path, string entityTypeIds = null);

        /// <summary>
        /// Channel path content
        /// </summary>
        /// <remarks>
        /// Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of ChannelPathContentModel</returns>
        ApiResponse<ChannelPathContentModel> ChannelContentWithHttpInfo(string path, string entityTypeIds = null);
        /// <summary>
        /// Get entity types for channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> ChannelEntityTypes (int? channelId);

        /// <summary>
        /// Get entity types for channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> EntityTypesWithHttpInfo(int? channelId);
        /// <summary>
        /// Get entity links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>EntityListModel</returns>
        EntityListModel GetByEntityType(int? channelId, int? entityId, string linkDirection, string linkTypeId = null);

        /// <summary>
        /// Get entity links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of EntityListModel</returns>
        ApiResponse<EntityListModel> GetByEntityTypeWithHttpInfo(int? channelId, int? entityId, string linkDirection, string linkTypeId = null);
        /// <summary>
        /// Get a list of entities in a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>EntityListModel</returns>
        EntityListModel GetByLinkEntityType(int? channelId, string entityTypeId = null);

        /// <summary>
        /// Get a list of entities in a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>ApiResponse of EntityListModel</returns>
        ApiResponse<EntityListModel> GetByLinkEntityTypeWithHttpInfo(int? channelId, string entityTypeId = null);
        /// <summary>
        /// Channel structure tree
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Dictionary&lt;string, StructureNode&gt;</returns>
        Dictionary<string, StructureNode> GetChannelNodeTree(int? channelId);

        /// <summary>
        /// Channel structure tree
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, StructureNode&gt;</returns>
        ApiResponse<Dictionary<string, StructureNode>> GetChannelNodeTreeWithHttpInfo(int? channelId);
        /// <summary>
        /// Channel structure list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetChannelNodes(int? channelId);

        /// <summary>
        /// Channel structure list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetChannelNodesWithHttpInfo(int? channelId);
        /// <summary>
        /// Get structure entities for entity
        /// </summary>
        /// <remarks>
        /// Returns all occurances of an entity in a channel
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>List&lt;StructureEntityModel&gt;</returns>
        List<StructureEntityModel> GetChannelStructureEntities(int? channelId, int? entityId);

        /// <summary>
        /// Get structure entities for entity
        /// </summary>
        /// <remarks>
        /// Returns all occurances of an entity in a channel
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;StructureEntityModel&gt;</returns>
        ApiResponse<List<StructureEntityModel>> GetChannelStructureEntitiesWithHttpInfo(int? channelId, int? entityId);
        /// <summary>
        /// Get channel id&#39;s for entity id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>List&lt;ChannelSummaryModel&gt;</returns>
        List<ChannelSummaryModel> GetChannelsForEntityId(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null);

        /// <summary>
        /// Get channel id&#39;s for entity id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>ApiResponse of List&lt;ChannelSummaryModel&gt;</returns>
        ApiResponse<List<ChannelSummaryModel>> GetChannelsForEntityIdWithHttpInfo(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Channel path content
        /// </summary>
        /// <remarks>
        /// Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ChannelPathContentModel</returns>
        System.Threading.Tasks.Task<ChannelPathContentModel> ChannelContentAsync(string path, string entityTypeIds = null);

        /// <summary>
        /// Channel path content
        /// </summary>
        /// <remarks>
        /// Use the entity list to directly query data. Use the paths in the content array to traverse the channel structure.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (ChannelPathContentModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<ChannelPathContentModel>> ChannelContentAsyncWithHttpInfo(string path, string entityTypeIds = null);
        /// <summary>
        /// Get entity types for channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> EntityTypesAsync(int? channelId);

        /// <summary>
        /// Get entity types for channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> EntityTypesAsyncWithHttpInfo(int? channelId);
        /// <summary>
        /// Get entity links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of EntityListModel</returns>
        System.Threading.Tasks.Task<EntityListModel> GetByEntityTypeAsync(int? channelId, int? entityId, string linkDirection, string linkTypeId = null);

        /// <summary>
        /// Get entity links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">\&quot;inbound\&quot; or \&quot;outbound\&quot;</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntityListModel>> GetByEntityTypeAsyncWithHttpInfo(int? channelId, int? entityId, string linkDirection, string linkTypeId = null);
        /// <summary>
        /// Get a list of entities in a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>Task of EntityListModel</returns>
        System.Threading.Tasks.Task<EntityListModel> GetByLinkEntityTypeAsync(int? channelId, string entityTypeId = null);

        /// <summary>
        /// Get a list of entities in a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityTypeId">optional, filter by entity type id (optional)</param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntityListModel>> GetByLinkEntityTypeAsyncWithHttpInfo(int? channelId, string entityTypeId = null);
        /// <summary>
        /// Channel structure tree
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of Dictionary&lt;string, StructureNode&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, StructureNode>> GetChannelNodeTreeAsync(int? channelId);

        /// <summary>
        /// Channel structure tree
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, StructureNode&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, StructureNode>>> GetChannelNodeTreeAsyncWithHttpInfo(int? channelId);
        /// <summary>
        /// Channel structure list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetChannelNodesAsync(int? channelId);

        /// <summary>
        /// Channel structure list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetChannelNodesAsyncWithHttpInfo(int? channelId);
        /// <summary>
        /// Get structure entities for entity
        /// </summary>
        /// <remarks>
        /// Returns all occurances of an entity in a channel
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;StructureEntityModel&gt;</returns>
        System.Threading.Tasks.Task<List<StructureEntityModel>> GetChannelStructureEntitiesAsync(int? channelId, int? entityId);

        /// <summary>
        /// Get structure entities for entity
        /// </summary>
        /// <remarks>
        /// Returns all occurances of an entity in a channel
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId"></param>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;StructureEntityModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<StructureEntityModel>>> GetChannelStructureEntitiesAsyncWithHttpInfo(int? channelId, int? entityId);
        /// <summary>
        /// Get channel id&#39;s for entity id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>Task of List&lt;ChannelSummaryModel&gt;</returns>
        System.Threading.Tasks.Task<List<ChannelSummaryModel>> GetChannelsForEntityIdAsync(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null);

        /// <summary>
        /// Get channel id&#39;s for entity id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forEntityId">optional (optional)</param>
        /// <param name="includeChannels">optional, defaults to true (optional)</param>
        /// <param name="includePublications">optional, defaults to false (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;ChannelSummaryModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<ChannelSummaryModel>>> GetChannelsForEntityIdAsyncWithHttpInfo(int? forEntityId = null, bool? includeChannels = null, bool? includePublications = null);
        #endregion Asynchronous Operations
    }
}