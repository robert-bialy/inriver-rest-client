using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// UrlFileModelWithLink
    /// </summary>
    [DataContract]
    public class UrlFileModelWithLink :  IEquatable<UrlFileModelWithLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlFileModelWithLink" /> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="overrideUrlFileName">overrideUrlFileName.</param>
        /// <param name="resourceLink">resourceLink.</param>
        public UrlFileModelWithLink(string url = default, string overrideUrlFileName = default, ResourceLinkModel resourceLink = default(ResourceLinkModel))
        {
            Url = url;
            OverrideUrlFileName = overrideUrlFileName;
            ResourceLink = resourceLink;
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
            sb.Append("class UrlFileModelWithLink {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  OverrideUrlFileName: ").Append(OverrideUrlFileName).Append("\n");
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
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as UrlFileModelWithLink);
        }

        /// <summary>
        /// Returns true if UrlFileModelWithLink instances are equal
        /// </summary>
        /// <param name="input">Instance of UrlFileModelWithLink to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UrlFileModelWithLink input)
        {
            if(input == null)
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
                ) && 
               (
                    ResourceLink == input.ResourceLink ||
                   (ResourceLink != null &&
                    ResourceLink.Equals(input.ResourceLink))
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
                if(Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                if(OverrideUrlFileName != null)
                    hashCode = hashCode * 59 + OverrideUrlFileName.GetHashCode();
                if(ResourceLink != null)
                    hashCode = hashCode * 59 + ResourceLink.GetHashCode();
                return hashCode;
            }
        }
    }

}
