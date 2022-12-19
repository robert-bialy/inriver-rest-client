using System.Net;
using FluentAssertions;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using JustEat.HttpClientInterception;
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
            var options = new HttpClientInterceptorOptions();
            var builder = new HttpRequestInterceptionBuilder();
            builder
                .Requests()
                .ForPost()
                .ForHttps()
                .ForHost(host)
                .ForPath("/api/v1.0.0/entities:createnew")
                .Responds()
                .WithStatus(HttpStatusCode.Created)
                .RegisterWith(options);
            using var httpClient = options.CreateHttpClient();
            var client = new InRiverRestClient(apiKey, $"https://{host}", httpClient);

            //Act
            var response = await client.EntityApi.CreateEntityAsyncWithHttpInfo(new EntityCreationModel("Item"));

            //Assert
            response.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }
    }
}