using InRiver.Rest.Lib.Client;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests
{
    [TestFixture]
    public class InRiverRestClientTests
    {
        [TestCase("", "http://basepath", true)]
        [TestCase(null, "http://basepath", true)]
        [TestCase("apiKey", null, true)]
        [TestCase("apiKey", "", true)]
        [TestCase("apiKey", "http://basepath", false)]
        public void InRiverRestClient_ConstructorValidation_ThrowsException(string apiKey, string basePath, bool shouldThrow)
        {
            Action sut =() => { var x = new InRiverRestClient(apiKey, basePath); };

            if(shouldThrow)
            {
                Assert.That(() => sut(), Throws.InstanceOf<InvalidDataException>());
            }
            else
            {
                Assert.That(() => sut(), Throws.Nothing);
            }
        }

        [TestCase("", "http://basepath", true)]
        [TestCase(null, "http://basepath", true)]
        [TestCase("apiKey", null, true)]
        [TestCase("apiKey", "", true)]
        [TestCase("apiKey", "http://basepath", false)]
        public void InRiverRestClient_ConstructorWithConfigurationValidation_ThrowsException(string apiKey, string basePath, bool shouldThrow)
        {
            Action sut =() => { var x = new InRiverRestClient(e =>
            {
                e.BasePath = basePath;
                e.AddDefaultHeader("X-inRiver-APIKey", apiKey);
            }); };

            if(shouldThrow)
            {
                Assert.That(() => sut(), Throws.InstanceOf<InvalidDataException>());
            }
            else
            {
                Assert.That(() => sut(), Throws.Nothing);
            }
        }

        [TestCase("", "http://basepath", true)]
        [TestCase(null, "http://basepath", true)]
        [TestCase("apiKey", null, true)]
        [TestCase("apiKey", "", true)]
        [TestCase("apiKey", "http://basepath", false)]
        public void InRiverRestClient_ConstructorWithHttpClientValidation_ThrowsException(string apiKey, string basePath, bool shouldThrow)
        {
            Action sut =() => {
                var x = new InRiverRestClient(apiKey, basePath, new HttpClient());
            };

            if(shouldThrow)
            {
                Assert.That(() => sut(), Throws.InstanceOf<InvalidDataException>());
            }
            else
            {
                Assert.That(() => sut(), Throws.Nothing);
            }
        }

        [TestCase("", "http://basepath", true)]
        [TestCase(null, "http://basepath", true)]
        [TestCase("apiKey", null, true)]
        [TestCase("apiKey", "", true)]
        [TestCase("apiKey", "http://basepath", false)]
        public void InRiverRestClient_ConstructorWithBasePathAndConfiguration_ThrowsException(string apiKey, string basePath, bool shouldThrow)
        {
            Action sut =() => {
                var x = new InRiverRestClient(apiKey, basePath, e =>
                {
                    e.BasePath = basePath;
                    e.AddDefaultHeader("X-inRiver-APIKey", apiKey);
                });
            };

            if(shouldThrow)
            {
                Assert.That(() => sut(), Throws.InstanceOf<InvalidDataException>());
            }
            else
            {
                Assert.That(() => sut(), Throws.Nothing);
            }
        }
    }
}
