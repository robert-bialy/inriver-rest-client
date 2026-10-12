using System.Reflection;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Models
{
    [TestFixture]
    internal class SerializationTests
    {
        private static IEnumerable<Type> TypesToTest()
        {
            var modelTypes = Assembly
                .Load("InRiver.Rest.Lib")
                .GetTypes()
                .Where(t => t.IsPublic && t.IsClass && t.Namespace != null && t.Namespace.StartsWith("InRiver.Rest.Lib.Model"));

            return modelTypes;
        }

        [TestCaseSource(nameof(TypesToTest))]
        public void AllModels_ShouldHaveDataContractAttribute(Type type)
        {
            Assert.That(Attribute.IsDefined(type, typeof(DataContractAttribute)), Is.True);
        }
    }
}
