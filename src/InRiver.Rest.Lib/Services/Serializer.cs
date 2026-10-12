using System;
using InRiver.Rest.Lib.Client;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Services
{
    internal sealed class Serializer
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            DateParseHandling = DateParseHandling.None
        };

        public object Deserialize(string content, Type type, string mediaType = null)
        {
            try
            {
                return JsonConvert.DeserializeObject(content, type, _serializerSettings);
            }
            catch(JsonException error)
            {
                // The specification leaves several extension responses untyped and permits text/plain.
                if(string.Equals(mediaType, "text/plain", StringComparison.OrdinalIgnoreCase) &&
                    (type == typeof(object) || type == typeof(string)))
                    return content;
                throw new ApiException(500, error.Message, content);
            }
        }

        public string Serialize(object obj)
        {
            try
            {
                return obj == null ? null : JsonConvert.SerializeObject(obj);
            }
            catch(JsonException error)
            {
                throw new ApiException(500, error.Message);
            }
        }
    }
}
