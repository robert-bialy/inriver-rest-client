using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IModelApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create new CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>CVLValueModel</returns>
        CVLValueModel CreateCvlValue (string cvlId, CVLValueModel cvlValueModel);

        /// <summary>
        /// Create new CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        ApiResponse<CVLValueModel> CreateCvlValueWithHttpInfo (string cvlId, CVLValueModel cvlValueModel);
        /// <summary>
        /// Delete CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns></returns>
        void DeleteCvlValue (string cvlId, string key);

        /// <summary>
        /// Delete CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteCvlValueWithHttpInfo (string cvlId, string key);
        /// <summary>
        /// Returns all values for a CVL
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>List&lt;CVLValueModel&gt;</returns>
        List<CVLValueModel> GetAllCvlValues (string cvlId);

        /// <summary>
        /// Returns all values for a CVL
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>ApiResponse of List&lt;CVLValueModel&gt;</returns>
        ApiResponse<List<CVLValueModel>> GetAllCvlValuesWithHttpInfo (string cvlId);
        /// <summary>
        /// Returns all CVL&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;CVLModel&gt;</returns>
        List<CVLModel> GetAllCvls ();

        /// <summary>
        /// Returns all CVL&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;CVLModel&gt;</returns>
        ApiResponse<List<CVLModel>> GetAllCvlsWithHttpInfo ();
        /// <summary>
        /// Returns available entity types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>List&lt;EntityTypeModel&gt;</returns>
        List<EntityTypeModel> GetAllEntityTypes (string entityTypeIds = null);

        /// <summary>
        /// Returns available entity types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>ApiResponse of List&lt;EntityTypeModel&gt;</returns>
        ApiResponse<List<EntityTypeModel>> GetAllEntityTypesWithHttpInfo (string entityTypeIds = null);
        /// <summary>
        /// Returns available field sets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;FieldSetModel&gt;</returns>
        List<FieldSetModel> GetAllFieldSets ();

        /// <summary>
        /// Returns available field sets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;FieldSetModel&gt;</returns>
        ApiResponse<List<FieldSetModel>> GetAllFieldSetsWithHttpInfo ();
        /// <summary>
        /// Returns available languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;LanguageModel&gt;</returns>
        List<LanguageModel> GetAllLanguages ();

        /// <summary>
        /// Returns available languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;LanguageModel&gt;</returns>
        ApiResponse<List<LanguageModel>> GetAllLanguagesWithHttpInfo ();
        /// <summary>
        /// Returns all specification templates
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;EntitySummaryModel&gt;</returns>
        List<EntitySummaryModel> GetAllSpecificationTemplates ();

        /// <summary>
        /// Returns all specification templates
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;EntitySummaryModel&gt;</returns>
        ApiResponse<List<EntitySummaryModel>> GetAllSpecificationTemplatesWithHttpInfo ();
        /// <summary>
        /// Get CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>CVLValueModel</returns>
        CVLValueModel GetCvlValue (string cvlId, string key);

        /// <summary>
        /// Get CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        ApiResponse<CVLValueModel> GetCvlValueWithHttpInfo (string cvlId, string key);
        /// <summary>
        /// Returns field types for specification template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>List&lt;SpecificationFieldTypeModel&gt;</returns>
        List<SpecificationFieldTypeModel> GetSpecificationTemplatesields (int? templateId);

        /// <summary>
        /// Returns field types for specification template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>ApiResponse of List&lt;SpecificationFieldTypeModel&gt;</returns>
        ApiResponse<List<SpecificationFieldTypeModel>> GetSpecificationTemplatesieldsWithHttpInfo (int? templateId);
        /// <summary>
        /// Update CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>CVLValueModel</returns>
        CVLValueModel UpdateCvlValue (string cvlId, string key, CVLValueModel cvlValueModel);

        /// <summary>
        /// Update CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>ApiResponse of CVLValueModel</returns>
        ApiResponse<CVLValueModel> UpdateCvlValueWithHttpInfo (string cvlId, string key, CVLValueModel cvlValueModel);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create new CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of CVLValueModel</returns>
        System.Threading.Tasks.Task<CVLValueModel> CreateCvlValueAsync (string cvlId, CVLValueModel cvlValueModel);

        /// <summary>
        /// Create new CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of ApiResponse (CVLValueModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> CreateCvlValueAsyncWithHttpInfo (string cvlId, CVLValueModel cvlValueModel);
        /// <summary>
        /// Delete CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteCvlValueAsync (string cvlId, string key);

        /// <summary>
        /// Delete CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">The key of the CVL value to delete</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteCvlValueAsyncWithHttpInfo (string cvlId, string key);
        /// <summary>
        /// Returns all values for a CVL
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>Task of List&lt;CVLValueModel&gt;</returns>
        System.Threading.Tasks.Task<List<CVLValueModel>> GetAllCvlValuesAsync (string cvlId);

        /// <summary>
        /// Returns all values for a CVL
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <returns>Task of ApiResponse (List&lt;CVLValueModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CVLValueModel>>> GetAllCvlValuesAsyncWithHttpInfo (string cvlId);
        /// <summary>
        /// Returns all CVL&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;CVLModel&gt;</returns>
        System.Threading.Tasks.Task<List<CVLModel>> GetAllCvlsAsync ();

        /// <summary>
        /// Returns all CVL&#39;s
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;CVLModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CVLModel>>> GetAllCvlsAsyncWithHttpInfo ();
        /// <summary>
        /// Returns available entity types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of List&lt;EntityTypeModel&gt;</returns>
        System.Threading.Tasks.Task<List<EntityTypeModel>> GetAllEntityTypesAsync (string entityTypeIds = null);

        /// <summary>
        /// Returns available entity types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityTypeIds">optional, filter types using comma separated list (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;EntityTypeModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<EntityTypeModel>>> GetAllEntityTypesAsyncWithHttpInfo (string entityTypeIds = null);
        /// <summary>
        /// Returns available field sets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;FieldSetModel&gt;</returns>
        System.Threading.Tasks.Task<List<FieldSetModel>> GetAllFieldSetsAsync ();

        /// <summary>
        /// Returns available field sets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;FieldSetModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FieldSetModel>>> GetAllFieldSetsAsyncWithHttpInfo ();
        /// <summary>
        /// Returns available languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;LanguageModel&gt;</returns>
        System.Threading.Tasks.Task<List<LanguageModel>> GetAllLanguagesAsync ();

        /// <summary>
        /// Returns available languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;LanguageModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LanguageModel>>> GetAllLanguagesAsyncWithHttpInfo ();
        /// <summary>
        /// Returns all specification templates
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;EntitySummaryModel&gt;</returns>
        System.Threading.Tasks.Task<List<EntitySummaryModel>> GetAllSpecificationTemplatesAsync ();

        /// <summary>
        /// Returns all specification templates
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;EntitySummaryModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<EntitySummaryModel>>> GetAllSpecificationTemplatesAsyncWithHttpInfo ();
        /// <summary>
        /// Get CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>Task of CVLValueModel</returns>
        System.Threading.Tasks.Task<CVLValueModel> GetCvlValueAsync (string cvlId, string key);

        /// <summary>
        /// Get CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key">CVL value key</param>
        /// <returns>Task of ApiResponse (CVLValueModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> GetCvlValueAsyncWithHttpInfo (string cvlId, string key);
        /// <summary>
        /// Returns field types for specification template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>Task of List&lt;SpecificationFieldTypeModel&gt;</returns>
        System.Threading.Tasks.Task<List<SpecificationFieldTypeModel>> GetSpecificationTemplatesieldsAsync (int? templateId);

        /// <summary>
        /// Returns field types for specification template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        /// <returns>Task of ApiResponse (List&lt;SpecificationFieldTypeModel&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SpecificationFieldTypeModel>>> GetSpecificationTemplatesieldsAsyncWithHttpInfo (int? templateId);
        /// <summary>
        /// Update CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of CVLValueModel</returns>
        System.Threading.Tasks.Task<CVLValueModel> UpdateCvlValueAsync (string cvlId, string key, CVLValueModel cvlValueModel);

        /// <summary>
        /// Update CVL value
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cvlId"></param>
        /// <param name="key"></param>
        /// <param name="cvlValueModel"></param>
        /// <returns>Task of ApiResponse (CVLValueModel)</returns>
        System.Threading.Tasks.Task<ApiResponse<CVLValueModel>> UpdateCvlValueAsyncWithHttpInfo (string cvlId, string key, CVLValueModel cvlValueModel);
        #endregion Asynchronous Operations
    }
}