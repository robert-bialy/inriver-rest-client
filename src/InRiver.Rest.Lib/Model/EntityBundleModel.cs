using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// EntityBundleModel
    /// </summary>
    [DataContract]
    public class EntityBundleModel :  IEquatable<EntityBundleModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBundleModel" /> class.
        /// </summary>
        /// <param name="summary">summary.</param>
        /// <param name="fields">fields.</param>
        /// <param name="specification">specification.</param>
        /// <param name="outbound">outbound.</param>
        /// <param name="inbound">inbound.</param>
        /// <param name="linkEntity">linkEntity.</param>
        /// <param name="linkTypeId">linkTypeId.</param>
        /// <param name="linkIndex">linkIndex.</param>
        public EntityBundleModel(EntitySummaryModel summary = default(EntitySummaryModel), List<FieldSummaryModel> fields = default(List<FieldSummaryModel>), List<SpecificationValueSummaryModel> specification = default(List<SpecificationValueSummaryModel>), List<EntityBundleModel> outbound = default(List<EntityBundleModel>), List<EntityBundleModel> inbound = default(List<EntityBundleModel>), EntityBundleModel linkEntity = default(EntityBundleModel), string linkTypeId = default, int? linkIndex = default(int?))
        {
            Summary = summary;
            Fields = fields;
            Specification = specification;
            Outbound = outbound;
            Inbound = inbound;
            LinkEntity = linkEntity;
            LinkTypeId = linkTypeId;
            LinkIndex = linkIndex;
        }
        
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
        /// Gets or Sets Specification
        /// </summary>
        [DataMember(Name="specification", EmitDefaultValue=false)]
        public List<SpecificationValueSummaryModel> Specification { get; set; }

        /// <summary>
        /// Gets or Sets Outbound
        /// </summary>
        [DataMember(Name="outbound", EmitDefaultValue=false)]
        public List<EntityBundleModel> Outbound { get; set; }

        /// <summary>
        /// Gets or Sets Inbound
        /// </summary>
        [DataMember(Name="inbound", EmitDefaultValue=false)]
        public List<EntityBundleModel> Inbound { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntity
        /// </summary>
        [DataMember(Name="linkEntity", EmitDefaultValue=false)]
        public EntityBundleModel LinkEntity { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityBundleModel {\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
            sb.Append("  Specification: ").Append(Specification).Append("\n");
            sb.Append("  Outbound: ").Append(Outbound).Append("\n");
            sb.Append("  Inbound: ").Append(Inbound).Append("\n");
            sb.Append("  LinkEntity: ").Append(LinkEntity).Append("\n");
            sb.Append("  LinkTypeId: ").Append(LinkTypeId).Append("\n");
            sb.Append("  LinkIndex: ").Append(LinkIndex).Append("\n");
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
            return Equals(input as EntityBundleModel);
        }

        /// <summary>
        /// Returns true if EntityBundleModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntityBundleModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntityBundleModel input)
        {
            if (input == null)
                return false;

            return 
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
                    Specification == input.Specification ||
                    Specification != null &&
                    Specification.SequenceEqual(input.Specification)
                ) && 
                (
                    Outbound == input.Outbound ||
                    Outbound != null &&
                    Outbound.SequenceEqual(input.Outbound)
                ) && 
                (
                    Inbound == input.Inbound ||
                    Inbound != null &&
                    Inbound.SequenceEqual(input.Inbound)
                ) && 
                (
                    LinkEntity == input.LinkEntity ||
                    (LinkEntity != null &&
                    LinkEntity.Equals(input.LinkEntity))
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
                if (Summary != null)
                    hashCode = hashCode * 59 + Summary.GetHashCode();
                if (Fields != null)
                    hashCode = hashCode * 59 + Fields.GetHashCode();
                if (Specification != null)
                    hashCode = hashCode * 59 + Specification.GetHashCode();
                if (Outbound != null)
                    hashCode = hashCode * 59 + Outbound.GetHashCode();
                if (Inbound != null)
                    hashCode = hashCode * 59 + Inbound.GetHashCode();
                if (LinkEntity != null)
                    hashCode = hashCode * 59 + LinkEntity.GetHashCode();
                if (LinkTypeId != null)
                    hashCode = hashCode * 59 + LinkTypeId.GetHashCode();
                if (LinkIndex != null)
                    hashCode = hashCode * 59 + LinkIndex.GetHashCode();
                return hashCode;
            }
        }
    }

}
