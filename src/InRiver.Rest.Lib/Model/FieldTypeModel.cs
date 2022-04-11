using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FieldTypeModel
    /// </summary>
    [DataContract]
    public class FieldTypeModel :  IEquatable<FieldTypeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldTypeModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId">fieldTypeId.</param>
        /// <param name="fieldTypeDisplayName">fieldTypeDisplayName.</param>
        /// <param name="fieldTypeDescription">fieldTypeDescription.</param>
        /// <param name="fieldDataType">fieldDataType.</param>
        /// <param name="isMultiValue">isMultiValue.</param>
        /// <param name="isHidden">isHidden.</param>
        /// <param name="isReadOnly">isReadOnly.</param>
        /// <param name="isMandatory">isMandatory.</param>
        /// <param name="isUnique">isUnique.</param>
        /// <param name="isExcludedFromDefaultView">isExcludedFromDefaultView.</param>
        /// <param name="includedInFieldSets">includedInFieldSets.</param>
        /// <param name="categoryId">categoryId.</param>
        /// <param name="index">index.</param>
        /// <param name="cvlId">cvlId.</param>
        /// <param name="parentCvlId">parentCvlId.</param>
        /// <param name="settings">settings.</param>
        public FieldTypeModel(string fieldTypeId = default(string), string fieldTypeDisplayName = default(string), string fieldTypeDescription = default(string), string fieldDataType = default(string), bool? isMultiValue = default(bool?), bool? isHidden = default(bool?), bool? isReadOnly = default(bool?), bool? isMandatory = default(bool?), bool? isUnique = default(bool?), bool? isExcludedFromDefaultView = default(bool?), List<string> includedInFieldSets = default(List<string>), string categoryId = default(string), int? index = default(int?), string cvlId = default(string), string parentCvlId = default(string), Dictionary<string, string> settings = default(Dictionary<string, string>))
        {
            this.FieldTypeId = fieldTypeId;
            this.FieldTypeDisplayName = fieldTypeDisplayName;
            this.FieldTypeDescription = fieldTypeDescription;
            this.FieldDataType = fieldDataType;
            this.IsMultiValue = isMultiValue;
            this.IsHidden = isHidden;
            this.IsReadOnly = isReadOnly;
            this.IsMandatory = isMandatory;
            this.IsUnique = isUnique;
            this.IsExcludedFromDefaultView = isExcludedFromDefaultView;
            this.IncludedInFieldSets = includedInFieldSets;
            this.CategoryId = categoryId;
            this.Index = index;
            this.CvlId = cvlId;
            this.ParentCvlId = parentCvlId;
            this.Settings = settings;
        }
        
        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name="fieldTypeId", EmitDefaultValue=false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets FieldTypeDisplayName
        /// </summary>
        [DataMember(Name="fieldTypeDisplayName", EmitDefaultValue=false)]
        public string FieldTypeDisplayName { get; set; }

        /// <summary>
        /// Gets or Sets FieldTypeDescription
        /// </summary>
        [DataMember(Name="fieldTypeDescription", EmitDefaultValue=false)]
        public string FieldTypeDescription { get; set; }

        /// <summary>
        /// Gets or Sets FieldDataType
        /// </summary>
        [DataMember(Name="fieldDataType", EmitDefaultValue=false)]
        public string FieldDataType { get; set; }

        /// <summary>
        /// Gets or Sets IsMultiValue
        /// </summary>
        [DataMember(Name="isMultiValue", EmitDefaultValue=false)]
        public bool? IsMultiValue { get; set; }

        /// <summary>
        /// Gets or Sets IsHidden
        /// </summary>
        [DataMember(Name="isHidden", EmitDefaultValue=false)]
        public bool? IsHidden { get; set; }

        /// <summary>
        /// Gets or Sets IsReadOnly
        /// </summary>
        [DataMember(Name="isReadOnly", EmitDefaultValue=false)]
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// Gets or Sets IsMandatory
        /// </summary>
        [DataMember(Name="isMandatory", EmitDefaultValue=false)]
        public bool? IsMandatory { get; set; }

        /// <summary>
        /// Gets or Sets IsUnique
        /// </summary>
        [DataMember(Name="isUnique", EmitDefaultValue=false)]
        public bool? IsUnique { get; set; }

        /// <summary>
        /// Gets or Sets IsExcludedFromDefaultView
        /// </summary>
        [DataMember(Name="isExcludedFromDefaultView", EmitDefaultValue=false)]
        public bool? IsExcludedFromDefaultView { get; set; }

        /// <summary>
        /// Gets or Sets IncludedInFieldSets
        /// </summary>
        [DataMember(Name="includedInFieldSets", EmitDefaultValue=false)]
        public List<string> IncludedInFieldSets { get; set; }

        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [DataMember(Name="categoryId", EmitDefaultValue=false)]
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets CvlId
        /// </summary>
        [DataMember(Name="cvlId", EmitDefaultValue=false)]
        public string CvlId { get; set; }

        /// <summary>
        /// Gets or Sets ParentCvlId
        /// </summary>
        [DataMember(Name="parentCvlId", EmitDefaultValue=false)]
        public string ParentCvlId { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name="settings", EmitDefaultValue=false)]
        public Dictionary<string, string> Settings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FieldTypeModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
            sb.Append("  FieldTypeDisplayName: ").Append(FieldTypeDisplayName).Append("\n");
            sb.Append("  FieldTypeDescription: ").Append(FieldTypeDescription).Append("\n");
            sb.Append("  FieldDataType: ").Append(FieldDataType).Append("\n");
            sb.Append("  IsMultiValue: ").Append(IsMultiValue).Append("\n");
            sb.Append("  IsHidden: ").Append(IsHidden).Append("\n");
            sb.Append("  IsReadOnly: ").Append(IsReadOnly).Append("\n");
            sb.Append("  IsMandatory: ").Append(IsMandatory).Append("\n");
            sb.Append("  IsUnique: ").Append(IsUnique).Append("\n");
            sb.Append("  IsExcludedFromDefaultView: ").Append(IsExcludedFromDefaultView).Append("\n");
            sb.Append("  IncludedInFieldSets: ").Append(IncludedInFieldSets).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  CvlId: ").Append(CvlId).Append("\n");
            sb.Append("  ParentCvlId: ").Append(ParentCvlId).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
            return this.Equals(input as FieldTypeModel);
        }

        /// <summary>
        /// Returns true if FieldTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FieldTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FieldTypeModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FieldTypeId == input.FieldTypeId ||
                    (this.FieldTypeId != null &&
                    this.FieldTypeId.Equals(input.FieldTypeId))
                ) && 
                (
                    this.FieldTypeDisplayName == input.FieldTypeDisplayName ||
                    (this.FieldTypeDisplayName != null &&
                    this.FieldTypeDisplayName.Equals(input.FieldTypeDisplayName))
                ) && 
                (
                    this.FieldTypeDescription == input.FieldTypeDescription ||
                    (this.FieldTypeDescription != null &&
                    this.FieldTypeDescription.Equals(input.FieldTypeDescription))
                ) && 
                (
                    this.FieldDataType == input.FieldDataType ||
                    (this.FieldDataType != null &&
                    this.FieldDataType.Equals(input.FieldDataType))
                ) && 
                (
                    this.IsMultiValue == input.IsMultiValue ||
                    (this.IsMultiValue != null &&
                    this.IsMultiValue.Equals(input.IsMultiValue))
                ) && 
                (
                    this.IsHidden == input.IsHidden ||
                    (this.IsHidden != null &&
                    this.IsHidden.Equals(input.IsHidden))
                ) && 
                (
                    this.IsReadOnly == input.IsReadOnly ||
                    (this.IsReadOnly != null &&
                    this.IsReadOnly.Equals(input.IsReadOnly))
                ) && 
                (
                    this.IsMandatory == input.IsMandatory ||
                    (this.IsMandatory != null &&
                    this.IsMandatory.Equals(input.IsMandatory))
                ) && 
                (
                    this.IsUnique == input.IsUnique ||
                    (this.IsUnique != null &&
                    this.IsUnique.Equals(input.IsUnique))
                ) && 
                (
                    this.IsExcludedFromDefaultView == input.IsExcludedFromDefaultView ||
                    (this.IsExcludedFromDefaultView != null &&
                    this.IsExcludedFromDefaultView.Equals(input.IsExcludedFromDefaultView))
                ) && 
                (
                    this.IncludedInFieldSets == input.IncludedInFieldSets ||
                    this.IncludedInFieldSets != null &&
                    this.IncludedInFieldSets.SequenceEqual(input.IncludedInFieldSets)
                ) && 
                (
                    this.CategoryId == input.CategoryId ||
                    (this.CategoryId != null &&
                    this.CategoryId.Equals(input.CategoryId))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.CvlId == input.CvlId ||
                    (this.CvlId != null &&
                    this.CvlId.Equals(input.CvlId))
                ) && 
                (
                    this.ParentCvlId == input.ParentCvlId ||
                    (this.ParentCvlId != null &&
                    this.ParentCvlId.Equals(input.ParentCvlId))
                ) && 
                (
                    this.Settings == input.Settings ||
                    this.Settings != null &&
                    this.Settings.SequenceEqual(input.Settings)
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
                if (this.FieldTypeId != null)
                    hashCode = hashCode * 59 + this.FieldTypeId.GetHashCode();
                if (this.FieldTypeDisplayName != null)
                    hashCode = hashCode * 59 + this.FieldTypeDisplayName.GetHashCode();
                if (this.FieldTypeDescription != null)
                    hashCode = hashCode * 59 + this.FieldTypeDescription.GetHashCode();
                if (this.FieldDataType != null)
                    hashCode = hashCode * 59 + this.FieldDataType.GetHashCode();
                if (this.IsMultiValue != null)
                    hashCode = hashCode * 59 + this.IsMultiValue.GetHashCode();
                if (this.IsHidden != null)
                    hashCode = hashCode * 59 + this.IsHidden.GetHashCode();
                if (this.IsReadOnly != null)
                    hashCode = hashCode * 59 + this.IsReadOnly.GetHashCode();
                if (this.IsMandatory != null)
                    hashCode = hashCode * 59 + this.IsMandatory.GetHashCode();
                if (this.IsUnique != null)
                    hashCode = hashCode * 59 + this.IsUnique.GetHashCode();
                if (this.IsExcludedFromDefaultView != null)
                    hashCode = hashCode * 59 + this.IsExcludedFromDefaultView.GetHashCode();
                if (this.IncludedInFieldSets != null)
                    hashCode = hashCode * 59 + this.IncludedInFieldSets.GetHashCode();
                if (this.CategoryId != null)
                    hashCode = hashCode * 59 + this.CategoryId.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.CvlId != null)
                    hashCode = hashCode * 59 + this.CvlId.GetHashCode();
                if (this.ParentCvlId != null)
                    hashCode = hashCode * 59 + this.ParentCvlId.GetHashCode();
                if (this.Settings != null)
                    hashCode = hashCode * 59 + this.Settings.GetHashCode();
                return hashCode;
            }
        }
    }

}
