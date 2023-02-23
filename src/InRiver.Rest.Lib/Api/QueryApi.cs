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
    internal sealed class QueryApi : IQueryApi
    {
        private readonly ISerializer _serializer;
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="apiClient"></param>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public QueryApi(ISerializer serializer, IApiClient apiClient, Configuration configuration = null)
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
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;:(string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;:(Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;:(string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;:(Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;:(Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;:(Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria(in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>EntityListModel</returns>
        public EntityListModel Query(QueryModel queryModel)
        {
             var localVarResponse = QueryWithHttpInfo(queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;:(string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;:(Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;:(string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;:(Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;:(Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;:(Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria(in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse<EntityListModel> QueryWithHttpInfo(QueryModel queryModel)
        {
            // verify the required parameter 'queryModel' is set
            if(queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling QueryApi->QueryQuery");

            var localVarPath = "/api/v1.0.0/query";
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

            if(queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(queryModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) _apiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;:(string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;:(Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;:(string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;:(Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;:(Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;:(Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria(in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> QueryAsync(QueryModel queryModel)
        {
             var localVarResponse = await QueryAsyncWithHttpInfo(queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;:(string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;:(Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;:(email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;:(DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;:(string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;:(Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;:(Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;:(Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria(in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>Task of ApiResponse(EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> QueryAsyncWithHttpInfo(QueryModel queryModel)
        {
            // verify the required parameter 'queryModel' is set
            if(queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling QueryApi->QueryQuery");

            var localVarPath = "/api/v1.0.0/query";
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

            if(queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = _serializer.Serialize(queryModel); // http body(model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse =(RestResponse) await _apiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode =(int) localVarResponse.StatusCode;
            
            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers?.ToDictionary(x => x.Name, x => x.Value?.ToString()),
               (EntityListModel) _serializer.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

    }
}
