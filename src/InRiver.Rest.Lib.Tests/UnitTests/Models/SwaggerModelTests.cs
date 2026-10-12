using InRiver.Rest.Lib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Models
{
    public class SwaggerModelTests
    {
        [Test]
        public void ClearOperations_EmitNullWhilePartialUpdatesOmitNull()
        {
            Assert.That(JObject.Parse(new FieldValueModel("Name", null).ToJson()).ContainsKey("value"), Is.True);
            Assert.That(JObject.Parse(new SetFieldSetModel(null).ToJson()).ContainsKey("fieldSetId"), Is.True);
            Assert.That(JObject.Parse(new SetSpecificationTemplateModel(null).ToJson()).ContainsKey("specificationId"), Is.True);
            Assert.That(JObject.Parse(new ChannelSnapshotTagModel(17, null).ToJson()).ContainsKey("snapshotTag"), Is.True);
            var specification = JObject.Parse(new SpecificationUpsertModel(null, null).ToJson());
            Assert.That(specification.ContainsKey("specification"), Is.True);
            Assert.That(specification.ContainsKey("specificationValues"), Is.True);
            var update = new LanguageRoleUpdateModel("Editor");
            Assert.That(JObject.Parse(update.ToJson()).ContainsKey("languages"), Is.False);
            update.Languages = new List<LanguageRoleLanguageInputModel>();
            Assert.That(JObject.Parse(update.ToJson())["languages"], Is.Empty);
        }

        [Test]
        public void ExplicitFalseAndZero_AreNotOmitted()
        {
            var field = new FieldTypeModelV2("ProductName", isMandatory: false, index: 0);
            var json = JObject.Parse(field.ToJson());
            Assert.That((bool?)json["isMandatory"], Is.False);
            Assert.That((int?)json["index"], Is.Zero);
        }

        [Test]
        public void CountOnlyQuery_AllowsMissingEntityIds()
        {
            var query = new QueryModel(objects: "count", dataCriteriaOperator: "Or");
            var json = JObject.Parse(query.ToJson());
            Assert.That((string?)json["objects"], Is.EqualTo("count"));
            var result = JsonConvert.DeserializeObject<EntityListModel>("{\"count\":123}")!;
            Assert.That(result.Count, Is.EqualTo(123));
            Assert.That(result.EntityIds, Is.Null);
        }

        [Test]
        public void SnapshotReadOnlyFields_DeserializeAndParticipateInEquality()
        {
            const string json = "{\"id\":1,\"entityId\":2,\"fields\":[{\"fieldTypeId\":\"Name\",\"localizedRevisions\":[{\"language\":\"en\",\"revision\":3}]}]}";
            var first = JsonConvert.DeserializeObject<EntitySnapshotModel>(json)!;
            var second = JsonConvert.DeserializeObject<EntitySnapshotModel>(json)!;
            Assert.That(first.Fields[0].LocalizedRevisions[0].Language, Is.EqualTo("en"));
            Assert.That(first.Equals(second), Is.True);
            Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
            second.Fields[0].LocalizedRevisions[0].Revision = 4;
            Assert.That(first.Equals(second), Is.False);
        }

        [Test]
        public void ProblemDetails_PreservesVendorProperties()
        {
            var problem = JsonConvert.DeserializeObject<ProblemDetails>("{\"title\":\"Conflict\",\"traceId\":\"123\"}")!;
            Assert.That((string?)problem.AdditionalProperties["traceId"], Is.EqualTo("123"));
            Assert.That((string?)JObject.Parse(problem.ToJson())["traceId"], Is.EqualTo("123"));
        }
    }
}
