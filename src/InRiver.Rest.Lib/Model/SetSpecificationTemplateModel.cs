using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SetSpecificationTemplateModel
    /// </summary>
    [DataContract]
    public class SetSpecificationTemplateModel :  IEquatable<SetSpecificationTemplateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetSpecificationTemplateModel" /> class.
        /// </summary>
        /// <param name="specificationId">specificationId.</param>
        public SetSpecificationTemplateModel(int? specificationId = default(int?))
        {
            this.SpecificationId = specificationId;
        }
        
        /// <summary>
        /// Gets or Sets SpecificationId
        /// </summary>
        [DataMember(Name="specificationId", EmitDefaultValue=false)]
        public int? SpecificationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetSpecificationTemplateModel {\n");
            sb.Append("  SpecificationId: ").Append(SpecificationId).Append("\n");
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
            return this.Equals(input as SetSpecificationTemplateModel);
        }

        /// <summary>
        /// Returns true if SetSpecificationTemplateModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SetSpecificationTemplateModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetSpecificationTemplateModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SpecificationId == input.SpecificationId ||
                    (this.SpecificationId != null &&
                    this.SpecificationId.Equals(input.SpecificationId))
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
                if (this.SpecificationId != null)
                    hashCode = hashCode * 59 + this.SpecificationId.GetHashCode();
                return hashCode;
            }
        }
    }

}
