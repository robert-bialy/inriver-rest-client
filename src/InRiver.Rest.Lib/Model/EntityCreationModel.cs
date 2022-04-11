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
    /// EntityCreationModel
    /// </summary>
    [DataContract]
    public class EntityCreationModel :  IEquatable<EntityCreationModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreationModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected EntityCreationModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreationModel" /> class.
        /// </summary>
        /// <param name="entityTypeId">entityTypeId (required).</param>
        /// <param name="fieldSetId">fieldSetId.</param>
        /// <param name="fieldValues">fieldValues.</param>
        /// <param name="segmentId">segmentId.</param>
        public EntityCreationModel(string entityTypeId = default(string), string fieldSetId = default(string), List<FieldValueModel> fieldValues = default(List<FieldValueModel>), int? segmentId = default(int?))
        {
            // to ensure "entityTypeId" is required (not null)
            if (entityTypeId == null)
            {
                throw new InvalidDataException("entityTypeId is a required property for EntityCreationModel and cannot be null");
            }
            else
            {
                this.EntityTypeId = entityTypeId;
            }
            this.FieldSetId = fieldSetId;
            this.FieldValues = fieldValues;
            this.SegmentId = segmentId;
        }
        
        /// <summary>
        /// Gets or Sets EntityTypeId
        /// </summary>
        [DataMember(Name="entityTypeId", EmitDefaultValue=false)]
        public string EntityTypeId { get; set; }

        /// <summary>
        /// Gets or Sets FieldSetId
        /// </summary>
        [DataMember(Name="fieldSetId", EmitDefaultValue=false)]
        public string FieldSetId { get; set; }

        /// <summary>
        /// Gets or Sets FieldValues
        /// </summary>
        [DataMember(Name="fieldValues", EmitDefaultValue=false)]
        public List<FieldValueModel> FieldValues { get; set; }

        /// <summary>
        /// Gets or Sets SegmentId
        /// </summary>
        [DataMember(Name="segmentId", EmitDefaultValue=false)]
        public int? SegmentId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityCreationModel {\n");
            sb.Append("  EntityTypeId: ").Append(EntityTypeId).Append("\n");
            sb.Append("  FieldSetId: ").Append(FieldSetId).Append("\n");
            sb.Append("  FieldValues: ").Append(FieldValues).Append("\n");
            sb.Append("  SegmentId: ").Append(SegmentId).Append("\n");
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
            return this.Equals(input as EntityCreationModel);
        }

        /// <summary>
        /// Returns true if EntityCreationModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntityCreationModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntityCreationModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityTypeId == input.EntityTypeId ||
                    (this.EntityTypeId != null &&
                    this.EntityTypeId.Equals(input.EntityTypeId))
                ) && 
                (
                    this.FieldSetId == input.FieldSetId ||
                    (this.FieldSetId != null &&
                    this.FieldSetId.Equals(input.FieldSetId))
                ) && 
                (
                    this.FieldValues == input.FieldValues ||
                    this.FieldValues != null &&
                    this.FieldValues.SequenceEqual(input.FieldValues)
                ) && 
                (
                    this.SegmentId == input.SegmentId ||
                    (this.SegmentId != null &&
                    this.SegmentId.Equals(input.SegmentId))
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
                if (this.EntityTypeId != null)
                    hashCode = hashCode * 59 + this.EntityTypeId.GetHashCode();
                if (this.FieldSetId != null)
                    hashCode = hashCode * 59 + this.FieldSetId.GetHashCode();
                if (this.FieldValues != null)
                    hashCode = hashCode * 59 + this.FieldValues.GetHashCode();
                if (this.SegmentId != null)
                    hashCode = hashCode * 59 + this.SegmentId.GetHashCode();
                return hashCode;
            }
        }
    }

}
