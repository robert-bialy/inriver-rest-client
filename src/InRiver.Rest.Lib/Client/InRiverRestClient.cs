using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using InRiver.Rest.Lib.Api;

namespace InRiver.Rest.Lib.Client
{
    public class InRiverRestClient : IinRiverClient
    {
        private readonly Configuration _configuration;

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

        public IChannelApi ChannelApi => new ChannelApi(_configuration);

        public IEntityApi EntityApi => new EntityApi(_configuration);

        public ILinkApi LinkApi => new LinkApi(_configuration);

        public IMediaApi MediaApi => new MediaApi(_configuration);

        public IModelApi ModelApi => new ModelApi(_configuration);

        public IQueryApi QueryApi => new QueryApi(_configuration);

        public ISyndicateApi SyndicateApi => new SyndicateApi(_configuration);

        public ISystemApi SystemApi => new SystemApi(_configuration);

        public IWorkareaApi WorkareaApi => new WorkareaApi(_configuration);
    }
}