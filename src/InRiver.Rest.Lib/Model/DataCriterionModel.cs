using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// DataCriterionModel
    /// </summary>
    [DataContract]
    public class DataCriterionModel :  IEquatable<DataCriterionModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataCriterionModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId">fieldTypeId.</param>
        /// <param name="value">value.</param>
        /// <param name="language">language.</param>
        /// <param name="_operator">_operator.</param>
        public DataCriterionModel(string fieldTypeId = default(string), Object value = default(Object), string language = default(string), string _operator = default(string))
        {
            this.FieldTypeId = fieldTypeId;
            this.Value = value;
            this.Language = language;
            this.Operator = _operator;
        }
        
        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name="fieldTypeId", EmitDefaultValue=false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public Object Value { get; set; }

        /// <summary>
        /// Gets or Sets Language
        /// </summary>
        [DataMember(Name="language", EmitDefaultValue=false)]
        public string Language { get; set; }

        /// <summary>
        /// Gets or Sets Operator
        /// </summary>
        [DataMember(Name="operator", EmitDefaultValue=false)]
        public string Operator { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DataCriterionModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  Operator: ").Append(Operator).Append("\n");
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
            return this.Equals(input as DataCriterionModel);
        }

        /// <summary>
        /// Returns true if DataCriterionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DataCriterionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataCriterionModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FieldTypeId == input.FieldTypeId ||
                    (this.FieldTypeId != null &&
                    this.FieldTypeId.Equals(input.FieldTypeId))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Language == input.Language ||
                    (this.Language != null &&
                    this.Language.Equals(input.Language))
                ) && 
                (
                    this.Operator == input.Operator ||
                    (this.Operator != null &&
                    this.Operator.Equals(input.Operator))
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
                if (this.FieldTypeId != null)
                    hashCode = hashCode * 59 + this.FieldTypeId.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Language != null)
                    hashCode = hashCode * 59 + this.Language.GetHashCode();
                if (this.Operator != null)
                    hashCode = hashCode * 59 + this.Operator.GetHashCode();
                return hashCode;
            }
        }
    }

}
