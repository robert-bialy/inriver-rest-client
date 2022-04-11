using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// ChannelSummaryModel
    /// </summary>
    [DataContract]
    public class ChannelSummaryModel :  IEquatable<ChannelSummaryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelSummaryModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="displayDescription">displayDescription.</param>
        /// <param name="entityTypeId">entityTypeId.</param>
        /// <param name="createdDate">createdDate.</param>
        /// <param name="modifiedDate">modifiedDate.</param>
        /// <param name="isPublished">isPublished.</param>
        public ChannelSummaryModel(int? id = default(int?), string displayName = default(string), string displayDescription = default(string), string entityTypeId = default(string), string createdDate = default(string), string modifiedDate = default(string), bool? isPublished = default(bool?))
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.DisplayDescription = displayDescription;
            this.EntityTypeId = entityTypeId;
            this.CreatedDate = createdDate;
            this.ModifiedDate = modifiedDate;
            this.IsPublished = isPublished;
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
        /// Gets or Sets EntityTypeId
        /// </summary>
        [DataMember(Name="entityTypeId", EmitDefaultValue=false)]
        public string EntityTypeId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedDate
        /// </summary>
        [DataMember(Name="modifiedDate", EmitDefaultValue=false)]
        public string ModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets IsPublished
        /// </summary>
        [DataMember(Name="isPublished", EmitDefaultValue=false)]
        public bool? IsPublished { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelSummaryModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  DisplayDescription: ").Append(DisplayDescription).Append("\n");
            sb.Append("  EntityTypeId: ").Append(EntityTypeId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  ModifiedDate: ").Append(ModifiedDate).Append("\n");
            sb.Append("  IsPublished: ").Append(IsPublished).Append("\n");
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
            return this.Equals(input as ChannelSummaryModel);
        }

        /// <summary>
        /// Returns true if ChannelSummaryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ChannelSummaryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelSummaryModel input)
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
                    this.EntityTypeId == input.EntityTypeId ||
                    (this.EntityTypeId != null &&
                    this.EntityTypeId.Equals(input.EntityTypeId))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.ModifiedDate == input.ModifiedDate ||
                    (this.ModifiedDate != null &&
                    this.ModifiedDate.Equals(input.ModifiedDate))
                ) && 
                (
                    this.IsPublished == input.IsPublished ||
                    (this.IsPublished != null &&
                    this.IsPublished.Equals(input.IsPublished))
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
                if (this.EntityTypeId != null)
                    hashCode = hashCode * 59 + this.EntityTypeId.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.ModifiedDate != null)
                    hashCode = hashCode * 59 + this.ModifiedDate.GetHashCode();
                if (this.IsPublished != null)
                    hashCode = hashCode * 59 + this.IsPublished.GetHashCode();
                return hashCode;
            }
        }
    }

}
