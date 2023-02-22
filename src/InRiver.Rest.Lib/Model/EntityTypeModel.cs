using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// EntityTypeModel
    /// </summary>
    [DataContract]
    public class EntityTypeModel :  IEquatable<EntityTypeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityTypeModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="fieldTypes">fieldTypes.</param>
        /// <param name="inboundLinkTypes">inboundLinkTypes.</param>
        /// <param name="outboundLinkTypes">outboundLinkTypes.</param>
        /// <param name="isLinkEntityType">isLinkEntityType.</param>
        /// <param name="fieldSetIds">fieldSetIds.</param>
        /// <param name="displayNameFieldTypeId">displayNameFieldTypeId.</param>
        /// <param name="displayDescriptionFieldTypeId">displayDescriptionFieldTypeId.</param>
        public EntityTypeModel(string id = default, string name = default, List<FieldTypeModel> fieldTypes = default(List<FieldTypeModel>), List<string> inboundLinkTypes = default(List<string>), List<string> outboundLinkTypes = default(List<string>), bool? isLinkEntityType = default(bool?), List<string> fieldSetIds = default(List<string>), string displayNameFieldTypeId = default, string displayDescriptionFieldTypeId = default)
        {
            Id = id;
            Name = name;
            FieldTypes = fieldTypes;
            InboundLinkTypes = inboundLinkTypes;
            OutboundLinkTypes = outboundLinkTypes;
            IsLinkEntityType = isLinkEntityType;
            FieldSetIds = fieldSetIds;
            DisplayNameFieldTypeId = displayNameFieldTypeId;
            DisplayDescriptionFieldTypeId = displayDescriptionFieldTypeId;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets FieldTypes
        /// </summary>
        [DataMember(Name="fieldTypes", EmitDefaultValue=false)]
        public List<FieldTypeModel> FieldTypes { get; set; }

        /// <summary>
        /// Gets or Sets InboundLinkTypes
        /// </summary>
        [DataMember(Name="inboundLinkTypes", EmitDefaultValue=false)]
        public List<string> InboundLinkTypes { get; set; }

        /// <summary>
        /// Gets or Sets OutboundLinkTypes
        /// </summary>
        [DataMember(Name="outboundLinkTypes", EmitDefaultValue=false)]
        public List<string> OutboundLinkTypes { get; set; }

        /// <summary>
        /// Gets or Sets IsLinkEntityType
        /// </summary>
        [DataMember(Name="isLinkEntityType", EmitDefaultValue=false)]
        public bool? IsLinkEntityType { get; set; }

        /// <summary>
        /// Gets or Sets FieldSetIds
        /// </summary>
        [DataMember(Name="fieldSetIds", EmitDefaultValue=false)]
        public List<string> FieldSetIds { get; set; }

        /// <summary>
        /// Gets or Sets DisplayNameFieldTypeId
        /// </summary>
        [DataMember(Name="displayNameFieldTypeId", EmitDefaultValue=false)]
        public string DisplayNameFieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets DisplayDescriptionFieldTypeId
        /// </summary>
        [DataMember(Name="displayDescriptionFieldTypeId", EmitDefaultValue=false)]
        public string DisplayDescriptionFieldTypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityTypeModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  FieldTypes: ").Append(FieldTypes).Append("\n");
            sb.Append("  InboundLinkTypes: ").Append(InboundLinkTypes).Append("\n");
            sb.Append("  OutboundLinkTypes: ").Append(OutboundLinkTypes).Append("\n");
            sb.Append("  IsLinkEntityType: ").Append(IsLinkEntityType).Append("\n");
            sb.Append("  FieldSetIds: ").Append(FieldSetIds).Append("\n");
            sb.Append("  DisplayNameFieldTypeId: ").Append(DisplayNameFieldTypeId).Append("\n");
            sb.Append("  DisplayDescriptionFieldTypeId: ").Append(DisplayDescriptionFieldTypeId).Append("\n");
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
            return Equals(input as EntityTypeModel);
        }

        /// <summary>
        /// Returns true if EntityTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntityTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntityTypeModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) && 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    FieldTypes == input.FieldTypes ||
                    FieldTypes != null &&
                    FieldTypes.SequenceEqual(input.FieldTypes)
                ) && 
                (
                    InboundLinkTypes == input.InboundLinkTypes ||
                    InboundLinkTypes != null &&
                    InboundLinkTypes.SequenceEqual(input.InboundLinkTypes)
                ) && 
                (
                    OutboundLinkTypes == input.OutboundLinkTypes ||
                    OutboundLinkTypes != null &&
                    OutboundLinkTypes.SequenceEqual(input.OutboundLinkTypes)
                ) && 
                (
                    IsLinkEntityType == input.IsLinkEntityType ||
                    (IsLinkEntityType != null &&
                    IsLinkEntityType.Equals(input.IsLinkEntityType))
                ) && 
                (
                    FieldSetIds == input.FieldSetIds ||
                    FieldSetIds != null &&
                    FieldSetIds.SequenceEqual(input.FieldSetIds)
                ) && 
                (
                    DisplayNameFieldTypeId == input.DisplayNameFieldTypeId ||
                    (DisplayNameFieldTypeId != null &&
                    DisplayNameFieldTypeId.Equals(input.DisplayNameFieldTypeId))
                ) && 
                (
                    DisplayDescriptionFieldTypeId == input.DisplayDescriptionFieldTypeId ||
                    (DisplayDescriptionFieldTypeId != null &&
                    DisplayDescriptionFieldTypeId.Equals(input.DisplayDescriptionFieldTypeId))
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (FieldTypes != null)
                    hashCode = hashCode * 59 + FieldTypes.GetHashCode();
                if (InboundLinkTypes != null)
                    hashCode = hashCode * 59 + InboundLinkTypes.GetHashCode();
                if (OutboundLinkTypes != null)
                    hashCode = hashCode * 59 + OutboundLinkTypes.GetHashCode();
                if (IsLinkEntityType != null)
                    hashCode = hashCode * 59 + IsLinkEntityType.GetHashCode();
                if (FieldSetIds != null)
                    hashCode = hashCode * 59 + FieldSetIds.GetHashCode();
                if (DisplayNameFieldTypeId != null)
                    hashCode = hashCode * 59 + DisplayNameFieldTypeId.GetHashCode();
                if (DisplayDescriptionFieldTypeId != null)
                    hashCode = hashCode * 59 + DisplayDescriptionFieldTypeId.GetHashCode();
                return hashCode;
            }
        }
    }

}
