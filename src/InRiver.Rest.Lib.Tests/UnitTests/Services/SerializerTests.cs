using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Services;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Services
{
    internal class SerializerTests
    {
        [TestCase("42", typeof(int), 42)]
        [TestCase("\"hello\"", typeof(string), "hello")]
        [TestCase("true", typeof(bool), true)]
        public void JsonScalars_AreDecoded(string json, Type type, object expected)
        {
            Assert.That(new Serializer().Deserialize(json, type), Is.EqualTo(expected));
        }

        [Test]
        public void DynamicValues_PreserveDateStringsAndNestedObjects()
        {
            var result = (JObject)new Serializer().Deserialize("{\"date\":\"2026-01-01T00:00:00Z\",\"nested\":{\"en\":\"hello\"}}", typeof(object));
            Assert.That(result["date"]!.Type, Is.EqualTo(JTokenType.String));
            Assert.That((string?)result["nested"]!["en"], Is.EqualTo("hello"));
        }

        [Test]
        public void UntypedPlainText_IsReturnedAsText()
        {
            Assert.That(new Serializer().Deserialize("extension passed", typeof(object), "text/plain"), Is.EqualTo("extension passed"));
            Assert.Throws<ApiException>(() => new Serializer().Deserialize("invalid json", typeof(object), "application/json"));
        }
    }
}
