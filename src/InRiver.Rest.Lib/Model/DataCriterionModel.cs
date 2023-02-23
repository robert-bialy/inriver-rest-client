using System;
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
        public DataCriterionModel(string fieldTypeId = default, object value = default(object), string language = default, string _operator = default)
        {
            FieldTypeId = fieldTypeId;
            Value = value;
            Language = language;
            Operator = _operator;
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
        public object Value { get; set; }

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
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as DataCriterionModel);
        }

        /// <summary>
        /// Returns true if DataCriterionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DataCriterionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataCriterionModel input)
        {
            if(input == null)
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
                ) && 
               (
                    Language == input.Language ||
                   (Language != null &&
                    Language.Equals(input.Language))
                ) && 
               (
                    Operator == input.Operator ||
                   (Operator != null &&
                    Operator.Equals(input.Operator))
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
                if(FieldTypeId != null)
                    hashCode = hashCode * 59 + FieldTypeId.GetHashCode();
                if(Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if(Language != null)
                    hashCode = hashCode * 59 + Language.GetHashCode();
                if(Operator != null)
                    hashCode = hashCode * 59 + Operator.GetHashCode();
                return hashCode;
            }
        }
    }

}
