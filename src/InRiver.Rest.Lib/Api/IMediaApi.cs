using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMediaApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel AddExternalUrl (ExternalUrlFileModelWithLink urlFileModel);

        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> AddExternalUrlWithHttpInfo (ExternalUrlFileModelWithLink urlFileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel UploadBase64File (Base64FileModelWithLink base64FileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> UploadBase64FileWithHttpInfo (Base64FileModelWithLink base64FileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>MediaInfoModel</returns>
        MediaInfoModel UploadMediaFromUrl (UrlFileModelWithLink urlFileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>ApiResponse of MediaInfoModel</returns>
        ApiResponse<MediaInfoModel> UploadMediaFromUrlWithHttpInfo (UrlFileModelWithLink urlFileModel);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> AddExternalUrlAsync (ExternalUrlFileModelWithLink urlFileModel);

        /// <summary>
        /// Add external media url
        /// </summary>
        /// <remarks>
        /// If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.     Example:                Original external file URL that is added with this REST endpoint                https://yourexternalresourceservice.com/imagename.jpg                Your external image service then need to support the standard inRiver image configuration formats(Original, Preview, Thumbnail and SmallThumbnail) as a suffix on the URL that you uploaded or have a proxy that redirect to the right image format, else the inRiver web portal will not work correct.                https://yourexternalresourceservice.com/imagename.jpg/Original &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Preview &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/Thumbnail &lt;br /&gt;  https://yourexternalresourceservice.com/imagename.jpg/SmallThumbnail &lt;br /&gt;
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> AddExternalUrlAsyncWithHttpInfo (ExternalUrlFileModelWithLink urlFileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> UploadBase64FileAsync (Base64FileModelWithLink base64FileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Upload base64 encoded file data. A resource entity will be created.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="base64FileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadBase64FileAsyncWithHttpInfo (Base64FileModelWithLink base64FileModel);
        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of MediaInfoModel</returns>
        System.Threading.Tasks.Task<MediaInfoModel> UploadMediaFromUrlAsync (UrlFileModelWithLink urlFileModel);

        /// <summary>
        /// Add Media
        /// </summary>
        /// <remarks>
        /// Note: If overrideUrlFileName is omitted, the filename will equal the one supplied in the url. Set overrideUrlFileName to specifiy a file name.    If the resourceLink object is omitted a resource entity will be created without a link. If resourceLink.linkTypeId is omitted inRiver will automatically find the most suitable link type.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="urlFileModel"></param>
        /// <returns>Task of ApiResponse (MediaInfoModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<MediaInfoModel>> UploadMediaFromUrlAsyncWithHttpInfo (UrlFileModelWithLink urlFileModel);
        #endregion Asynchronous Operations
    }
}