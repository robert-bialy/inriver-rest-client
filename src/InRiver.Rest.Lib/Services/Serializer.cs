using System;
using InRiver.Rest.Lib.Client;
using Newtonsoft.Json;
using RestSharp;

namespace InRiver.Rest.Lib.Services
{
    internal interface ISerializer
    {
        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">object type.</param>
        /// <returns>object representation of the JSON string.</returns>
        object Deserialize(RestResponse response, Type type);

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>JSON string.</returns>
        string Serialize(object obj);
    }

    internal sealed class Serializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">object type.</param>
        /// <returns>object representation of the JSON string.</returns>
        public object Deserialize(RestResponse response, Type type)
        {
            var headers = response.Headers;
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(response.Content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>JSON string.</returns>
        public string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }


        /// <summary>
        /// Dynamically cast the object into target type.
        /// </summary>
        /// <param name="fromobject">object to be casted</param>
        /// <param name="toobject">Target type</param>
        /// <returns>Casted object</returns>
        private static dynamic ConvertType(dynamic fromobject, Type toobject)
        {
            return Convert.ChangeType(fromobject, toobject);
        }
    }
}
