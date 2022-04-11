using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// UrlFileModel
    /// </summary>
    [DataContract]
    public class UrlFileModel :  IEquatable<UrlFileModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlFileModel" /> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="overrideUrlFileName">overrideUrlFileName.</param>
        public UrlFileModel(string url = default(string), string overrideUrlFileName = default(string))
        {
            this.Url = url;
            this.OverrideUrlFileName = overrideUrlFileName;
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
            sb.Append("class UrlFileModel {\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UrlFileModel);
        }

        /// <summary>
        /// Returns true if UrlFileModel instances are equal
        /// </summary>
        /// <param name="input">Instance of UrlFileModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UrlFileModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.OverrideUrlFileName == input.OverrideUrlFileName ||
                    (this.OverrideUrlFileName != null &&
                    this.OverrideUrlFileName.Equals(input.OverrideUrlFileName))
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
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.OverrideUrlFileName != null)
                    hashCode = hashCode * 59 + this.OverrideUrlFileName.GetHashCode();
                return hashCode;
            }
        }
    }

}
