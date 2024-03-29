using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SpecificationValueModel
    /// </summary>
    [DataContract]
    public class SpecificationValueModel :  IEquatable<SpecificationValueModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationValueModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected SpecificationValueModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationValueModel" /> class.
        /// </summary>
        /// <param name="specificationFieldTypeId">specificationFieldTypeId(required).</param>
        /// <param name="value">value.</param>
        public SpecificationValueModel(string specificationFieldTypeId = default, object value = default(object))
        {
            // to ensure "specificationFieldTypeId" is required(not null)
            if(specificationFieldTypeId == null)
            {
                throw new InvalidDataException("specificationFieldTypeId is a required property for SpecificationValueModel and cannot be null");
            }
            else
            {
                SpecificationFieldTypeId = specificationFieldTypeId;
            }
            Value = value;
        }
        
        /// <summary>
        /// Gets or Sets SpecificationFieldTypeId
        /// </summary>
        [DataMember(Name="specificationFieldTypeId", EmitDefaultValue=false)]
        public string SpecificationFieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public object Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SpecificationValueModel {\n");
            sb.Append("  SpecificationFieldTypeId: ").Append(SpecificationFieldTypeId).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return Equals(input as SpecificationValueModel);
        }

        /// <summary>
        /// Returns true if SpecificationValueModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SpecificationValueModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecificationValueModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    SpecificationFieldTypeId == input.SpecificationFieldTypeId ||
                   (SpecificationFieldTypeId != null &&
                    SpecificationFieldTypeId.Equals(input.SpecificationFieldTypeId))
                ) && 
               (
                    Value == input.Value ||
                   (Value != null &&
                    Value.Equals(input.Value))
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
                if(SpecificationFieldTypeId != null)
                    hashCode = hashCode * 59 + SpecificationFieldTypeId.GetHashCode();
                if(Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                return hashCode;
            }
        }
    }

}
