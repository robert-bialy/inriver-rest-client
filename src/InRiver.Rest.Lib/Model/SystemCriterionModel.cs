using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SystemCriterionModel
    /// </summary>
    [DataContract]
    public class SystemCriterionModel :  IEquatable<SystemCriterionModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemCriterionModel" /> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="value">value.</param>
        /// <param name="_operator">_operator.</param>
        public SystemCriterionModel(string type = default, object value = default(object), string _operator = default)
        {
            Type = type;
            Value = value;
            Operator = _operator;
        }
        
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public object Value { get; set; }

        /// <summary>
        /// Gets or Sets Operator
        /// </summary>
        [DataMember(Name="operator", EmitDefaultValue = false)]
        public string Operator { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SystemCriterionModel {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return Equals(input as SystemCriterionModel);
        }

        /// <summary>
        /// Returns true if SystemCriterionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SystemCriterionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SystemCriterionModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    Type == input.Type ||
                   (Type != null &&
                    Type.Equals(input.Type))
                ) && 
               (
                    Value == input.Value ||
                   (Value != null &&
                    Value.Equals(input.Value))
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
                if(Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                if(Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if(Operator != null)
                    hashCode = hashCode * 59 + Operator.GetHashCode();
                return hashCode;
            }
        }
    }

}
