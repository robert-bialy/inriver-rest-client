using FluentAssertions;
using InRiver.Rest.Lib.Helpers;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Helpers
{
    [TestFixture]
    public class HttpHelpersTests
    {
        [Test]
        public void SelectHeaderContentType_IsEmpty_ReturnsApplicationJson()
        {
            HttpHelpers.SelectHeaderContentType(Array.Empty<string>()).Should().Be("application/json");
        }

        [Test]
        public void SelectHeaderContentType_IsNotMime_ReturnsFirst()
        {
            HttpHelpers.SelectHeaderContentType(new[] { "application/bson" }).Should().Be("application/bson");
        }

        [Test]
        public void SelectHeaderContentType_HasMimeTypes_ReturnsFirstMimeTypes()
        {
            HttpHelpers.SelectHeaderContentType(new[] { "application/javascript", "application/json" }).Should().Be("application/json");
        }

        [Test]
        public void ReturnsNullIfAcceptsArrayIsEmpty()
        {
            // Arrange
            string[] accepts = Array.Empty<string>();

            // Act
            string result = HttpHelpers.SelectHeaderAccept(accepts);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnsJsonIfAcceptsArrayContainsJson()
        {
            // Arrange
            string[] accepts = { "application/json" };

            // Act
            string result = HttpHelpers.SelectHeaderAccept(accepts);

            // Assert
            Assert.AreEqual("application/json", result);
        }

        [Test]
        public void ReturnsJoinedStringIfAcceptsArrayDoesNotContainJson()
        {
            // Arrange
            string[] accepts = { "text/html", "application/xml" };

            // Act
            string result = HttpHelpers.SelectHeaderAccept(accepts);

            // Assert
            Assert.AreEqual("text/html,application/xml", result);
        }

        [Test]
        public void ReturnsJsonIfAcceptsArrayContainsJsonWithDifferentCasing()
        {
            // Arrange
            string[] accepts = { "AppliCation/JSON" };

            // Act
            string result = HttpHelpers.SelectHeaderAccept(accepts);

            // Assert
            Assert.AreEqual("application/json", result);
        }
    }
}
