using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FieldSetModel
    /// </summary>
    [DataContract]
    public class FieldSetModel :  IEquatable<FieldSetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldSetModel" /> class.
        /// </summary>
        /// <param name="fieldSetId">fieldSetId.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="entityTypeId">entityTypeId.</param>
        /// <param name="fieldTypeIds">fieldTypeIds.</param>
        public FieldSetModel(string fieldSetId = default, string name = default, string description = default, string entityTypeId = default, List<string> fieldTypeIds = default(List<string>))
        {
            FieldSetId = fieldSetId;
            Name = name;
            Description = description;
            EntityTypeId = entityTypeId;
            FieldTypeIds = fieldTypeIds;
        }
        
        /// <summary>
        /// Gets or Sets FieldSetId
        /// </summary>
        [DataMember(Name="fieldSetId", EmitDefaultValue=false)]
        public string FieldSetId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets EntityTypeId
        /// </summary>
        [DataMember(Name="entityTypeId", EmitDefaultValue=false)]
        public string EntityTypeId { get; set; }

        /// <summary>
        /// Gets or Sets FieldTypeIds
        /// </summary>
        [DataMember(Name="fieldTypeIds", EmitDefaultValue=false)]
        public List<string> FieldTypeIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FieldSetModel {\n");
            sb.Append("  FieldSetId: ").Append(FieldSetId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EntityTypeId: ").Append(EntityTypeId).Append("\n");
            sb.Append("  FieldTypeIds: ").Append(FieldTypeIds).Append("\n");
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
            return Equals(input as FieldSetModel);
        }

        /// <summary>
        /// Returns true if FieldSetModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FieldSetModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FieldSetModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    FieldSetId == input.FieldSetId ||
                   (FieldSetId != null &&
                    FieldSetId.Equals(input.FieldSetId))
                ) && 
               (
                    Name == input.Name ||
                   (Name != null &&
                    Name.Equals(input.Name))
                ) && 
               (
                    Description == input.Description ||
                   (Description != null &&
                    Description.Equals(input.Description))
                ) && 
               (
                    EntityTypeId == input.EntityTypeId ||
                   (EntityTypeId != null &&
                    EntityTypeId.Equals(input.EntityTypeId))
                ) && 
               (
                    FieldTypeIds == input.FieldTypeIds ||
                    FieldTypeIds != null &&
                    FieldTypeIds.SequenceEqual(input.FieldTypeIds)
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
                if(FieldSetId != null)
                    hashCode = hashCode * 59 + FieldSetId.GetHashCode();
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if(EntityTypeId != null)
                    hashCode = hashCode * 59 + EntityTypeId.GetHashCode();
                if(FieldTypeIds != null)
                    hashCode = hashCode * 59 + FieldTypeIds.GetHashCode();
                return hashCode;
            }
        }
    }

}
