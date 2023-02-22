using System;
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
        public EntitySummaryModel(int? id = default(int?), string displayName = default, string displayDescription = default, string version = default, string lockedBy = default, string createdBy = default, string createdDate = default, string formattedCreatedDate = default, string modifiedBy = default, string modifiedDate = default, string formattedModifiedDate = default, string resourceUrl = default, string entityTypeId = default, string entityTypeDisplayName = default, int? completeness = default(int?), string fieldSetId = default, string fieldSetName = default, int? segmentId = default(int?), string segmentName = default)
        {
            Id = id;
            DisplayName = displayName;
            DisplayDescription = displayDescription;
            Version = version;
            LockedBy = lockedBy;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            FormattedCreatedDate = formattedCreatedDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
            FormattedModifiedDate = formattedModifiedDate;
            ResourceUrl = resourceUrl;
            EntityTypeId = entityTypeId;
            EntityTypeDisplayName = entityTypeDisplayName;
            Completeness = completeness;
            FieldSetId = fieldSetId;
            FieldSetName = fieldSetName;
            SegmentId = segmentId;
            SegmentName = segmentName;
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
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as EntitySummaryModel);
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
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) && 
                (
                    DisplayName == input.DisplayName ||
                    (DisplayName != null &&
                    DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    DisplayDescription == input.DisplayDescription ||
                    (DisplayDescription != null &&
                    DisplayDescription.Equals(input.DisplayDescription))
                ) && 
                (
                    Version == input.Version ||
                    (Version != null &&
                    Version.Equals(input.Version))
                ) && 
                (
                    LockedBy == input.LockedBy ||
                    (LockedBy != null &&
                    LockedBy.Equals(input.LockedBy))
                ) && 
                (
                    CreatedBy == input.CreatedBy ||
                    (CreatedBy != null &&
                    CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    CreatedDate == input.CreatedDate ||
                    (CreatedDate != null &&
                    CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    FormattedCreatedDate == input.FormattedCreatedDate ||
                    (FormattedCreatedDate != null &&
                    FormattedCreatedDate.Equals(input.FormattedCreatedDate))
                ) && 
                (
                    ModifiedBy == input.ModifiedBy ||
                    (ModifiedBy != null &&
                    ModifiedBy.Equals(input.ModifiedBy))
                ) && 
                (
                    ModifiedDate == input.ModifiedDate ||
                    (ModifiedDate != null &&
                    ModifiedDate.Equals(input.ModifiedDate))
                ) && 
                (
                    FormattedModifiedDate == input.FormattedModifiedDate ||
                    (FormattedModifiedDate != null &&
                    FormattedModifiedDate.Equals(input.FormattedModifiedDate))
                ) && 
                (
                    ResourceUrl == input.ResourceUrl ||
                    (ResourceUrl != null &&
                    ResourceUrl.Equals(input.ResourceUrl))
                ) && 
                (
                    EntityTypeId == input.EntityTypeId ||
                    (EntityTypeId != null &&
                    EntityTypeId.Equals(input.EntityTypeId))
                ) && 
                (
                    EntityTypeDisplayName == input.EntityTypeDisplayName ||
                    (EntityTypeDisplayName != null &&
                    EntityTypeDisplayName.Equals(input.EntityTypeDisplayName))
                ) && 
                (
                    Completeness == input.Completeness ||
                    (Completeness != null &&
                    Completeness.Equals(input.Completeness))
                ) && 
                (
                    FieldSetId == input.FieldSetId ||
                    (FieldSetId != null &&
                    FieldSetId.Equals(input.FieldSetId))
                ) && 
                (
                    FieldSetName == input.FieldSetName ||
                    (FieldSetName != null &&
                    FieldSetName.Equals(input.FieldSetName))
                ) && 
                (
                    SegmentId == input.SegmentId ||
                    (SegmentId != null &&
                    SegmentId.Equals(input.SegmentId))
                ) && 
                (
                    SegmentName == input.SegmentName ||
                    (SegmentName != null &&
                    SegmentName.Equals(input.SegmentName))
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
                if (DisplayName != null)
                    hashCode = hashCode * 59 + DisplayName.GetHashCode();
                if (DisplayDescription != null)
                    hashCode = hashCode * 59 + DisplayDescription.GetHashCode();
                if (Version != null)
                    hashCode = hashCode * 59 + Version.GetHashCode();
                if (LockedBy != null)
                    hashCode = hashCode * 59 + LockedBy.GetHashCode();
                if (CreatedBy != null)
                    hashCode = hashCode * 59 + CreatedBy.GetHashCode();
                if (CreatedDate != null)
                    hashCode = hashCode * 59 + CreatedDate.GetHashCode();
                if (FormattedCreatedDate != null)
                    hashCode = hashCode * 59 + FormattedCreatedDate.GetHashCode();
                if (ModifiedBy != null)
                    hashCode = hashCode * 59 + ModifiedBy.GetHashCode();
                if (ModifiedDate != null)
                    hashCode = hashCode * 59 + ModifiedDate.GetHashCode();
                if (FormattedModifiedDate != null)
                    hashCode = hashCode * 59 + FormattedModifiedDate.GetHashCode();
                if (ResourceUrl != null)
                    hashCode = hashCode * 59 + ResourceUrl.GetHashCode();
                if (EntityTypeId != null)
                    hashCode = hashCode * 59 + EntityTypeId.GetHashCode();
                if (EntityTypeDisplayName != null)
                    hashCode = hashCode * 59 + EntityTypeDisplayName.GetHashCode();
                if (Completeness != null)
                    hashCode = hashCode * 59 + Completeness.GetHashCode();
                if (FieldSetId != null)
                    hashCode = hashCode * 59 + FieldSetId.GetHashCode();
                if (FieldSetName != null)
                    hashCode = hashCode * 59 + FieldSetName.GetHashCode();
                if (SegmentId != null)
                    hashCode = hashCode * 59 + SegmentId.GetHashCode();
                if (SegmentName != null)
                    hashCode = hashCode * 59 + SegmentName.GetHashCode();
                return hashCode;
            }
        }
    }

}
