using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FieldValueModel
    /// </summary>
    [DataContract]
    public class FieldValueModel :  IEquatable<FieldValueModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValueModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected FieldValueModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValueModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId">fieldTypeId (required).</param>
        /// <param name="value">value.</param>
        public FieldValueModel(string fieldTypeId = default, object value = default(object))
        {
            // to ensure "fieldTypeId" is required (not null)
            if (fieldTypeId == null)
            {
                throw new InvalidDataException("fieldTypeId is a required property for FieldValueModel and cannot be null");
            }
            else
            {
                FieldTypeId = fieldTypeId;
            }
            Value = value;
        }
        
        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name="fieldTypeId", EmitDefaultValue=false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value")]
        public object Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FieldValueModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
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
            return Equals(input as FieldValueModel);
        }

        /// <summary>
        /// Returns true if FieldValueModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FieldValueModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FieldValueModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    FieldTypeId == input.FieldTypeId ||
                    (FieldTypeId != null &&
                    FieldTypeId.Equals(input.FieldTypeId))
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
                if (FieldTypeId != null)
                    hashCode = hashCode * 59 + FieldTypeId.GetHashCode();
                if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                return hashCode;
            }
        }
    }

}
