using System.Net;
using InRiver.Rest.Lib.Client;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Client
{
    public class HttpClientLifetimeTests
    {
        [Test]
        public async Task DisposingClient_DoesNotDisposeInjectedHttpClient()
        {
            var handler = new ApiClientTests.Handler((_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("0") }));
            using var http = new HttpClient(handler);
            var client = new InRiverRestClient("key", "https://example.test", http);
            await client.ChannelApi.GetChannelMessageCountAsync();
            client.Dispose();
            client.Dispose();
            Assert.That(handler.Disposed, Is.False);
            using var response = await http.GetAsync("https://example.test");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.Throws<ObjectDisposedException>(() => _ = client.ChannelApi);
        }

        [Test]
        public void ApiProperties_ReturnTheSameInstanceUnderConcurrency()
        {
            using var client = new InRiverRestClient("key");
            foreach(var property in typeof(IinRiverClient).GetProperties())
            {
                var instances = new object[100];
                Parallel.For(0, instances.Length, i => instances[i] = property.GetValue(client)!);
                Assert.That(instances.All(x => ReferenceEquals(x, instances[0])), Is.True, property.Name);
            }
        }
    }
}
