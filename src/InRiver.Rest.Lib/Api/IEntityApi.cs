using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEntityApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel AddExternalUrl(int? entityId, ExeternalUrlFileModel urlFileModel);

        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> AddExternalUrlWithHttpInfo(int? entityId, ExeternalUrlFileModel urlFileModel);
        /// <summary>
        /// Entity comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;CommentModel&gt;</returns>
        List<CommentModel> Comments(int? entityId);

        /// <summary>
        /// Entity comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;CommentModel&gt;</returns>
        ApiResponse<List<CommentModel>> CommentsWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;CompletenessDetailsModel&gt;</returns>
        List<CompletenessDetailsModel> CompletenessDetails(int? entityId);

        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;CompletenessDetailsModel&gt;</returns>
        ApiResponse<List<CompletenessDetailsModel>> CompletenessDetailsWithHttpInfo(int? entityId);
        /// <summary>
        /// Post entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>List&lt;CommentModel&gt;</returns>
        List<CommentModel> CreateComment(int? entityId, CommentModel commentModel);

        /// <summary>
        /// Post entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>ApiResponse of List&lt;CommentModel&gt;</returns>
        ApiResponse<List<CommentModel>> CreateCommentWithHttpInfo(int? entityId, CommentModel commentModel);
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <remarks>
        /// If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>EntitySummaryModel</returns>
        EntitySummaryModel CreateEntity(EntityCreationModel entityCreationModel);

        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <remarks>
        /// If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        ApiResponse<EntitySummaryModel> CreateEntityWithHttpInfo(EntityCreationModel entityCreationModel);
        /// <summary>
        /// Delete entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        void DeleteComment(int? entityId, int? commentId);

        /// <summary>
        /// Delete entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of object(void)</returns>
        ApiResponse<object> DeleteCommentWithHttpInfo(int? entityId, int? commentId);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns></returns>
        void DeleteEntity(int? entityId);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of object(void)</returns>
        ApiResponse<object> DeleteEntityWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns various types of entity data
        /// </summary>
        /// <remarks>
        /// Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityobjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityobjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchobjectsModel"></param>
        /// <returns>List&lt;EntityDataModel&gt;</returns>
        List<EntityDataModel> FetchData(FetchobjectsModel fetchobjectsModel);

        /// <summary>
        /// Returns various types of entity data
        /// </summary>
        /// <remarks>
        /// Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityobjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityobjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchobjectsModel"></param>
        /// <returns>ApiResponse of List&lt;EntityDataModel&gt;</returns>
        ApiResponse<List<EntityDataModel>> FetchDataWithHttpInfo(FetchobjectsModel fetchobjectsModel);
        /// <summary>
        /// Field value revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>FieldRevisionModel</returns>
        FieldRevisionModel[] FieldHistory(int? entityId, string fieldTypeId);

        /// <summary>
        /// Field value revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>ApiResponse of FieldRevisionModel</returns>
        ApiResponse<FieldRevisionModel[]> FieldHistoryWithHttpInfo(int? entityId, string fieldTypeId);
        /// <summary>
        /// Returns a read only list of entity media
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;MediaInfoModel&gt;</returns>
        List<MediaInfoModel> GetAllMedia (int? entityId);

        /// <summary>
        /// Returns a read only list of entity media
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;MediaInfoModel&gt;</returns>
        ApiResponse<List<MediaInfoModel>> GetAllMediaWithHttpInfo(int? entityId);
        /// <summary>
        /// Get All Segments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Segment&gt;</returns>
        List<Segment> GetAllSegments();

        /// <summary>
        /// Get All Segments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Segment&gt;</returns>
        ApiResponse<List<Segment>> AllSegmentsWithHttpInfo();
        /// <summary>
        /// Returns an entity creation model
        /// </summary>
        /// <remarks>
        /// The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>EntityCreationModel</returns>
        EntityCreationModel GetEmptyEntity(string entityTypeId, string fieldSetId = null, bool? allFields = null);

        /// <summary>
        /// Returns an entity creation model
        /// </summary>
        /// <remarks>
        /// The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>ApiResponse of EntityCreationModel</returns>
        ApiResponse<EntityCreationModel> GetEmptyEntityWithHttpInfo(string entityTypeId, string fieldSetId = null, bool? allFields = null);
        /// <summary>
        /// Returns a bundle of the entity and all linked entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>EntityBundleModel</returns>
        EntityBundleModel GetEntityBundle(int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null);

        /// <summary>
        /// Returns a bundle of the entity and all linked entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of EntityBundleModel</returns>
        ApiResponse<EntityBundleModel> GetEntityBundleWithHttpInfo(int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null);
        /// <summary>
        /// Returns a read only entity summary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>EntitySummaryModel</returns>
        EntitySummaryModel GetEntitySummary(int? entityId);

        /// <summary>
        /// Returns a read only entity summary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        ApiResponse<EntitySummaryModel> GetEntitySummaryWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;FieldValueModel&gt;</returns>
        List<FieldValueModel> GetFieldValues(int? entityId, string fieldTypeIds = null);

        /// <summary>
        /// Returns a list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;FieldValueModel&gt;</returns>
        ApiResponse<List<FieldValueModel>> GetFieldValuesWithHttpInfo(int? entityId, string fieldTypeIds = null);
        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;FieldSummaryModel&gt;</returns>
        List<FieldSummaryModel> GetFields(int? entityId, string fieldTypeIds = null);

        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;FieldSummaryModel&gt;</returns>
        ApiResponse<List<FieldSummaryModel>> GetFieldsWithHttpInfo(int? entityId, string fieldTypeIds = null);
        /// <summary>
        /// Returns a list of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>List&lt;LinkModel&gt;</returns>
        List<LinkModel> GetLinksForEntity(int? entityId, string linkDirection = null, string linkTypeId = null);

        /// <summary>
        /// Returns a list of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>ApiResponse of List&lt;LinkModel&gt;</returns>
        ApiResponse<List<LinkModel>> GetLinksForEntityWithHttpInfo(int? entityId, string linkDirection = null, string linkTypeId = null);
        /// <summary>
        /// Returns a read only list of entity media details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>List&lt;MediaInfoModel&gt;</returns>
        List<MediaInfoModel> GetMediaDetails(int? entityId);

        /// <summary>
        /// Returns a read only list of entity media details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>ApiResponse of List&lt;MediaInfoModel&gt;</returns>
        ApiResponse<List<MediaInfoModel>> GetMediaDetailsWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a read only list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;SpecificationValueSummaryModel&gt;</returns>
        List<SpecificationValueSummaryModel> GetSpecificationSummary(int? entityId, string specificationFieldTypeIds = null);

        /// <summary>
        /// Returns a read only list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;SpecificationValueSummaryModel&gt;</returns>
        ApiResponse<List<SpecificationValueSummaryModel>> GetSpecificationSummaryWithHttpInfo(int? entityId, string specificationFieldTypeIds = null);
        /// <summary>
        /// Returns a list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>List&lt;SpecificationValueModel&gt;</returns>
        List<SpecificationValueModel> GetSpecificationValues(int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null);

        /// <summary>
        /// Returns a list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>ApiResponse of List&lt;SpecificationValueModel&gt;</returns>
        ApiResponse<List<SpecificationValueModel>> GetSpecificationValuesWithHttpInfo(int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null);
        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Dictionary&lt;string, int?&gt;</returns>
        Dictionary<string, int?> MapUniqueValues(MapUniqueValuesModel mapUniqueValuesModel);

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, int?&gt;</returns>
        ApiResponse<Dictionary<string, int?>> MapUniqueValuesWithHttpInfo(MapUniqueValuesModel mapUniqueValuesModel);
        /// <summary>
        /// Set field set
        /// </summary>
        /// <remarks>
        /// Set fieldSetId to null to remove the field set
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>EntitySummaryModel</returns>
        EntitySummaryModel SetFieldSet(int? entityId, SetFieldSetModel setFieldSetModel);

        /// <summary>
        /// Set field set
        /// </summary>
        /// <remarks>
        /// Set fieldSetId to null to remove the field set
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        ApiResponse<EntitySummaryModel> SetFieldSetWithHttpInfo(int? entityId, SetFieldSetModel setFieldSetModel);
        /// <summary>
        /// Update field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>List&lt;FieldValueModel&gt;</returns>
        List<FieldValueModel> SetFieldValues(int? entityId, List<FieldValueModel> fieldValueModels);

        /// <summary>
        /// Update field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>ApiResponse of List&lt;FieldValueModel&gt;</returns>
        ApiResponse<List<FieldValueModel>> SetFieldValuesWithHttpInfo(int? entityId, List<FieldValueModel> fieldValueModels);
        /// <summary>
        /// Set entity segment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>EntitySummaryModel</returns>
        EntitySummaryModel SetSegment(int? entityId, SetSegmentModel setSegmentModel);

        /// <summary>
        /// Set entity segment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        ApiResponse<EntitySummaryModel> SetSegmentWithHttpInfo(int? entityId, SetSegmentModel setSegmentModel);
        /// <summary>
        /// Set specification template
        /// </summary>
        /// <remarks>
        /// Set SpecificationId to null for removing specification template
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>EntitySummaryModel</returns>
        EntitySummaryModel SetSpecificationTemplate(int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel);

        /// <summary>
        /// Set specification template
        /// </summary>
        /// <remarks>
        /// Set SpecificationId to null for removing specification template
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>ApiResponse of EntitySummaryModel</returns>
        ApiResponse<EntitySummaryModel> SetSpecificationTemplateWithHttpInfo(int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel);
        /// <summary>
        /// Get list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;int?&gt;</returns>
        List<int?> StarredEntities();

        /// <summary>
        /// Get list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        ApiResponse<List<int?>> StarredEntitiesWithHttpInfo();
        /// <summary>
        /// Update specification field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available specification field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>List&lt;SpecificationValueModel&gt;</returns>
        List<SpecificationValueModel> UpdateSpecificationValues(int? entityId, List<SpecificationValueModel> specificationValueModels);

        /// <summary>
        /// Update specification field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available specification field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>ApiResponse of List&lt;SpecificationValueModel&gt;</returns>
        ApiResponse<List<SpecificationValueModel>> UpdateSpecificationValuesWithHttpInfo(int? entityId, List<SpecificationValueModel> specificationValueModels);
        /// <summary>
        /// Update list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>List&lt;int?&gt;</returns>
        List<int?> UpdateStarredEntities(List<int?> entityIds);

        /// <summary>
        /// Update list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>ApiResponse of List&lt;int?&gt;</returns>
        ApiResponse<List<int?>> UpdateStarredEntitiesWithHttpInfo(List<int?> entityIds);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel UploadBase64File(int? entityId, Base64FileModel base64FileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> UploadBase64FileWithHttpInfo(int? entityId, Base64FileModel base64FileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel UploadMediaFromUrl(int? entityId, UrlFileModel urlFileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> EntityUploadMediaFromUrlWithHttpInfo(int? entityId, UrlFileModel urlFileModel);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> AddExternalUrlAsync(int? entityId, ExeternalUrlFileModel urlFileModel);

        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example:     You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> AddExternalUrlAsyncWithHttpInfo(int? entityId, ExeternalUrlFileModel urlFileModel);
        /// <summary>
        /// Entity comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;CommentModel&gt;</returns>
        System.Threading.Tasks.Task<List<CommentModel>> CommentsAsync(int? entityId);

        /// <summary>
        /// Entity comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;CommentModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CommentModel>>> CommentsAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;CompletenessDetailsModel&gt;</returns>
        System.Threading.Tasks.Task<List<CompletenessDetailsModel>> CompletenessDetailsAsync(int? entityId);

        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;CompletenessDetailsModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CompletenessDetailsModel>>> CompletenessDetailsAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Post entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>Task of List&lt;CommentModel&gt;</returns>
        System.Threading.Tasks.Task<List<CommentModel>> CreateCommentAsync(int? entityId, CommentModel commentModel);

        /// <summary>
        /// Post entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentModel"></param>
        /// <returns>Task of ApiResponse (List&lt;CommentModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CommentModel>>> CreateCommentAsyncWithHttpInfo(int? entityId, CommentModel commentModel);
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <remarks>
        /// If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        System.Threading.Tasks.Task<EntitySummaryModel> CreateEntityAsync(EntityCreationModel entityCreationModel);

        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <remarks>
        /// If segmentId is omitted in a multi segment environment, the entity will be created in a segment the user has access to. It&#39;s recommended to omit segmentId at all times if the enviroment doesn&#39;t have multiple segments.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityCreationModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> CreateEntityAsyncWithHttpInfo(EntityCreationModel entityCreationModel);
        /// <summary>
        /// Delete entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteCommentAsync(int? entityId, int? commentId);

        /// <summary>
        /// Delete entity comment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="commentId"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> DeleteCommentAsyncWithHttpInfo(int? entityId, int? commentId);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteEntityAsync(int? entityId);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> DeleteEntityAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns various types of entity data
        /// </summary>
        /// <remarks>
        /// Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityobjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityobjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchobjectsModel"></param>
        /// <returns>Task of List&lt;EntityDataModel&gt;</returns>
        System.Threading.Tasks.Task<List<EntityDataModel>> FetchDataAsync(FetchobjectsModel fetchobjectsModel);

        /// <summary>
        /// Returns various types of entity data
        /// </summary>
        /// <remarks>
        /// Fetch data for a list of entity id&#39;s and specify what data to include (objects).    Specify what objects to include in a comma separated list. You may fetch different object sets for entities, inbound links, outbound links. Supply a \&quot;linkEntityobjects\&quot; string in the inbound or outbound object to include link entity data in the response.    Link types may be specified for both inbound and outbound using linkTypeIds (a comma separated list of link type id&#39;s). If linkTypeIds is omitted no filtering will be applied.    Field data may be filtered by suppling a comma separated list as fieldTypeIds. The filter will be applied on all entities and linked entities regardless of entity type.    Available objects  - -- --  EntitySummary&lt;br /&gt;  FieldsSummary&lt;br /&gt;  FieldValues&lt;br /&gt;  SpecificationSummary&lt;br /&gt;  SpecificationValues&lt;br /&gt;  Media&lt;br /&gt;  MediaDetails&lt;br /&gt;    Examples:&lt;br /&gt;  \&quot;objects\&quot;: \&quot;EntitySummary,Media\&quot; &lt;br /&gt;  \&quot;linkEntityobjects\&quot;: \&quot;FieldValues\&quot; (applicable to inbound and outbound links only)&lt;br /&gt;    Always request as few objects as possible as this will reduce the response time.    Limit: 1000 entity ids per request.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="fetchobjectsModel"></param>
        /// <returns>Task of ApiResponse (List&lt;EntityDataModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<EntityDataModel>>> FetchDataAsyncWithHttpInfo(FetchobjectsModel fetchobjectsModel);
        /// <summary>
        /// Field value revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>Task of FieldRevisionModel</returns>
        System.Threading.Tasks.Task<FieldRevisionModel[]> FieldHistoryAsync(int? entityId, string fieldTypeId);

        /// <summary>
        /// Field value revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeId"></param>
        /// <returns>Task of ApiResponse (FieldRevisionModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<FieldRevisionModel[]>> FieldHistoryAsyncWithHttpInfo(int? entityId, string fieldTypeId);
        /// <summary>
        /// Returns a read only list of entity media
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;MediaInfoModel&gt;</returns>
        System.Threading.Tasks.Task<List<MediaInfoModel>> GetAllMediaAsync(int? entityId);

        /// <summary>
        /// Returns a read only list of entity media
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;MediaInfoModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<MediaInfoModel>>> GetAllMediaAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Get All Segments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Segment&gt;</returns>
        System.Threading.Tasks.Task<List<Segment>> GetAllSegmentsAsync();

        /// <summary>
        /// Get All Segments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Segment&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Segment>>> GetAllSegmentsAsyncWithHttpInfo();
        /// <summary>
        /// Returns an entity creation model
        /// </summary>
        /// <remarks>
        /// The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>Task of EntityCreationModel</returns>
        System.Threading.Tasks.Task<EntityCreationModel> GetEmptyEntityAsync(string entityTypeId, string fieldSetId = null, bool? allFields = null);

        /// <summary>
        /// Returns an entity creation model
        /// </summary>
        /// <remarks>
        /// The fieldValues array will contain all fields required to create an entity (usually all mandatory and unique fields).
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeId"></param>
        /// <param name="fieldSetId">optional (optional)</param>
        /// <param name="allFields">optional, include all fields (not included in a field set) (optional)</param>
        /// <returns>Task of ApiResponse (EntityCreationModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntityCreationModel>> GetEmptyEntityAsyncWithHttpInfo(string entityTypeId, string fieldSetId = null, bool? allFields = null);
        /// <summary>
        /// Returns a bundle of the entity and all linked entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of EntityBundleModel</returns>
        System.Threading.Tasks.Task<EntityBundleModel> GetEntityBundleAsync(int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null);

        /// <summary>
        /// Returns a bundle of the entity and all linked entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter field types using comma separated list (optional)</param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (EntityBundleModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntityBundleModel>> GetEntityBundleAsyncWithHttpInfo(int? entityId, string fieldTypeIds = null, string linkDirection = null, string linkTypeId = null);
        /// <summary>
        /// Returns a read only entity summary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        System.Threading.Tasks.Task<EntitySummaryModel> GetEntitySummaryAsync(int? entityId);

        /// <summary>
        /// Returns a read only entity summary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> GetEntitySummaryAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;FieldValueModel&gt;</returns>
        System.Threading.Tasks.Task<List<FieldValueModel>> GetFieldValuesAsync(int? entityId, string fieldTypeIds = null);

        /// <summary>
        /// Returns a list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FieldValueModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FieldValueModel>>> GetFieldValuesAsyncWithHttpInfo(int? entityId, string fieldTypeIds = null);
        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;FieldSummaryModel&gt;</returns>
        System.Threading.Tasks.Task<List<FieldSummaryModel>> GetFieldsAsync(int? entityId, string fieldTypeIds = null);

        /// <summary>
        /// Returns a read only list of field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FieldSummaryModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FieldSummaryModel>>> GetFieldsAsyncWithHttpInfo(int? entityId, string fieldTypeIds = null);
        /// <summary>
        /// Returns a list of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of List&lt;LinkModel&gt;</returns>
        System.Threading.Tasks.Task<List<LinkModel>> GetLinksForEntityAsync(int? entityId, string linkDirection = null, string linkTypeId = null);

        /// <summary>
        /// Returns a list of links
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="linkDirection">optional, \&quot;inbound\&quot; or \&quot;outbound\&quot; (optional)</param>
        /// <param name="linkTypeId">optional, filter by link type (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;LinkModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LinkModel>>> GetLinksForEntityAsyncWithHttpInfo(int? entityId, string linkDirection = null, string linkTypeId = null);
        /// <summary>
        /// Returns a read only list of entity media details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of List&lt;MediaInfoModel&gt;</returns>
        System.Threading.Tasks.Task<List<MediaInfoModel>> GetMediaDetailsAsync(int? entityId);

        /// <summary>
        /// Returns a read only list of entity media details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <returns>Task of ApiResponse (List&lt;MediaInfoModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<MediaInfoModel>>> EntityGetMediaDetailsAsyncWithHttpInfo(int? entityId);
        /// <summary>
        /// Returns a read only list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;SpecificationValueSummaryModel&gt;</returns>
        System.Threading.Tasks.Task<List<SpecificationValueSummaryModel>> GetSpecificationSummaryAsync(int? entityId, string specificationFieldTypeIds = null);

        /// <summary>
        /// Returns a read only list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueSummaryModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueSummaryModel>>> GetSpecificationSummaryAsyncWithHttpInfo(int? entityId, string specificationFieldTypeIds = null);
        /// <summary>
        /// Returns a list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>Task of List&lt;SpecificationValueModel&gt;</returns>
        System.Threading.Tasks.Task<List<SpecificationValueModel>> GetSpecificationValuesAsync(int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null);

        /// <summary>
        /// Returns a list of specification field values
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationFieldTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <param name="mandatoryOnly">optional (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueModel>>> GetSpecificationValuesAsyncWithHttpInfo(int? entityId, string specificationFieldTypeIds = null, bool? mandatoryOnly = null);
        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Task of Dictionary&lt;string, int?&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, int?>> MapUniqueValuesAsync(MapUniqueValuesModel mapUniqueValuesModel);

        /// <summary>
        /// Returns a dictionary of unique values and entity id&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapUniqueValuesModel"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, int?&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, int?>>> MapUniqueValuesAsyncWithHttpInfo(MapUniqueValuesModel mapUniqueValuesModel);
        /// <summary>
        /// Set field set
        /// </summary>
        /// <remarks>
        /// Set fieldSetId to null to remove the field set
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        System.Threading.Tasks.Task<EntitySummaryModel> SetFieldSetAsync(int? entityId, SetFieldSetModel setFieldSetModel);

        /// <summary>
        /// Set field set
        /// </summary>
        /// <remarks>
        /// Set fieldSetId to null to remove the field set
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setFieldSetModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetFieldSetAsyncWithHttpInfo(int? entityId, SetFieldSetModel setFieldSetModel);
        /// <summary>
        /// Update field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>Task of List&lt;FieldValueModel&gt;</returns>
        System.Threading.Tasks.Task<List<FieldValueModel>> SetFieldValuesAsync(int? entityId, List<FieldValueModel> fieldValueModels);

        /// <summary>
        /// Update field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="fieldValueModels"></param>
        /// <returns>Task of ApiResponse (List&lt;FieldValueModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FieldValueModel>>> SetFieldValuesAsyncWithHttpInfo(int? entityId, List<FieldValueModel> fieldValueModels);
        /// <summary>
        /// Set entity segment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        System.Threading.Tasks.Task<EntitySummaryModel> SetSegmentAsync(int? entityId, SetSegmentModel setSegmentModel);

        /// <summary>
        /// Set entity segment
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSegmentModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetSegmentAsyncWithHttpInfo(int? entityId, SetSegmentModel setSegmentModel);
        /// <summary>
        /// Set specification template
        /// </summary>
        /// <remarks>
        /// Set SpecificationId to null for removing specification template
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>Task of EntitySummaryModel</returns>
        System.Threading.Tasks.Task<EntitySummaryModel> SetSpecificationTemplateAsync(int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel);

        /// <summary>
        /// Set specification template
        /// </summary>
        /// <remarks>
        /// Set SpecificationId to null for removing specification template
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="setSpecificationTemplateModel"></param>
        /// <returns>Task of ApiResponse (EntitySummaryModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<EntitySummaryModel>> SetSpecificationTemplateAsyncWithHttpInfo(int? entityId, SetSpecificationTemplateModel setSpecificationTemplateModel);
        /// <summary>
        /// Get list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;int?&gt;</returns>
        System.Threading.Tasks.Task<List<int?>> StarredEntitiesAsync();

        /// <summary>
        /// Get list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<int?>>> StarredEntitiesAsyncWithHttpInfo();
        /// <summary>
        /// Update specification field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available specification field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>Task of List&lt;SpecificationValueModel&gt;</returns>
        System.Threading.Tasks.Task<List<SpecificationValueModel>> UpdateSpecificationValuesAsync(int? entityId, List<SpecificationValueModel> specificationValueModels);

        /// <summary>
        /// Update specification field values
        /// </summary>
        /// <remarks>
        /// The list may be an subset of available specification field values
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="specificationValueModels"></param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationValueModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SpecificationValueModel>>> UpdateSpecificationValuesAsyncWithHttpInfo(int? entityId, List<SpecificationValueModel> specificationValueModels);
        /// <summary>
        /// Update list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>Task of List&lt;int?&gt;</returns>
        System.Threading.Tasks.Task<List<int?>> UpdateStarredEntitiesAsync(List<int?> entityIds);

        /// <summary>
        /// Update list of starred entities
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityIds"></param>
        /// <returns>Task of ApiResponse (List&lt;int?&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<int?>>> UpdateStarredEntitiesAsyncWithHttpInfo(List<int?> entityIds);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> UploadBase64FileAsync(int? entityId, Base64FileModel base64FileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data.     Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadBase64FileAsyncWithHttpInfo(int? entityId, Base64FileModel base64FileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> UploadMediaFromUrlAsync(int? entityId, UrlFileModel urlFileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Enter entityId for the entity you want to link the created resource entity to.     Example: You want to create a resource and then link it to a Product. You add the entityId for the product entity that you would like to link the resource entity to.    Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityId"></param>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadMediaFromUrlAsyncWithHttpInfo(int? entityId, UrlFileModel urlFileModel);
        #endregion Asynchronous Operations
    }
}