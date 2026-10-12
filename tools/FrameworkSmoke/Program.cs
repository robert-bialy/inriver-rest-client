using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;

internal static class Program
{
    private static async Task Main()
    {
        using(var http = new HttpClient(new Handler()))
        {
            using(var client = new InRiverRestClient("smoke-key", "https://example.test", http))
            {
                var result = await client.EntityApi.SetFieldSetAsync(17, new SetFieldSetModel(null));
                if(result.Id != 17) throw new Exception("Response did not deserialize on .NET Framework.");
                using(var cancellation = new CancellationTokenSource())
                {
                    cancellation.Cancel();
                    try
                    {
                        await client.ChannelApi.GetChannelMessageCountAsync(cancellation.Token);
                        throw new Exception("Cancellation was not propagated.");
                    }
                    catch(OperationCanceledException) { }
                }
            }
            // Disposing the library must leave the injected client usable.
            using(var response = await http.GetAsync("https://example.test"))
                if(response.StatusCode != HttpStatusCode.OK) throw new Exception("Injected client is unusable.");
        }
        Console.WriteLine(".NET Framework 4.7.2 consumer smoke check passed.");
    }

    private sealed class Handler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.Method == HttpMethod.Put)
            {
                if(request.RequestUri.AbsolutePath != "/api/v1.0.0/entities/17/fieldset") throw new Exception("Incorrect path.");
                if(!request.Headers.Contains("X-inRiver-APIKey")) throw new Exception("Missing authentication.");
                if(await request.Content.ReadAsStringAsync() != "{\"fieldSetId\":null}") throw new Exception("Null clearing was lost.");
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"id\":17}") };
        }
    }
}
