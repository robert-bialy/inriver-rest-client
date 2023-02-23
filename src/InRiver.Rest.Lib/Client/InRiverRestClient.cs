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
        private object Lock = new object();
        private IApiClient _apiClient;
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
            if(string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidDataException("Api key is required and cannot be null or empty");
            if(string.IsNullOrWhiteSpace(basePath))
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
            if(_configuration.DefaultHeader == null || !_configuration.DefaultHeader.ContainsKey("X-inRiver-APIKey") || string.IsNullOrWhiteSpace(_configuration.DefaultHeader["X-inRiver-APIKey"]))
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

        public IChannelApi ChannelApi
        {
            get
            {
                if(_channelApi != null) return _channelApi;
                lock(Lock)
                {
                    return _channelApi = new ChannelApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public IEntityApi EntityApi
        {
            get
            {
                if(_entityApi != null) return _entityApi;
                lock(Lock)
                {
                    return _entityApi = new EntityApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public ILinkApi LinkApi
        {
            get
            {
                if(_entityApi != null) return _linkApi;
                lock(Lock)
                {
                    return _linkApi = new LinkApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public IMediaApi MediaApi
        {
            get
            {
                if(_mediaApi != null) return _mediaApi;
                lock(Lock)
                {
                    return _mediaApi = new MediaApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public IModelApi ModelApi
        {
            get 
            {
                if(_modelApi != null) return _modelApi;
                lock(Lock)
                {
                    return _modelApi = new ModelApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public IQueryApi QueryApi
        {
            get 
            {
                if(_queryApi != null) return _queryApi;
                lock(Lock)
                {
                    return _queryApi = new QueryApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public ISyndicateApi SyndicateApi
        {
            get
            {
                if(_syndicateApi != null) return _syndicateApi;
                lock(Lock)
                {
                    return _syndicateApi = new SyndicateApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public ISystemApi SystemApi
        {
            get
            {
                if(_systemApi != null) return _systemApi;
                lock(Lock)
                {
                    return _systemApi = new SystemApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        public IWorkareaApi WorkareaApi
        {
            get
            {
                if(_workareaApi != null) return _workareaApi;
                lock(Lock)
                {
                    return _workareaApi = new WorkareaApi(_serializer, ApiClient, _configuration);
                }
            }
        }

        private IApiClient ApiClient
        {
            get
            {
                if(_apiClient != null) return _apiClient;
                lock(Lock)
                {
                    return _apiClient = new ApiClient(_configuration, new RestClientFactory(_configuration.HttpClientOverride));
                }
            }
        }
    }
}