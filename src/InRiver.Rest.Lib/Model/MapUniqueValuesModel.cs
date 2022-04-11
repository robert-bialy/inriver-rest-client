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
        /// <param name="fieldTypeId">fieldTypeId (required).</param>
        /// <param name="uniqueValues">uniqueValues (required).</param>
        public MapUniqueValuesModel(string fieldTypeId = default(string), List<Object> uniqueValues = default(List<Object>))
        {
            // to ensure "fieldTypeId" is required (not null)
            if (fieldTypeId == null)
            {
                throw new InvalidDataException("fieldTypeId is a required property for MapUniqueValuesModel and cannot be null");
            }
            else
            {
                this.FieldTypeId = fieldTypeId;
            }
            // to ensure "uniqueValues" is required (not null)
            if (uniqueValues == null)
            {
                throw new InvalidDataException("uniqueValues is a required property for MapUniqueValuesModel and cannot be null");
            }
            else
            {
                this.UniqueValues = uniqueValues;
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
        public List<Object> UniqueValues { get; set; }

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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MapUniqueValuesModel);
        }

        /// <summary>
        /// Returns true if MapUniqueValuesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of MapUniqueValuesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MapUniqueValuesModel input)
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
                    this.UniqueValues == input.UniqueValues ||
                    this.UniqueValues != null &&
                    this.UniqueValues.SequenceEqual(input.UniqueValues)
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
                if (this.UniqueValues != null)
                    hashCode = hashCode * 59 + this.UniqueValues.GetHashCode();
                return hashCode;
            }
        }
    }

}
