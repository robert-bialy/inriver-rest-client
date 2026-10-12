using System.Net;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using InRiver.Rest.Lib.Tests.UnitTests.Client;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.FeatureTests.HttpOverrideTests
{
    [TestFixture]
    public class HttpOverrideTests
    {
        [Test]
        public async Task HttpClientIsOverwritten_SendsHttpRequestSuccessfully()
        {
            //Arrange
            const string host = "apieuw.productmarketingcloud.com";
            const string apiKey = "11";
            using var httpClient = new HttpClient(new ApiClientTests.Handler((request, _) =>
            {
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
                Assert.That(request.RequestUri, Is.EqualTo(new Uri($"https://{host}/api/v1.0.1/entities:createnew")));
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Created));
            }));
            var client = new InRiverRestClient(apiKey, $"https://{host}", httpClient);

            //Act
            var response = await client.EntityApi.CreateEntityAsyncWithHttpInfo(new EntityCreationModel("Item"));

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
        }

        [Test]
        public async Task HttpClientIsOverwritten_SendsConcurrentRequests()
        {
            //Arrange
            const string host = "apieuw.productmarketingcloud.com";
            const string apiKey = "11";
            using var httpClient = new HttpClient(new ApiClientTests.Handler((request, _) =>
            {
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
                Assert.That(request.RequestUri, Is.EqualTo(new Uri($"https://{host}/api/v1.0.1/entities:createnew")));
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Created));
            }));
            var client = new InRiverRestClient(apiKey, $"https://{host}", httpClient);

            //Act
            var request1 = client.EntityApi.CreateEntityAsyncWithHttpInfo(new EntityCreationModel("Item"));
            var request2 = client.EntityApi.CreateEntityAsyncWithHttpInfo(new EntityCreationModel("Item"));
            await Task.WhenAll(request1, request2);

            //Assert
            Assert.That(request1.Result.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
            Assert.That(request2.Result.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
        }
    }
}
