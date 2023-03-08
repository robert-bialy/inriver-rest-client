using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// MapUniqueValuesModel
    /// </summary>
    [DataContract]
    public class MapUniqueValuesModel :  IEquatable<MapUniqueValuesModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapUniqueValuesModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected MapUniqueValuesModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MapUniqueValuesModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId">fieldTypeId(required).</param>
        /// <param name="uniqueValues">uniqueValues(required).</param>
        public MapUniqueValuesModel(string fieldTypeId = default, List<object> uniqueValues = default(List<object>))
        {
            // to ensure "fieldTypeId" is required(not null)
            if(fieldTypeId == null)
            {
                throw new InvalidDataException("fieldTypeId is a required property for MapUniqueValuesModel and cannot be null");
            }
            else
            {
                FieldTypeId = fieldTypeId;
            }
            // to ensure "uniqueValues" is required(not null)
            if(uniqueValues == null)
            {
                throw new InvalidDataException("uniqueValues is a required property for MapUniqueValuesModel and cannot be null");
            }
            else
            {
                UniqueValues = uniqueValues;
            }
        }
        
        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name="fieldTypeId", EmitDefaultValue=false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets UniqueValues
        /// </summary>
        [DataMember(Name="uniqueValues", EmitDefaultValue=false)]
        public List<object> UniqueValues { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MapUniqueValuesModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
            sb.Append("  UniqueValues: ").Append(UniqueValues).Append("\n");
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
            return Equals(input as MapUniqueValuesModel);
        }

        /// <summary>
        /// Returns true if MapUniqueValuesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of MapUniqueValuesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MapUniqueValuesModel input)
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
                    UniqueValues == input.UniqueValues ||
                    UniqueValues != null &&
                    UniqueValues.SequenceEqual(input.UniqueValues)
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
                if(UniqueValues != null)
                    hashCode = hashCode * 59 + UniqueValues.GetHashCode();
                return hashCode;
            }
        }
    }

}
