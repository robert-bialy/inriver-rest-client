using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// EntityDataModel
    /// </summary>
    [DataContract]
    public class EntityDataModel :  IEquatable<EntityDataModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDataModel" /> class.
        /// </summary>
        /// <param name="entityId">entityId.</param>
        /// <param name="linkTypeId">linkTypeId.</param>
        /// <param name="linkIndex">linkIndex.</param>
        /// <param name="linkEntity">linkEntity.</param>
        /// <param name="summary">summary.</param>
        /// <param name="fields">fields.</param>
        /// <param name="fieldValues">fieldValues.</param>
        /// <param name="specification">specification.</param>
        /// <param name="specificationValues">specificationValues.</param>
        /// <param name="media">media.</param>
        /// <param name="mediaDetails">mediaDetails.</param>
        /// <param name="inbound">inbound.</param>
        /// <param name="outbound">outbound.</param>
        public EntityDataModel(int? entityId = default(int?), string linkTypeId = default, int? linkIndex = default(int?), EntityDataModel linkEntity = default(EntityDataModel), EntitySummaryModel summary = default(EntitySummaryModel), List<FieldSummaryModel> fields = default(List<FieldSummaryModel>), List<FieldValueModel> fieldValues = default(List<FieldValueModel>), List<SpecificationValueSummaryModel> specification = default(List<SpecificationValueSummaryModel>), List<SpecificationValueModel> specificationValues = default(List<SpecificationValueModel>), List<string> media = default(List<string>), List<MediaInfoModel> mediaDetails = default(List<MediaInfoModel>), List<EntityDataModel> inbound = default(List<EntityDataModel>), List<EntityDataModel> outbound = default(List<EntityDataModel>))
        {
            EntityId = entityId;
            LinkTypeId = linkTypeId;
            LinkIndex = linkIndex;
            LinkEntity = linkEntity;
            Summary = summary;
            Fields = fields;
            FieldValues = fieldValues;
            Specification = specification;
            SpecificationValues = specificationValues;
            Media = media;
            MediaDetails = mediaDetails;
            Inbound = inbound;
            Outbound = outbound;
        }
        
        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entityId", EmitDefaultValue=false)]
        public int? EntityId { get; set; }

        /// <summary>
        /// Gets or Sets LinkTypeId
        /// </summary>
        [DataMember(Name="linkTypeId", EmitDefaultValue=false)]
        public string LinkTypeId { get; set; }

        /// <summary>
        /// Gets or Sets LinkIndex
        /// </summary>
        [DataMember(Name="linkIndex", EmitDefaultValue=false)]
        public int? LinkIndex { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntity
        /// </summary>
        [DataMember(Name="linkEntity", EmitDefaultValue=false)]
        public EntityDataModel LinkEntity { get; set; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name="summary", EmitDefaultValue=false)]
        public EntitySummaryModel Summary { get; set; }

        /// <summary>
        /// Gets or Sets Fields
        /// </summary>
        [DataMember(Name="fields", EmitDefaultValue=false)]
        public List<FieldSummaryModel> Fields { get; set; }

        /// <summary>
        /// Gets or Sets FieldValues
        /// </summary>
        [DataMember(Name="fieldValues", EmitDefaultValue=false)]
        public List<FieldValueModel> FieldValues { get; set; }

        /// <summary>
        /// Gets or Sets Specification
        /// </summary>
        [DataMember(Name="specification", EmitDefaultValue=false)]
        public List<SpecificationValueSummaryModel> Specification { get; set; }

        /// <summary>
        /// Gets or Sets SpecificationValues
        /// </summary>
        [DataMember(Name="specificationValues", EmitDefaultValue=false)]
        public List<SpecificationValueModel> SpecificationValues { get; set; }

        /// <summary>
        /// Gets or Sets Media
        /// </summary>
        [DataMember(Name="media", EmitDefaultValue=false)]
        public List<string> Media { get; set; }

        /// <summary>
        /// Gets or Sets MediaDetails
        /// </summary>
        [DataMember(Name="mediaDetails", EmitDefaultValue=false)]
        public List<MediaInfoModel> MediaDetails { get; set; }

        /// <summary>
        /// Gets or Sets Inbound
        /// </summary>
        [DataMember(Name="inbound", EmitDefaultValue=false)]
        public List<EntityDataModel> Inbound { get; set; }

        /// <summary>
        /// Gets or Sets Outbound
        /// </summary>
        [DataMember(Name="outbound", EmitDefaultValue=false)]
        public List<EntityDataModel> Outbound { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityDataModel {\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  LinkTypeId: ").Append(LinkTypeId).Append("\n");
            sb.Append("  LinkIndex: ").Append(LinkIndex).Append("\n");
            sb.Append("  LinkEntity: ").Append(LinkEntity).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
            sb.Append("  FieldValues: ").Append(FieldValues).Append("\n");
            sb.Append("  Specification: ").Append(Specification).Append("\n");
            sb.Append("  SpecificationValues: ").Append(SpecificationValues).Append("\n");
            sb.Append("  Media: ").Append(Media).Append("\n");
            sb.Append("  MediaDetails: ").Append(MediaDetails).Append("\n");
            sb.Append("  Inbound: ").Append(Inbound).Append("\n");
            sb.Append("  Outbound: ").Append(Outbound).Append("\n");
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
            return Equals(input as EntityDataModel);
        }

        /// <summary>
        /// Returns true if EntityDataModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntityDataModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntityDataModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    EntityId == input.EntityId ||
                   (EntityId != null &&
                    EntityId.Equals(input.EntityId))
                ) && 
               (
                    LinkTypeId == input.LinkTypeId ||
                   (LinkTypeId != null &&
                    LinkTypeId.Equals(input.LinkTypeId))
                ) && 
               (
                    LinkIndex == input.LinkIndex ||
                   (LinkIndex != null &&
                    LinkIndex.Equals(input.LinkIndex))
                ) && 
               (
                    LinkEntity == input.LinkEntity ||
                   (LinkEntity != null &&
                    LinkEntity.Equals(input.LinkEntity))
                ) && 
               (
                    Summary == input.Summary ||
                   (Summary != null &&
                    Summary.Equals(input.Summary))
                ) && 
               (
                    Fields == input.Fields ||
                    Fields != null &&
                    Fields.SequenceEqual(input.Fields)
                ) && 
               (
                    FieldValues == input.FieldValues ||
                    FieldValues != null &&
                    FieldValues.SequenceEqual(input.FieldValues)
                ) && 
               (
                    Specification == input.Specification ||
                    Specification != null &&
                    Specification.SequenceEqual(input.Specification)
                ) && 
               (
                    SpecificationValues == input.SpecificationValues ||
                    SpecificationValues != null &&
                    SpecificationValues.SequenceEqual(input.SpecificationValues)
                ) && 
               (
                    Media == input.Media ||
                    Media != null &&
                    Media.SequenceEqual(input.Media)
                ) && 
               (
                    MediaDetails == input.MediaDetails ||
                    MediaDetails != null &&
                    MediaDetails.SequenceEqual(input.MediaDetails)
                ) && 
               (
                    Inbound == input.Inbound ||
                    Inbound != null &&
                    Inbound.SequenceEqual(input.Inbound)
                ) && 
               (
                    Outbound == input.Outbound ||
                    Outbound != null &&
                    Outbound.SequenceEqual(input.Outbound)
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
                if(EntityId != null)
                    hashCode = hashCode * 59 + EntityId.GetHashCode();
                if(LinkTypeId != null)
                    hashCode = hashCode * 59 + LinkTypeId.GetHashCode();
                if(LinkIndex != null)
                    hashCode = hashCode * 59 + LinkIndex.GetHashCode();
                if(LinkEntity != null)
                    hashCode = hashCode * 59 + LinkEntity.GetHashCode();
                if(Summary != null)
                    hashCode = hashCode * 59 + Summary.GetHashCode();
                if(Fields != null)
                    hashCode = hashCode * 59 + Fields.GetHashCode();
                if(FieldValues != null)
                    hashCode = hashCode * 59 + FieldValues.GetHashCode();
                if(Specification != null)
                    hashCode = hashCode * 59 + Specification.GetHashCode();
                if(SpecificationValues != null)
                    hashCode = hashCode * 59 + SpecificationValues.GetHashCode();
                if(Media != null)
                    hashCode = hashCode * 59 + Media.GetHashCode();
                if(MediaDetails != null)
                    hashCode = hashCode * 59 + MediaDetails.GetHashCode();
                if(Inbound != null)
                    hashCode = hashCode * 59 + Inbound.GetHashCode();
                if(Outbound != null)
                    hashCode = hashCode * 59 + Outbound.GetHashCode();
                return hashCode;
            }
        }
    }

}
