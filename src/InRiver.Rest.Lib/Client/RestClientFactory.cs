using RestSharp;
using System.Net.Http;

namespace InRiver.Rest.Lib.Client
{
    internal interface IRestClientFactory
    {
        RestClient Create(RestClientOptions configuration);
    }

    internal sealed class RestClientFactory : IRestClientFactory
    {
        private static readonly object Lock = new object();

        private readonly HttpClient _httpClientOverride;
        private RestClient _restClient;

        public RestClientFactory(HttpClient httpClientOverride = null)
        {
            _httpClientOverride = httpClientOverride;
        }

        public RestClient Create(RestClientOptions configuration)
        {
            if (_httpClientOverride == null)
                return new RestClient(configuration);

            if (_restClient == null)
            {
                lock (Lock)
                {
                    if (_restClient == null)
                    {
                        _restClient = new RestClient(_httpClientOverride, configuration);
                    }
                }
            }

            return _restClient;
        }
    }
}