using System;
using System.Collections.Generic;
using InRiver.Rest.Lib.Api;

namespace InRiver.Rest.Lib.Client
{
    public class InRiverRestClient : IinRiverClient
    {
        private readonly string _basePath;
        private readonly string _apiKey;
        private readonly Configuration _configuration;

        public InRiverRestClient(string apiKey, string basePath = "https://apieuw.productmarketingcloud.com")
        {
            _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _configuration = new Configuration
            {
                BasePath = _basePath,
                DefaultHeader = new Dictionary<string, string>
                {
                    { "X-inRiver-APIKey", _apiKey }
                }
            };
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