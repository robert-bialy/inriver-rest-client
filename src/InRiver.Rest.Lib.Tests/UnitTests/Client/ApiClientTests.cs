using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Services;
using NUnit.Framework;
using Moq;
using RestSharp;

namespace InRiver.Rest.Lib.Tests.UnitTests.Client
{
    [TestFixture]
    public class ApiClientTests
    {
        private ApiClient _apiClient;
        private Mock<IRestClientFactory> _restClientFactoryMock;

        [SetUp]
        public void SetUp()
        {
            var configuration = new Configuration();
            _restClientFactoryMock = new Mock<IRestClientFactory>();
            _apiClient = new ApiClient(configuration, _restClientFactoryMock.Object);
        }

        [Test]
        public void CallApi_ShouldReturnResponse()
        {
            // Arrange
            var path = "http://example.com";
            var method = Method.Get;
            var queryParams = new List<KeyValuePair<string, string>>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            var pathParams = new Dictionary<string, string>();
            var contentType = "application/json";
            var response = new RestResponse();
            var restClientMock = new Mock<IRestClient>();
            _restClientFactoryMock
                .Setup(x => x.Create(It.IsAny<RestClientOptions>()))
                .Returns(restClientMock.Object);
            restClientMock
                .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(response);
            _restClientFactoryMock
                .Setup(x => x.Create(It.IsAny<RestClientOptions>()))
                .Returns(restClientMock.Object);

            // Act
            var result = _apiClient.CallApi(path, method, queryParams, null, headerParams, formParams, fileParams, pathParams, contentType);

            // Assert
            Assert.AreEqual(response, result);
        }

        [Test]
        public void CallApiAsync_ShouldReturnResponse()
        {
            // Arrange
            var path = "http://example.com";
            var method = Method.Get;
            var queryParams = new List<KeyValuePair<string, string>>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            var pathParams = new Dictionary<string, string>();
            var contentType = "application/json";
            var response = new RestResponse();

            var restClientMock = new Mock<IRestClient>();
            _restClientFactoryMock
                .Setup(x => x.Create(It.IsAny<RestClientOptions>()))
                .Returns(restClientMock.Object);

            restClientMock
                .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(response);
            _restClientFactoryMock
                .Setup(x => x.Create(It.IsAny<RestClientOptions>()))
                .Returns(restClientMock.Object);

            // Act
            var result = _apiClient.CallApiAsync(path, method, queryParams, null, headerParams, formParams, fileParams, pathParams, contentType).Result;

            // Assert
            Assert.AreEqual(response, result);
        }
    }
}
