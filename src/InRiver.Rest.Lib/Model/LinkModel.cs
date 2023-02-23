using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// LinkModel
    /// </summary>
    [DataContract]
    public class LinkModel :  IEquatable<LinkModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected LinkModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="isActive">isActive.</param>
        /// <param name="linkTypeId">linkTypeId(required).</param>
        /// <param name="sourceEntityId">sourceEntityId(required).</param>
        /// <param name="targetEntityId">targetEntityId(required).</param>
        /// <param name="linkEntityId">linkEntityId.</param>
        /// <param name="index">index.</param>
        public LinkModel(
            int? id,
            bool? isActive,
            string linkTypeId,
            int? sourceEntityId,
            int? targetEntityId,
            int? linkEntityId,
            int? index)
        {
            // to ensure "linkTypeId" is required(not null)
            if(linkTypeId == null)
            {
                throw new InvalidDataException("linkTypeId is a required property for LinkModel and cannot be null");
            }
            else
            {
                LinkTypeId = linkTypeId;
            }
            // to ensure "sourceEntityId" is required(not null)
            if(sourceEntityId == null)
            {
                throw new InvalidDataException("sourceEntityId is a required property for LinkModel and cannot be null");
            }
            else
            {
                SourceEntityId = sourceEntityId;
            }
            // to ensure "targetEntityId" is required(not null)
            if(targetEntityId == null)
            {
                throw new InvalidDataException("targetEntityId is a required property for LinkModel and cannot be null");
            }
            else
            {
                TargetEntityId = targetEntityId;
            }
            Id = id;
            IsActive = isActive;
            LinkEntityId = linkEntityId;
            Index = index;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name="isActive", EmitDefaultValue=false)]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or Sets LinkTypeId
        /// </summary>
        [DataMember(Name="linkTypeId", EmitDefaultValue=false)]
        public string LinkTypeId { get; set; }

        /// <summary>
        /// Gets or Sets SourceEntityId
        /// </summary>
        [DataMember(Name="sourceEntityId", EmitDefaultValue=false)]
        public int? SourceEntityId { get; set; }

        /// <summary>
        /// Gets or Sets TargetEntityId
        /// </summary>
        [DataMember(Name="targetEntityId", EmitDefaultValue=false)]
        public int? TargetEntityId { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntityId
        /// </summary>
        [DataMember(Name="linkEntityId", EmitDefaultValue=false)]
        public int? LinkEntityId { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  LinkTypeId: ").Append(LinkTypeId).Append("\n");
            sb.Append("  SourceEntityId: ").Append(SourceEntityId).Append("\n");
            sb.Append("  TargetEntityId: ").Append(TargetEntityId).Append("\n");
            sb.Append("  LinkEntityId: ").Append(LinkEntityId).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
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
            return Equals(input as LinkModel);
        }

        /// <summary>
        /// Returns true if LinkModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    Id == input.Id ||
                   (Id != null &&
                    Id.Equals(input.Id))
                ) && 
               (
                    IsActive == input.IsActive ||
                   (IsActive != null &&
                    IsActive.Equals(input.IsActive))
                ) && 
               (
                    LinkTypeId == input.LinkTypeId ||
                   (LinkTypeId != null &&
                    LinkTypeId.Equals(input.LinkTypeId))
                ) && 
               (
                    SourceEntityId == input.SourceEntityId ||
                   (SourceEntityId != null &&
                    SourceEntityId.Equals(input.SourceEntityId))
                ) && 
               (
                    TargetEntityId == input.TargetEntityId ||
                   (TargetEntityId != null &&
                    TargetEntityId.Equals(input.TargetEntityId))
                ) && 
               (
                    LinkEntityId == input.LinkEntityId ||
                   (LinkEntityId != null &&
                    LinkEntityId.Equals(input.LinkEntityId))
                ) && 
               (
                    Index == input.Index ||
                   (Index != null &&
                    Index.Equals(input.Index))
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
                if(Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if(IsActive != null)
                    hashCode = hashCode * 59 + IsActive.GetHashCode();
                if(LinkTypeId != null)
                    hashCode = hashCode * 59 + LinkTypeId.GetHashCode();
                if(SourceEntityId != null)
                    hashCode = hashCode * 59 + SourceEntityId.GetHashCode();
                if(TargetEntityId != null)
                    hashCode = hashCode * 59 + TargetEntityId.GetHashCode();
                if(LinkEntityId != null)
                    hashCode = hashCode * 59 + LinkEntityId.GetHashCode();
                if(Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                return hashCode;
            }
        }
    }

}
