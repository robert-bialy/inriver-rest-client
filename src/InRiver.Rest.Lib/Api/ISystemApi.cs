using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISystemApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Assign a role to a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        UserRolesModel AddUserRoleForSegment(int? segmentId, UserRoleModel userRoleModel);

        /// <summary>
        /// Assign a role to a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        ApiResponse<UserRolesModel> AddUserRoleForSegmentWithHttpInfo(int? segmentId, UserRoleModel userRoleModel);
        /// <summary>
        /// Returns available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetAllImageConfigurations();

        /// <summary>
        /// Returns available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetAllImageConfigurationsWithHttpInfo();
        /// <summary>
        /// Return full details of available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ImageConfigurationDetailsModel</returns>
        ImageConfigurationDetailsModel GetImageConfigurationDetails();

        /// <summary>
        /// Return full details of available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of ImageConfigurationDetailsModel</returns>
        ApiResponse<ImageConfigurationDetailsModel> GetImageConfigurationDetailsWithHttpInfo();
        /// <summary>
        /// Get list of server settings
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        Dictionary<string, string> GetServerSettings(string settingNames = null);

        /// <summary>
        /// Get list of server settings
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        ApiResponse<Dictionary<string, string>> GetServerSettingsWithHttpInfo(string settingNames = null);
        /// <summary>
        /// Remove a role from a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>UserRolesModel</returns>
        UserRolesModel RemoveUserRoleForSegment(int? segmentId, UserRoleModel userRoleModel);

        /// <summary>
        /// Remove a role from a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        ApiResponse<UserRolesModel> RemoveUserRoleForSegmentWithHttpInfo(int? segmentId, UserRoleModel userRoleModel);
        /// <summary>
        /// Get list of user roles and permissions
        /// </summary>
        /// <remarks>
        /// If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>List&lt;RoleModel&gt;</returns>
        List<RoleModel> Roles(string forUsername = null);

        /// <summary>
        /// Get list of user roles and permissions
        /// </summary>
        /// <remarks>
        /// If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>ApiResponse of List&lt;RoleModel&gt;</returns>
        ApiResponse<List<RoleModel>> RolesWithHttpInfo(string forUsername = null);
        /// <summary>
        /// Get list of segments
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>List&lt;SegmentModel&gt;</returns>
        List<SegmentModel> Segments(string forUsername = null);

        /// <summary>
        /// Get list of segments
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>ApiResponse of List&lt;SegmentModel&gt;</returns>
        ApiResponse<List<SegmentModel>> SegmentsWithHttpInfo(string forUsername = null);
        /// <summary>
        /// Modify user access for segment
        /// </summary>
        /// <remarks>
        /// The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>UserRolesModel</returns>
        UserRolesModel SetUserRolesForSegment(int? segmentId, UserRolesModel userRolesModel);

        /// <summary>
        /// Modify user access for segment
        /// </summary>
        /// <remarks>
        /// The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>ApiResponse of UserRolesModel</returns>
        ApiResponse<UserRolesModel> SetUserRolesForSegmentWithHttpInfo(int? segmentId, UserRolesModel userRolesModel);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Assign a role to a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        System.Threading.Tasks.Task<UserRolesModel> AddUserRoleForSegmentAsync(int? segmentId, UserRoleModel userRoleModel);

        /// <summary>
        /// Assign a role to a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> AddUserRoleForSegmentAsyncWithHttpInfo(int? segmentId, UserRoleModel userRoleModel);
        /// <summary>
        /// Returns available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetAllImageConfigurationsAsync();

        /// <summary>
        /// Returns available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetAllImageConfigurationsAsyncWithHttpInfo();
        /// <summary>
        /// Return full details of available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ImageConfigurationDetailsModel</returns>
        System.Threading.Tasks.Task<ImageConfigurationDetailsModel> GetImageConfigurationDetailsAsync();

        /// <summary>
        /// Return full details of available image configurations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse(ImageConfigurationDetailsModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<ImageConfigurationDetailsModel>> GetImageConfigurationDetailsAsyncWithHttpInfo();
        /// <summary>
        /// Get list of server settings
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Task of Dictionary&lt;string, string&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, string>> GetServerSettingsAsync(string settingNames = null);

        /// <summary>
        /// Get list of server settings
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="settingNames">optional, comma separated list of setting names(optional)</param>
        /// <returns>Task of ApiResponse(Dictionary&lt;string, string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, string>>> GetServerSettingsAsyncWithHttpInfo(string settingNames = null);
        /// <summary>
        /// Remove a role from a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        System.Threading.Tasks.Task<UserRolesModel> RemoveUserRoleForSegmentAsync(int? segmentId, UserRoleModel userRoleModel);

        /// <summary>
        /// Remove a role from a user and segment
        /// </summary>
        /// <remarks>
        /// The roleName value expects a single role name, such as \&quot;Editor\&quot; or \&quot;Reader\&quot;. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRoleModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> RemoveUserRoleForSegmentAsyncWithHttpInfo(int? segmentId, UserRoleModel userRoleModel);
        /// <summary>
        /// Get list of user roles and permissions
        /// </summary>
        /// <remarks>
        /// If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>Task of List&lt;RoleModel&gt;</returns>
        System.Threading.Tasks.Task<List<RoleModel>> RolesAsync(string forUsername = null);

        /// <summary>
        /// Get list of user roles and permissions
        /// </summary>
        /// <remarks>
        /// If the environment has multiple segments the user&#39;s roles for assigned segments will be combined. The /segments endpoint should be used for multi segment environments. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get permissions for a specific user(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;RoleModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<RoleModel>>> RolesAsyncWithHttpInfo(string forUsername = null);
        /// <summary>
        /// Get list of segments
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>Task of List&lt;SegmentModel&gt;</returns>
        System.Threading.Tasks.Task<List<SegmentModel>> SegmentsAsync(string forUsername = null);

        /// <summary>
        /// Get list of segments
        /// </summary>
        /// <remarks>
        /// Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="forUsername">optional, get segments for a specific user(optional)</param>
        /// <returns>Task of ApiResponse(List&lt;SegmentModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SegmentModel>>> SegmentsAsyncWithHttpInfo(string forUsername = null);
        /// <summary>
        /// Modify user access for segment
        /// </summary>
        /// <remarks>
        /// The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of UserRolesModel</returns>
        System.Threading.Tasks.Task<UserRolesModel> SetUserRolesForSegmentAsync(int? segmentId, UserRolesModel userRolesModel);

        /// <summary>
        /// Modify user access for segment
        /// </summary>
        /// <remarks>
        /// The roleNames array is expecting a list of role names, such as [\&quot;Editor\&quot;, \&quot;Reader\&quot;]. The roleNames array may be set to empty or null in order to completely remove user access from the given segment. Requires administrator role.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="segmentId"></param>
        /// <param name="userRolesModel"></param>
        /// <returns>Task of ApiResponse(UserRolesModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserRolesModel>> GetUserRolesForSegmentAsyncWithHttpInfo(int? segmentId, UserRolesModel userRolesModel);
        #endregion Asynchronous Operations
    }
}