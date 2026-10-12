using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using InRiver.Rest.Lib.Client;

[assembly: InternalsVisibleTo("InRiver.Rest.Lib.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace InRiver.Rest.Lib.Helpers
{
    internal static class HttpHelpers
    {
        /// <summary>
        /// If parameter is DateTime, output in a formatted string(default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter(header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj, Configuration configuration)
        {
            if(obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return((DateTime)obj).ToString(configuration.DateTimeFormat, CultureInfo.InvariantCulture);
            else if(obj is DateTimeOffset)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return((DateTimeOffset)obj).ToString(configuration.DateTimeFormat, CultureInfo.InvariantCulture);
            else if(obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach(var param in(IList)obj)
                {
                    if(flattenedString.Length> 0)
                        flattenedString.Append(",");
                    flattenedString.Append(ParameterToString(param, configuration));
                }
                return flattenedString.ToString();
            }
            else
                return obj is bool boolean ? (boolean ? "true" : "false") : Convert.ToString(obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert params to key/value pairs. 
        /// Use collectionFormat to properly format lists and collections.
        /// </summary>
        /// <param name="name">Key name.</param>
        /// <param name="value">Value object.</param>
        /// <returns>A list of KeyValuePairs</returns>
        public static IEnumerable<KeyValuePair<string, string>> ParameterToKeyValuePairs(string collectionFormat, string name, object value, Configuration configuration)
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if(IsCollection(value) && collectionFormat == "multi")
            {
                var valueCollection = value as IEnumerable;
                parameters.AddRange(from object item in valueCollection select new KeyValuePair<string, string>(name, ParameterToString(item, configuration)));
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>(name, ParameterToString(value, configuration)));
            }

            return parameters;
        }

        /// <summary>
        /// Check if generic object is a collection.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if object is a collection type</returns>
        private static bool IsCollection(object value)
        {
            return value is IList || value is ICollection;
        }
    }
}
