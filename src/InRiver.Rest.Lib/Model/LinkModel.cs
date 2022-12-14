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
        /// <param name="linkTypeId">linkTypeId (required).</param>
        /// <param name="sourceEntityId">sourceEntityId (required).</param>
        /// <param name="targetEntityId">targetEntityId (required).</param>
        /// <param name="linkEntityId">linkEntityId.</param>
        /// <param name="index">index.</param>
        public LinkModel(
            int? id = default(int?),
            bool? isActive = default(bool?),
            string linkTypeId = default(string),
            int? sourceEntityId = default(int?),
            int? targetEntityId = default(int?),
            int? linkEntityId = default(int?),
            int? index = default(int?))
        {
            // to ensure "linkTypeId" is required (not null)
            if (linkTypeId == null)
            {
                throw new InvalidDataException("linkTypeId is a required property for LinkModel and cannot be null");
            }
            else
            {
                LinkTypeId = linkTypeId;
            }
            // to ensure "sourceEntityId" is required (not null)
            if (sourceEntityId == null)
            {
                throw new InvalidDataException("sourceEntityId is a required property for LinkModel and cannot be null");
            }
            else
            {
                SourceEntityId = sourceEntityId;
            }
            // to ensure "targetEntityId" is required (not null)
            if (targetEntityId == null)
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as LinkModel);
        }

        /// <summary>
        /// Returns true if LinkModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkModel input)
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
                    this.IsActive == input.IsActive ||
                    (this.IsActive != null &&
                    this.IsActive.Equals(input.IsActive))
                ) && 
                (
                    this.LinkTypeId == input.LinkTypeId ||
                    (this.LinkTypeId != null &&
                    this.LinkTypeId.Equals(input.LinkTypeId))
                ) && 
                (
                    this.SourceEntityId == input.SourceEntityId ||
                    (this.SourceEntityId != null &&
                    this.SourceEntityId.Equals(input.SourceEntityId))
                ) && 
                (
                    this.TargetEntityId == input.TargetEntityId ||
                    (this.TargetEntityId != null &&
                    this.TargetEntityId.Equals(input.TargetEntityId))
                ) && 
                (
                    this.LinkEntityId == input.LinkEntityId ||
                    (this.LinkEntityId != null &&
                    this.LinkEntityId.Equals(input.LinkEntityId))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
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
                if (this.IsActive != null)
                    hashCode = hashCode * 59 + this.IsActive.GetHashCode();
                if (this.LinkTypeId != null)
                    hashCode = hashCode * 59 + this.LinkTypeId.GetHashCode();
                if (this.SourceEntityId != null)
                    hashCode = hashCode * 59 + this.SourceEntityId.GetHashCode();
                if (this.TargetEntityId != null)
                    hashCode = hashCode * 59 + this.TargetEntityId.GetHashCode();
                if (this.LinkEntityId != null)
                    hashCode = hashCode * 59 + this.LinkEntityId.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                return hashCode;
            }
        }
    }

}
