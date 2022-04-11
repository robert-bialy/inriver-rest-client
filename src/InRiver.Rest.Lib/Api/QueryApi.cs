using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using RestSharp;

namespace InRiver.Rest.Lib.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal class QueryApi : IQueryApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public QueryApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public QueryApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;: (string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;: (Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;: (string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;: (Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;: (Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;: (Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria (in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>EntityListModel</returns>
        public EntityListModel Query (QueryModel queryModel)
        {
             ApiResponse<EntityListModel> localVarResponse = QueryWithHttpInfo(queryModel);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;: (string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;: (Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;: (string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;: (Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;: (Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;: (Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria (in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>ApiResponse of EntityListModel</returns>
        public ApiResponse< EntityListModel > QueryWithHttpInfo (QueryModel queryModel)
        {
            // verify the required parameter 'queryModel' is set
            if (queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling QueryApi->QueryQuery");

            var localVarPath = "/api/v1.0.0/query";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (queryModel != null && queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(queryModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("QueryQuery", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;: (string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;: (Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;: (string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;: (Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;: (Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;: (Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria (in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>Task of EntityListModel</returns>
        public async System.Threading.Tasks.Task<EntityListModel> QueryAsync (QueryModel queryModel)
        {
             ApiResponse<EntityListModel> localVarResponse = await QueryAsyncWithHttpInfo(queryModel);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Search for entity id&#39;s Available system criterion types and their supported operators&lt;br /&gt;   - -- --  &lt;b&gt;FieldSetId&lt;/b&gt;: (string) Equal, NotEqual, IsEmpty, IsNotEmpty&lt;br /&gt;&lt;b&gt;SegmentIds&lt;/b&gt;: (Integer array) ContainsAny, NotContainsAny&lt;br /&gt;&lt;b&gt;CreatedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;ModifiedBy&lt;/b&gt;: (email, string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Created&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;LastModified&lt;/b&gt;: (DateTime) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;EntityTypeId&lt;/b&gt;: (string) Equal, NotEqual&lt;br /&gt;&lt;b&gt;Completeness&lt;/b&gt;: (Integer) Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual&lt;br /&gt;&lt;b&gt;ChannelId&lt;/b&gt;: (Integer) Equal&lt;br /&gt;&lt;b&gt;PublicationId&lt;/b&gt;: (Integer) Equal                Operators for each field datatype in dataCriteria&lt;br /&gt;   - -- --  &lt;b&gt;String&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;LocaleString&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;Boolean&lt;/b&gt;: IsTrue, IsFalse, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(singlevalue)&lt;/b&gt;: Equal, NotEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;CVL(multivalue)&lt;/b&gt;: ContainsAll, ContainsAny, NotContainsAll, NotContainsAny, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Date time&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Integer and Double&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,&lt;br /&gt;&lt;b&gt;Xml&lt;/b&gt;: Equal, NotEqual, BeginsWith, IsEmpty, IsNotEmpty, Contains&lt;br /&gt;&lt;b&gt;File&lt;/b&gt;: Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual, IsEmpty IsNotEmpty,                Language  - -- --  &lt;b&gt;LocaleString&lt;/b&gt; is the only data type that supports language.                 Link Criterion&lt;br /&gt;   - -- --  Direction determines if the source or target entity of the link will be included in the result.&lt;br /&gt;  - If direction is \&quot;outbound\&quot;, the link source entity is included in the result&lt;br /&gt;  - If direction is \&quot;inbound\&quot;, the link target entity is included in the result&lt;br /&gt;    If linkCriterion.dataCriteria is omitted the search will simply check if a link exists.&lt;br /&gt;    The boolean linkExists defaults to true and may be omitted. Setting linkExists to false searches for entities without links and can&#39;t be combined with data criteria (in the link criterion).&lt;br /&gt;    Note: Keep your queries as simple as possible. More complex queries take longer time to perform.&lt;br /&gt;
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryModel"></param>
        /// <returns>Task of ApiResponse (EntityListModel)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EntityListModel>> QueryAsyncWithHttpInfo (QueryModel queryModel)
        {
            // verify the required parameter 'queryModel' is set
            if (queryModel == null)
                throw new ApiException(400, "Missing required parameter 'queryModel' when calling QueryApi->QueryQuery");

            var localVarPath = "/api/v1.0.0/query";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (queryModel != null && queryModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(queryModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = queryModel; // byte array
            }


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("QueryQuery", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<EntityListModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (EntityListModel) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(EntityListModel)));
        }

    }
}
