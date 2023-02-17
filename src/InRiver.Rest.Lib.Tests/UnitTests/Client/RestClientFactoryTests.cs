using InRiver.Rest.Lib.Client;
using NUnit.Framework;
using RestSharp;
using RestClient = InRiver.Rest.Lib.Services.RestClient;

namespace InRiver.Rest.Lib.Tests.UnitTests.Client
{
    [TestFixture]
    public class RestClientFactoryTests
    {
        [Test]
        public void Create_WithoutHttpClientOverride_ReturnsSameRestClientInstanceOnSubsequentCalls()
        {
            // Arrange
            var sut = new RestClientFactory();
            var configuration = new RestClientOptions();

            // Act
            var client1 = sut.Create(configuration);
            var client2 = sut.Create(configuration);

            // Assert
            Assert.AreSame(client1, client2);
        }

        [Test]
        public void Create_WithHttpClientOverride_ReturnsSameRestClientInstanceOnSubsequentCalls()
        {
            // Arrange
            var httpClient = new HttpClient();
            var sut = new RestClientFactory(httpClient);
            var configuration = new RestClientOptions();

            // Act
            var client1 = sut.Create(configuration);
            var client2 = sut.Create(configuration);

            // Assert
            Assert.AreSame(client1, client2);
        }
    }
}