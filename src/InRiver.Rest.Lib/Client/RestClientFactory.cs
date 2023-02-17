using RestSharp;
using System.Net.Http;
using System.Runtime.CompilerServices;
using InRiver.Rest.Lib.Services;
using RestClient = RestSharp.RestClient;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace InRiver.Rest.Lib.Client
{
    internal interface IRestClientFactory
    {
        IRestClient Create(RestClientOptions configuration);
    }

    internal sealed class RestClientFactory : IRestClientFactory
    {
        private static readonly object Lock = new object();

        private readonly HttpClient _httpClientOverride;
        private IRestClient _restClient;

        public RestClientFactory(HttpClient httpClientOverride = null)
        {
            _httpClientOverride = httpClientOverride;
        }

        public IRestClient Create(RestClientOptions configuration)
        {
            if (_restClient != null) return _restClient;
            lock (Lock)
            {
                _restClient = _httpClientOverride == null
                    ? new Services.RestClient(new RestClient(configuration))
                    : new Services.RestClient(new RestClient(_httpClientOverride, configuration));
            }

            return _restClient;
        }
    }
}