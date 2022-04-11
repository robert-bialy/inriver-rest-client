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
        public EntityTypeModel(string id = default(string), string name = default(string), List<FieldTypeModel> fieldTypes = default(List<FieldTypeModel>), List<string> inboundLinkTypes = default(List<string>), List<string> outboundLinkTypes = default(List<string>), bool? isLinkEntityType = default(bool?), List<string> fieldSetIds = default(List<string>), string displayNameFieldTypeId = default(string), string displayDescriptionFieldTypeId = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.FieldTypes = fieldTypes;
            this.InboundLinkTypes = inboundLinkTypes;
            this.OutboundLinkTypes = outboundLinkTypes;
            this.IsLinkEntityType = isLinkEntityType;
            this.FieldSetIds = fieldSetIds;
            this.DisplayNameFieldTypeId = displayNameFieldTypeId;
            this.DisplayDescriptionFieldTypeId = displayDescriptionFieldTypeId;
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EntityTypeModel);
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
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.FieldTypes == input.FieldTypes ||
                    this.FieldTypes != null &&
                    this.FieldTypes.SequenceEqual(input.FieldTypes)
                ) && 
                (
                    this.InboundLinkTypes == input.InboundLinkTypes ||
                    this.InboundLinkTypes != null &&
                    this.InboundLinkTypes.SequenceEqual(input.InboundLinkTypes)
                ) && 
                (
                    this.OutboundLinkTypes == input.OutboundLinkTypes ||
                    this.OutboundLinkTypes != null &&
                    this.OutboundLinkTypes.SequenceEqual(input.OutboundLinkTypes)
                ) && 
                (
                    this.IsLinkEntityType == input.IsLinkEntityType ||
                    (this.IsLinkEntityType != null &&
                    this.IsLinkEntityType.Equals(input.IsLinkEntityType))
                ) && 
                (
                    this.FieldSetIds == input.FieldSetIds ||
                    this.FieldSetIds != null &&
                    this.FieldSetIds.SequenceEqual(input.FieldSetIds)
                ) && 
                (
                    this.DisplayNameFieldTypeId == input.DisplayNameFieldTypeId ||
                    (this.DisplayNameFieldTypeId != null &&
                    this.DisplayNameFieldTypeId.Equals(input.DisplayNameFieldTypeId))
                ) && 
                (
                    this.DisplayDescriptionFieldTypeId == input.DisplayDescriptionFieldTypeId ||
                    (this.DisplayDescriptionFieldTypeId != null &&
                    this.DisplayDescriptionFieldTypeId.Equals(input.DisplayDescriptionFieldTypeId))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.FieldTypes != null)
                    hashCode = hashCode * 59 + this.FieldTypes.GetHashCode();
                if (this.InboundLinkTypes != null)
                    hashCode = hashCode * 59 + this.InboundLinkTypes.GetHashCode();
                if (this.OutboundLinkTypes != null)
                    hashCode = hashCode * 59 + this.OutboundLinkTypes.GetHashCode();
                if (this.IsLinkEntityType != null)
                    hashCode = hashCode * 59 + this.IsLinkEntityType.GetHashCode();
                if (this.FieldSetIds != null)
                    hashCode = hashCode * 59 + this.FieldSetIds.GetHashCode();
                if (this.DisplayNameFieldTypeId != null)
                    hashCode = hashCode * 59 + this.DisplayNameFieldTypeId.GetHashCode();
                if (this.DisplayDescriptionFieldTypeId != null)
                    hashCode = hashCode * 59 + this.DisplayDescriptionFieldTypeId.GetHashCode();
                return hashCode;
            }
        }
    }

}
