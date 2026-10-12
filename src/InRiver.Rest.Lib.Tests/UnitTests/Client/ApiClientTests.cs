using System.Net;
using System.Net.Http;
using System.Text;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Client
{
    [TestFixture]
    public class ApiClientTests
    {
        internal sealed class Handler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _send;
            public bool Disposed { get; private set; }
            public Handler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) => _send = send;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token) => _send(request, token);
            protected override void Dispose(bool disposing) { Disposed = true; base.Dispose(disposing); }
        }

        [TestCase(400)]
        [TestCase(403)]
        [TestCase(404)]
        [TestCase(409)]
        [TestCase(429)]
        [TestCase(500)]
        public void HttpErrors_PreserveStatusAndProblemBody(int status)
        {
            const string body = "{\"title\":\"Failed\",\"detail\":\"Example detail\",\"vendorCode\":42}";
            using var http = new HttpClient(new Handler((_, _) => Task.FromResult(new HttpResponseMessage((HttpStatusCode)status)
            { Content = new StringContent(body, Encoding.UTF8, "application/problem+json") })));
            using var client = new InRiverRestClient("key", "https://example.test", http);
            var error = Assert.ThrowsAsync<ApiException>(() => client.ChannelApi.GetChannelMessageCountAsync());
            Assert.That(error!.ErrorCode, Is.EqualTo(status));
            Assert.That((string)error.ErrorContent, Is.EqualTo(body));
        }

        [Test]
        public async Task Requests_HavePerClientAuthenticationAndResponseHeaders()
        {
            using var http = new HttpClient(new Handler((request, _) =>
            {
                Assert.That(request.Headers.GetValues("X-inRiver-APIKey").Single(), Is.EqualTo("key"));
                Assert.That(request.Headers.UserAgent.ToString(), Is.EqualTo("Example/2.0"));
                Assert.That(request.Headers.Accept.ToString(), Is.EqualTo("application/json"));
                var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("5", Encoding.UTF8, "application/json") };
                response.Headers.Add("X-Trace", "trace");
                return Task.FromResult(response);
            }));
            using var client = new InRiverRestClient("key", "https://example.test", http, c => c.UserAgent = "Example/2.0");
            var response = await client.ChannelApi.GetChannelMessageCountAsyncWithHttpInfo();
            Assert.That(response.Data, Is.EqualTo(5));
            Assert.That(response.Headers["x-trace"], Is.EqualTo("trace"));
            Assert.That(response.Headers["Content-Type"], Does.StartWith("application/json"));
            Assert.That(http.DefaultRequestHeaders.Contains("X-inRiver-APIKey"), Is.False);
        }

        [Test]
        public void Cancellation_ReachesTheHandlerWithoutBecomingApiException()
        {
            using var cancellation = new CancellationTokenSource();
            using var http = new HttpClient(new Handler(async (_, token) =>
            {
                cancellation.Cancel();
                await Task.Delay(Timeout.Infinite, token);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }));
            using var client = new InRiverRestClient("key", "https://example.test", http);
            Assert.That(async () => await client.ChannelApi.GetChannelMessageCountAsync(cancellation.Token),
                Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void ConfiguredTimeout_CancelsRequestWithoutChangingInjectedClient()
        {
            using var http = new HttpClient(new Handler(async (_, token) =>
            {
                await Task.Delay(Timeout.Infinite, token);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }));
            var originalTimeout = http.Timeout;
            using var client = new InRiverRestClient("key", "https://example.test", http, c => c.Timeout = 20);
            Assert.That(async () => await client.ChannelApi.GetChannelMessageCountAsync(), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(http.Timeout, Is.EqualTo(originalTimeout));
        }

        [Test]
        public void NetworkError_PreservesTheExistingZeroStatusConvention()
        {
            using var http = new HttpClient(new Handler((_, _) => throw new HttpRequestException("offline")));
            using var client = new InRiverRestClient("key", "https://example.test", http);
            var error = Assert.ThrowsAsync<ApiException>(() => client.ChannelApi.GetChannelMessageCountAsync());
            Assert.That(error!.ErrorCode, Is.Zero);
        }

        [Test]
        public async Task OptionalQueryValues_DistinguishOmittedFromFalse()
        {
            var queries = new List<string>();
            using var http = new HttpClient(new Handler((request, _) =>
            {
                queries.Add(request.RequestUri!.Query);
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("[]") });
            }));
            using var client = new InRiverRestClient("key", "https://example.test", http);
            await client.ChannelApi.GetChannelEntitiesAsync("Product");
            await client.ChannelApi.GetChannelEntitiesAsync("Product", orphaned: false, linkRuleEnabled: false);
            Assert.That(queries, Is.EqualTo(new[] { "", "?orphaned=false&linkRuleEnabled=false" }));
        }

        [Test]
        public async Task HtmlTemplateArrayQuery_UsesRepeatedKeys()
        {
            using var http = new HttpClient(new Handler((request, _) =>
            {
                Assert.That(request.RequestUri!.Query, Is.EqualTo("?contentStoreHtmlTemplateTypes=EditTemplate&contentStoreHtmlTemplateTypes=PortalTemplate&includeData=false"));
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("[]") });
            }));
            using var client = new InRiverRestClient("key", "https://example.test", http);
            await client.HtmlTemplateApi.GetHtmlTemplatesByTypesAsync(new List<string> { "EditTemplate", "PortalTemplate" }, false);
        }
    }
}
