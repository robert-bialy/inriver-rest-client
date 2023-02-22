using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SetFieldSetModel
    /// </summary>
    [DataContract]
    public class SetFieldSetModel :  IEquatable<SetFieldSetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetFieldSetModel" /> class.
        /// </summary>
        /// <param name="fieldSetId">fieldSetId.</param>
        /// <param name="wipeOtherFields">wipeOtherFields.</param>
        public SetFieldSetModel(string fieldSetId = default, bool? wipeOtherFields = default(bool?))
        {
            FieldSetId = fieldSetId;
            WipeOtherFields = wipeOtherFields;
        }
        
        /// <summary>
        /// Gets or Sets FieldSetId
        /// </summary>
        [DataMember(Name="fieldSetId", EmitDefaultValue=false)]
        public string FieldSetId { get; set; }

        /// <summary>
        /// Gets or Sets WipeOtherFields
        /// </summary>
        [DataMember(Name="wipeOtherFields", EmitDefaultValue=false)]
        public bool? WipeOtherFields { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetFieldSetModel {\n");
            sb.Append("  FieldSetId: ").Append(FieldSetId).Append("\n");
            sb.Append("  WipeOtherFields: ").Append(WipeOtherFields).Append("\n");
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
            return Equals(input as SetFieldSetModel);
        }

        /// <summary>
        /// Returns true if SetFieldSetModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SetFieldSetModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetFieldSetModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    FieldSetId == input.FieldSetId ||
                    (FieldSetId != null &&
                    FieldSetId.Equals(input.FieldSetId))
                ) && 
                (
                    WipeOtherFields == input.WipeOtherFields ||
                    (WipeOtherFields != null &&
                    WipeOtherFields.Equals(input.WipeOtherFields))
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
                if (FieldSetId != null)
                    hashCode = hashCode * 59 + FieldSetId.GetHashCode();
                if (WipeOtherFields != null)
                    hashCode = hashCode * 59 + WipeOtherFields.GetHashCode();
                return hashCode;
            }
        }
    }

}
