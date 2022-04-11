using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// EntitySummaryModel
    /// </summary>
    [DataContract]
    public class EntitySummaryModel :  IEquatable<EntitySummaryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySummaryModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="displayDescription">displayDescription.</param>
        /// <param name="version">version.</param>
        /// <param name="lockedBy">lockedBy.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdDate">createdDate.</param>
        /// <param name="formattedCreatedDate">formattedCreatedDate.</param>
        /// <param name="modifiedBy">modifiedBy.</param>
        /// <param name="modifiedDate">modifiedDate.</param>
        /// <param name="formattedModifiedDate">formattedModifiedDate.</param>
        /// <param name="resourceUrl">resourceUrl.</param>
        /// <param name="entityTypeId">entityTypeId.</param>
        /// <param name="entityTypeDisplayName">entityTypeDisplayName.</param>
        /// <param name="completeness">completeness.</param>
        /// <param name="fieldSetId">fieldSetId.</param>
        /// <param name="fieldSetName">fieldSetName.</param>
        /// <param name="segmentId">segmentId.</param>
        /// <param name="segmentName">segmentName.</param>
        public EntitySummaryModel(int? id = default(int?), string displayName = default(string), string displayDescription = default(string), string version = default(string), string lockedBy = default(string), string createdBy = default(string), string createdDate = default(string), string formattedCreatedDate = default(string), string modifiedBy = default(string), string modifiedDate = default(string), string formattedModifiedDate = default(string), string resourceUrl = default(string), string entityTypeId = default(string), string entityTypeDisplayName = default(string), int? completeness = default(int?), string fieldSetId = default(string), string fieldSetName = default(string), int? segmentId = default(int?), string segmentName = default(string))
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.DisplayDescription = displayDescription;
            this.Version = version;
            this.LockedBy = lockedBy;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.FormattedCreatedDate = formattedCreatedDate;
            this.ModifiedBy = modifiedBy;
            this.ModifiedDate = modifiedDate;
            this.FormattedModifiedDate = formattedModifiedDate;
            this.ResourceUrl = resourceUrl;
            this.EntityTypeId = entityTypeId;
            this.EntityTypeDisplayName = entityTypeDisplayName;
            this.Completeness = completeness;
            this.FieldSetId = fieldSetId;
            this.FieldSetName = fieldSetName;
            this.SegmentId = segmentId;
            this.SegmentName = segmentName;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets DisplayDescription
        /// </summary>
        [DataMember(Name="displayDescription", EmitDefaultValue=false)]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or Sets LockedBy
        /// </summary>
        [DataMember(Name="lockedBy", EmitDefaultValue=false)]
        public string LockedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets FormattedCreatedDate
        /// </summary>
        [DataMember(Name="formattedCreatedDate", EmitDefaultValue=false)]
        public string FormattedCreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedBy
        /// </summary>
        [DataMember(Name="modifiedBy", EmitDefaultValue=false)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedDate
        /// </summary>
        [DataMember(Name="modifiedDate", EmitDefaultValue=false)]
        public string ModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets FormattedModifiedDate
        /// </summary>
        [DataMember(Name="formattedModifiedDate", EmitDefaultValue=false)]
        public string FormattedModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets ResourceUrl
        /// </summary>
        [DataMember(Name="resourceUrl", EmitDefaultValue=false)]
        public string ResourceUrl { get; set; }

        /// <summary>
        /// Gets or Sets EntityTypeId
        /// </summary>
        [DataMember(Name="entityTypeId", EmitDefaultValue=false)]
        public string EntityTypeId { get; set; }

        /// <summary>
        /// Gets or Sets EntityTypeDisplayName
        /// </summary>
        [DataMember(Name="entityTypeDisplayName", EmitDefaultValue=false)]
        public string EntityTypeDisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Completeness
        /// </summary>
        [DataMember(Name="completeness", EmitDefaultValue=false)]
        public int? Completeness { get; set; }

        /// <summary>
        /// Gets or Sets FieldSetId
        /// </summary>
        [DataMember(Name="fieldSetId", EmitDefaultValue=false)]
        public string FieldSetId { get; set; }

        /// <summary>
        /// Gets or Sets FieldSetName
        /// </summary>
        [DataMember(Name="fieldSetName", EmitDefaultValue=false)]
        public string FieldSetName { get; set; }

        /// <summary>
        /// Gets or Sets SegmentId
        /// </summary>
        [DataMember(Name="segmentId", EmitDefaultValue=false)]
        public int? SegmentId { get; set; }

        /// <summary>
        /// Gets or Sets SegmentName
        /// </summary>
        [DataMember(Name="segmentName", EmitDefaultValue=false)]
        public string SegmentName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntitySummaryModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  DisplayDescription: ").Append(DisplayDescription).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  LockedBy: ").Append(LockedBy).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  FormattedCreatedDate: ").Append(FormattedCreatedDate).Append("\n");
            sb.Append("  ModifiedBy: ").Append(ModifiedBy).Append("\n");
            sb.Append("  ModifiedDate: ").Append(ModifiedDate).Append("\n");
            sb.Append("  FormattedModifiedDate: ").Append(FormattedModifiedDate).Append("\n");
            sb.Append("  ResourceUrl: ").Append(ResourceUrl).Append("\n");
            sb.Append("  EntityTypeId: ").Append(EntityTypeId).Append("\n");
            sb.Append("  EntityTypeDisplayName: ").Append(EntityTypeDisplayName).Append("\n");
            sb.Append("  Completeness: ").Append(Completeness).Append("\n");
            sb.Append("  FieldSetId: ").Append(FieldSetId).Append("\n");
            sb.Append("  FieldSetName: ").Append(FieldSetName).Append("\n");
            sb.Append("  SegmentId: ").Append(SegmentId).Append("\n");
            sb.Append("  SegmentName: ").Append(SegmentName).Append("\n");
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
            return this.Equals(input as EntitySummaryModel);
        }

        /// <summary>
        /// Returns true if EntitySummaryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntitySummaryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntitySummaryModel input)
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
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.DisplayDescription == input.DisplayDescription ||
                    (this.DisplayDescription != null &&
                    this.DisplayDescription.Equals(input.DisplayDescription))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.LockedBy == input.LockedBy ||
                    (this.LockedBy != null &&
                    this.LockedBy.Equals(input.LockedBy))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.FormattedCreatedDate == input.FormattedCreatedDate ||
                    (this.FormattedCreatedDate != null &&
                    this.FormattedCreatedDate.Equals(input.FormattedCreatedDate))
                ) && 
                (
                    this.ModifiedBy == input.ModifiedBy ||
                    (this.ModifiedBy != null &&
                    this.ModifiedBy.Equals(input.ModifiedBy))
                ) && 
                (
                    this.ModifiedDate == input.ModifiedDate ||
                    (this.ModifiedDate != null &&
                    this.ModifiedDate.Equals(input.ModifiedDate))
                ) && 
                (
                    this.FormattedModifiedDate == input.FormattedModifiedDate ||
                    (this.FormattedModifiedDate != null &&
                    this.FormattedModifiedDate.Equals(input.FormattedModifiedDate))
                ) && 
                (
                    this.ResourceUrl == input.ResourceUrl ||
                    (this.ResourceUrl != null &&
                    this.ResourceUrl.Equals(input.ResourceUrl))
                ) && 
                (
                    this.EntityTypeId == input.EntityTypeId ||
                    (this.EntityTypeId != null &&
                    this.EntityTypeId.Equals(input.EntityTypeId))
                ) && 
                (
                    this.EntityTypeDisplayName == input.EntityTypeDisplayName ||
                    (this.EntityTypeDisplayName != null &&
                    this.EntityTypeDisplayName.Equals(input.EntityTypeDisplayName))
                ) && 
                (
                    this.Completeness == input.Completeness ||
                    (this.Completeness != null &&
                    this.Completeness.Equals(input.Completeness))
                ) && 
                (
                    this.FieldSetId == input.FieldSetId ||
                    (this.FieldSetId != null &&
                    this.FieldSetId.Equals(input.FieldSetId))
                ) && 
                (
                    this.FieldSetName == input.FieldSetName ||
                    (this.FieldSetName != null &&
                    this.FieldSetName.Equals(input.FieldSetName))
                ) && 
                (
                    this.SegmentId == input.SegmentId ||
                    (this.SegmentId != null &&
                    this.SegmentId.Equals(input.SegmentId))
                ) && 
                (
                    this.SegmentName == input.SegmentName ||
                    (this.SegmentName != null &&
                    this.SegmentName.Equals(input.SegmentName))
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
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.DisplayDescription != null)
                    hashCode = hashCode * 59 + this.DisplayDescription.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.LockedBy != null)
                    hashCode = hashCode * 59 + this.LockedBy.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.FormattedCreatedDate != null)
                    hashCode = hashCode * 59 + this.FormattedCreatedDate.GetHashCode();
                if (this.ModifiedBy != null)
                    hashCode = hashCode * 59 + this.ModifiedBy.GetHashCode();
                if (this.ModifiedDate != null)
                    hashCode = hashCode * 59 + this.ModifiedDate.GetHashCode();
                if (this.FormattedModifiedDate != null)
                    hashCode = hashCode * 59 + this.FormattedModifiedDate.GetHashCode();
                if (this.ResourceUrl != null)
                    hashCode = hashCode * 59 + this.ResourceUrl.GetHashCode();
                if (this.EntityTypeId != null)
                    hashCode = hashCode * 59 + this.EntityTypeId.GetHashCode();
                if (this.EntityTypeDisplayName != null)
                    hashCode = hashCode * 59 + this.EntityTypeDisplayName.GetHashCode();
                if (this.Completeness != null)
                    hashCode = hashCode * 59 + this.Completeness.GetHashCode();
                if (this.FieldSetId != null)
                    hashCode = hashCode * 59 + this.FieldSetId.GetHashCode();
                if (this.FieldSetName != null)
                    hashCode = hashCode * 59 + this.FieldSetName.GetHashCode();
                if (this.SegmentId != null)
                    hashCode = hashCode * 59 + this.SegmentId.GetHashCode();
                if (this.SegmentName != null)
                    hashCode = hashCode * 59 + this.SegmentName.GetHashCode();
                return hashCode;
            }
        }
    }

}
