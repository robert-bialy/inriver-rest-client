using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// ResourceLinkModel
    /// </summary>
    [DataContract]
    public class ResourceLinkModel :  IEquatable<ResourceLinkModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLinkModel" /> class.
        /// </summary>
        /// <param name="sourceEntityId">sourceEntityId.</param>
        /// <param name="linkTypeId">linkTypeId.</param>
        public ResourceLinkModel(int? sourceEntityId = default(int?), string linkTypeId = default)
        {
            SourceEntityId = sourceEntityId;
            LinkTypeId = linkTypeId;
        }
        
        /// <summary>
        /// Gets or Sets SourceEntityId
        /// </summary>
        [DataMember(Name="sourceEntityId", EmitDefaultValue=false)]
        public int? SourceEntityId { get; set; }

        /// <summary>
        /// Gets or Sets LinkTypeId
        /// </summary>
        [DataMember(Name="linkTypeId", EmitDefaultValue=false)]
        public string LinkTypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResourceLinkModel {\n");
            sb.Append("  SourceEntityId: ").Append(SourceEntityId).Append("\n");
            sb.Append("  LinkTypeId: ").Append(LinkTypeId).Append("\n");
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
            return Equals(input as ResourceLinkModel);
        }

        /// <summary>
        /// Returns true if ResourceLinkModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourceLinkModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourceLinkModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    SourceEntityId == input.SourceEntityId ||
                   (SourceEntityId != null &&
                    SourceEntityId.Equals(input.SourceEntityId))
                ) && 
               (
                    LinkTypeId == input.LinkTypeId ||
                   (LinkTypeId != null &&
                    LinkTypeId.Equals(input.LinkTypeId))
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
                if(SourceEntityId != null)
                    hashCode = hashCode * 59 + SourceEntityId.GetHashCode();
                if(LinkTypeId != null)
                    hashCode = hashCode * 59 + LinkTypeId.GetHashCode();
                return hashCode;
            }
        }
    }

}
