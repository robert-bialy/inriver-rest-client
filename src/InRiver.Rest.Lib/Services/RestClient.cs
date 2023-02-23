using RestSharp;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace InRiver.Rest.Lib.Services
{
    public interface IRestClient
    {
        Task<RestResponse> ExecuteAsync(RestRequest request, CancellationToken cancellationToken = default);
    } 

    internal sealed class RestClient : IRestClient
    {
        private readonly RestSharp.RestClient _restClient;

        public RestClient(RestSharp.RestClient restClient)
        {
            _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request, CancellationToken cancellationToken = default)
        {
            return await _restClient.ExecuteAsync(request, cancellationToken);
        }
    }
}
