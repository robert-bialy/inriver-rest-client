using InRiver.Rest.Lib.Services;
using NUnit.Framework;
using RestSharp;

namespace InRiver.Rest.Lib.Tests.UnitTests.Services
{
    internal class SerializerTests
    {
        private Serializer _serializer = null!;

        [SetUp]
        public void Setup()
        {
            _serializer = new Serializer();
        }

        [Test]
        public void Deserialize_WithByteType_ReturnsRawBytes()
        {
            // Arrange
            byte[] expected = { 1, 2, 3 };
            var response = new RestResponse { RawBytes = expected };
            var type = typeof(byte[]);

            // Act
            var result = _serializer.Deserialize(response, type);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
