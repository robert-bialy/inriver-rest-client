using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using InRiver.Rest.Lib.Api;
using InRiver.Rest.Lib.Services;

namespace InRiver.Rest.Lib.Client
{
    public sealed class InRiverRestClient : IinRiverClient
    {
        #region Private Members

        private readonly Configuration _configuration;
        private readonly ISerializer _serializer = new Serializer();
        private IChannelApi _channelApi;
        private IEntityApi _entityApi;
        private ILinkApi _linkApi;
        private IMediaApi _mediaApi;
        private IModelApi _modelApi;
        private IQueryApi _queryApi;
        private ISyndicateApi _syndicateApi;
        private ISystemApi _systemApi;
        private IWorkareaApi _workareaApi;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InRiverRestClient" /> class.
        /// </summary>
        /// <param name="apiKey">inRiver's key used to authenticate.</param>
        /// <param name="basePath">REST API's endpoint.</param>
        public InRiverRestClient(string apiKey, string basePath = "https://apieuw.productmarketingcloud.com")
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidDataException("Api key is required and cannot be null or empty");
            if (string.IsNullOrWhiteSpace(basePath))
                throw new InvalidDataException("Base path is required and cannot be null or empty");
            _configuration = new Configuration
            {
                BasePath = basePath,
                DefaultHeader = new Dictionary<string, string>
                {
                    { Configuration.InRiverAPIKeyHeader, apiKey }
                }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InRiverRestClient" /> class.
        /// </summary>
        /// <param name="configuration">Configuration class.</param>
        public InRiverRestClient(Action<Configuration> configuration)
        {
            _configuration = new Configuration();
            configuration.Invoke(_configuration);
            if(string.IsNullOrWhiteSpace(_configuration.BasePath))
                throw new InvalidDataException("Base path is required and cannot be null or empty");
            if (_configuration.DefaultHeader == null || !_configuration.DefaultHeader.ContainsKey("X-inRiver-APIKey") || string.IsNullOrWhiteSpace(_configuration.DefaultHeader["X-inRiver-APIKey"]))
                throw new InvalidDataException("Api key is required and cannot be null or empty. Please include default X-inRiver-APIKey header.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InRiverRestClient" /> class.
        /// </summary>
        /// <param name="apiKey">inRiver's key used to authenticate.</param>
        /// <param name="configuration">Configuration class.</param>
        /// <param name="basePath">REST API's endpoint.</param>
        public InRiverRestClient(
            string apiKey,
            string basePath,
            Action<Configuration> configuration = null)
            : this(apiKey, basePath)
        {
            configuration?.Invoke(_configuration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InRiverRestClient" /> class.
        /// </summary>
        /// <param name="apiKey">inRiver's key used to authenticate.</param>
        /// <param name="httpClient">httpClient override.</param>
        /// <param name="configuration">Configuration class.</param>
        /// <param name="basePath">REST API's endpoint.</param>
        public InRiverRestClient(
            string apiKey,
            string basePath,
            HttpClient httpClient = null,
            Action<Configuration> configuration = null)
            : this(apiKey, basePath)
        {
            _configuration.HttpClientOverride = httpClient;
            configuration?.Invoke(_configuration);
        }

        public IChannelApi ChannelApi => _channelApi ?? (_channelApi = new ChannelApi(_serializer,_configuration));

        public IEntityApi EntityApi => _entityApi ?? (_entityApi = new EntityApi(_serializer,_configuration));

        public ILinkApi LinkApi => _linkApi ?? (_linkApi = new LinkApi(_serializer,_configuration));

        public IMediaApi MediaApi => _mediaApi ?? (_mediaApi = new MediaApi(_serializer,_configuration));

        public IModelApi ModelApi => _modelApi ?? (_modelApi = new ModelApi(_serializer,_configuration));

        public IQueryApi QueryApi => _queryApi ?? (_queryApi = new QueryApi(_serializer,_configuration));

        public ISyndicateApi SyndicateApi => _syndicateApi ?? (_syndicateApi =  new SyndicateApi(_serializer,_configuration));

        public ISystemApi SystemApi => _systemApi ?? (_systemApi = new SystemApi(_serializer, _configuration));

        public IWorkareaApi WorkareaApi => _workareaApi ?? (_workareaApi = new WorkareaApi(_serializer, _configuration));
    }
}