using System.Net;
using System.Globalization;
using System.Text;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Tests.UnitTests.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.FeatureTests.HttpOverrideTests
{
    public class SwaggerContractTests
    {
        private static JObject Spec => JObject.Parse(File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "swagger.json")));
        private static JArray Operations => JArray.Parse(File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "operations.json")));

        public static IEnumerable<TestCaseData> Endpoints()
        {
            foreach(var op in Operations.Cast<JObject>())
                foreach(var variant in new[] { "", "WithHttpInfo", "Async", "AsyncWithHttpInfo" })
                    yield return new TestCaseData((string)op["tag"]!, (string)op["method"]!, (string)op["verb"]!, (string)op["path"]!, variant)
                        .SetName($"{op["tag"]}.{op["method"]}{variant} ({op["verb"]} {op["path"]})");
        }

        [Test]
        public void OperationInventory_CoversEverySwaggerOperationExactlyOnce()
        {
            var expected = ((JObject)Spec["paths"]!).Properties().SelectMany(p => ((JObject)p.Value).Properties().Select(m => m.Name.ToUpperInvariant() + " " + p.Name));
            var actual = Operations.Select(o => o["verb"] + " " + o["path"]);
            Assert.That(actual, Is.EquivalentTo(expected));
            Assert.That(actual.Distinct().Count(), Is.EqualTo(actual.Count()));
        }

        [TestCaseSource(nameof(Endpoints))]
        public async Task Endpoint_UsesSwaggerMethodPathParametersBodyAndResponse(string tag, string method, string verb, string path, string variant)
        {
            var spec = Spec;
            var operation = spec["paths"]![path]![verb.ToLowerInvariant()]!;
            var response = ((JObject)operation["responses"]!).Properties().Single(p => p.Name.StartsWith("2"));
            var responseSchema = response.Value["content"]?["application/json"]?["schema"];
            var responseJson = responseSchema == null ? "" : Sample(responseSchema, spec).ToString(Formatting.None);
            var expectedPath = path;
            var expectedQuery = new List<string>();
            var supplied = new Dictionary<string, JToken>();
            foreach(var parameter in operation["parameters"] ?? new JArray())
            {
                var name = (string)parameter["name"]!;
                var sample = Sample(parameter["schema"]!, spec);
                supplied[name] = sample;
                var wireValue = (string?)parameter["schema"]!["format"] == "date-time"
                    ? DateTimeOffset.Parse((string)sample!, CultureInfo.InvariantCulture).ToString("o", CultureInfo.InvariantCulture)
                    : Wire(sample);
                if((string?)parameter["in"] == "path")
                    expectedPath = expectedPath.Replace("{" + name + "}", Uri.EscapeDataString(wireValue));
                else
                    foreach(var value in sample is JArray array ? array.Select(Wire).ToArray() : new[] { wireValue })
                        expectedQuery.Add(Uri.EscapeDataString(name) + "=" + Uri.EscapeDataString(value));
            }
            var requestSchema = operation["requestBody"]?["content"]?["application/json"]?["schema"];
            var requestJson = requestSchema == null ? null : Sample(requestSchema, spec);
            var calls = 0;
            using var http = new HttpClient(new ApiClientTests.Handler(async (request, _) =>
            {
                calls++;
                Assert.That(request.Method.Method, Is.EqualTo(verb));
                Assert.That(request.RequestUri!.AbsolutePath, Is.EqualTo(expectedPath));
                Assert.That(request.RequestUri.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries), Is.EquivalentTo(expectedQuery));
                Assert.That(request.Headers.GetValues("X-inRiver-APIKey").Single(), Is.EqualTo("contract-key"));
                if(requestJson != null)
                {
                    Assert.That(request.Content!.Headers.ContentType!.MediaType, Is.EqualTo("application/json"));
                    var sent = JToken.Parse(await request.Content.ReadAsStringAsync());
                    Assert.That(JToken.DeepEquals(sent, JToken.Parse(requestJson.ToString())), Is.True, $"Request: {sent}; expected: {requestJson}");
                }
                else
                    Assert.That(request.Content, Is.Null);
                return new HttpResponseMessage((HttpStatusCode)int.Parse(response.Name))
                { Content = new StringContent(responseJson, Encoding.UTF8, "application/json") };
            }));
            using var client = new InRiverRestClient("contract-key", "https://example.test", http);
            var api = typeof(IinRiverClient).GetProperty(tag + "Api")!.GetValue(client)!;
            var methodName = tag == "Entity" && method == "UploadMediaFromUrl" && variant == "WithHttpInfo"
                ? "EntityUploadMediaFromUrlWithHttpInfo" : method + variant;
            var entry = api.GetType().GetMethod(methodName)!;
            var args = entry.GetParameters().Select(p =>
            {
                if(p.ParameterType == typeof(CancellationToken)) return (object)CancellationToken.None;
                if(supplied.TryGetValue(p.Name!, out var value)) return value.ToObject(p.ParameterType);
                return requestJson!.ToObject(p.ParameterType);
            }).ToArray();
            object? result = entry.Invoke(api, args);
            if(result is Task task)
            {
                await task;
                result = entry.ReturnType.IsGenericType ? entry.ReturnType.GetProperty("Result")!.GetValue(task) : null;
            }
            Assert.That(calls, Is.EqualTo(1));
            if(variant.Contains("WithHttpInfo"))
            {
                Assert.That(result!.GetType().GetProperty("StatusCode")!.GetValue(result), Is.EqualTo(int.Parse(response.Name)));
                result = result.GetType().GetProperty("Data")!.GetValue(result);
            }
            if(responseSchema != null)
                Assert.That(JToken.DeepEquals(JToken.Parse(JsonConvert.SerializeObject(result)), JToken.Parse(responseJson)), Is.True,
                    $"Response did not round-trip as the Swagger schema: {JsonConvert.SerializeObject(result)}");
        }

        private static string Wire(JToken value) => value.Type == JTokenType.String ? (string)value! : value.ToString(Formatting.None);

        private static JToken Sample(JToken schema, JObject spec, int depth = 0)
        {
            if(schema["$ref"] != null)
                return Sample(spec["components"]!["schemas"]![schema["$ref"]!.ToString().Split('/').Last()]!, spec, depth);
            if(schema["enum"] is JArray values) return values[0].DeepClone();
            switch((string?)schema["type"])
            {
                case "integer": return new JValue(17);
                case "number": return new JValue(12.5);
                case "boolean": return new JValue(false);
                case "string": return new JValue((string?)schema["format"] switch
                {
                    "date-time" => "2026-01-02T03:04:05+02:00",
                    "uuid" => "11111111-2222-3333-4444-555555555555",
                    _ => "sample +&?é"
                });
                case "array": return depth > 2 ? new JArray() : new JArray(Sample(schema["items"]!, spec, depth + 1));
                case "object":
                    if(schema["properties"] is JObject props)
                    {
                        var obj = new JObject();
                        foreach(var p in props.Properties())
                        {
                            if(depth > 2 && (p.Value["$ref"] != null || (string?)p.Value["type"] == "object")) continue;
                            obj[p.Name] = Sample(p.Value, spec, depth + 1);
                        }
                        return obj;
                    }
                    return new JObject { ["example"] = Sample(schema["additionalProperties"] as JObject ?? new JObject(), spec, depth + 1) };
                default: return new JObject { ["en"] = "dynamic value" };
            }
        }
    }
}
