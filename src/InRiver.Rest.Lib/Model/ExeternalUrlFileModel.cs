using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// ExeternalUrlFileModel
    /// </summary>
    [DataContract]
    public class ExeternalUrlFileModel :  IEquatable<ExeternalUrlFileModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExeternalUrlFileModel" /> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="overrideUrlFileName">overrideUrlFileName.</param>
        public ExeternalUrlFileModel(string url = default, string overrideUrlFileName = default)
        {
            Url = url;
            OverrideUrlFileName = overrideUrlFileName;
        }
        
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets OverrideUrlFileName
        /// </summary>
        [DataMember(Name="overrideUrlFileName", EmitDefaultValue=false)]
        public string OverrideUrlFileName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExeternalUrlFileModel {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  OverrideUrlFileName: ").Append(OverrideUrlFileName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as ExeternalUrlFileModel);
        }

        /// <summary>
        /// Returns true if ExeternalUrlFileModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ExeternalUrlFileModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExeternalUrlFileModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    Url == input.Url ||
                    (Url != null &&
                    Url.Equals(input.Url))
                ) && 
                (
                    OverrideUrlFileName == input.OverrideUrlFileName ||
                    (OverrideUrlFileName != null &&
                    OverrideUrlFileName.Equals(input.OverrideUrlFileName))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                if (OverrideUrlFileName != null)
                    hashCode = hashCode * 59 + OverrideUrlFileName.GetHashCode();
                return hashCode;
            }
        }
    }

}
