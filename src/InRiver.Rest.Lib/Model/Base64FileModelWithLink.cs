using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// Base64FileModelWithLink
    /// </summary>
    [DataContract]
    public class Base64FileModelWithLink :  IEquatable<Base64FileModelWithLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Base64FileModelWithLink" /> class.
        /// </summary>
        /// <param name="fileName">fileName.</param>
        /// <param name="data">data.</param>
        /// <param name="resourceLink">resourceLink.</param>
        public Base64FileModelWithLink(string fileName = default(string), string data = default(string), ResourceLinkModel resourceLink = default(ResourceLinkModel))
        {
            this.FileName = fileName;
            this.Data = data;
            this.ResourceLink = resourceLink;
        }
        
        /// <summary>
        /// Gets or Sets FileName
        /// </summary>
        [DataMember(Name="fileName", EmitDefaultValue=false)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets ResourceLink
        /// </summary>
        [DataMember(Name="resourceLink", EmitDefaultValue=false)]
        public ResourceLinkModel ResourceLink { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Base64FileModelWithLink {\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  ResourceLink: ").Append(ResourceLink).Append("\n");
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
            return this.Equals(input as Base64FileModelWithLink);
        }

        /// <summary>
        /// Returns true if Base64FileModelWithLink instances are equal
        /// </summary>
        /// <param name="input">Instance of Base64FileModelWithLink to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Base64FileModelWithLink input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FileName == input.FileName ||
                    (this.FileName != null &&
                    this.FileName.Equals(input.FileName))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.ResourceLink == input.ResourceLink ||
                    (this.ResourceLink != null &&
                    this.ResourceLink.Equals(input.ResourceLink))
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
                if (this.FileName != null)
                    hashCode = hashCode * 59 + this.FileName.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
                if (this.ResourceLink != null)
                    hashCode = hashCode * 59 + this.ResourceLink.GetHashCode();
                return hashCode;
            }
        }
    }

}
