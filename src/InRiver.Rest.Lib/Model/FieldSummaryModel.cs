using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FieldSummaryModel
    /// </summary>
    [DataContract]
    public class FieldSummaryModel :  IEquatable<FieldSummaryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldSummaryModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId">fieldTypeId.</param>
        /// <param name="entityId">entityId.</param>
        /// <param name="fieldTypeDisplayName">fieldTypeDisplayName.</param>
        /// <param name="fieldTypeDescription">fieldTypeDescription.</param>
        /// <param name="fieldDataType">fieldDataType.</param>
        /// <param name="value">value.</param>
        /// <param name="displayValue">displayValue.</param>
        /// <param name="isMultiValue">isMultiValue.</param>
        /// <param name="isHidden">isHidden.</param>
        /// <param name="isReadOnly">isReadOnly.</param>
        /// <param name="isMandatory">isMandatory.</param>
        /// <param name="isUnique">isUnique.</param>
        /// <param name="isExcludedFromDefaultView">isExcludedFromDefaultView.</param>
        /// <param name="includedInFieldSets">includedInFieldSets.</param>
        /// <param name="categoryId">categoryId.</param>
        /// <param name="categoryName">categoryName.</param>
        /// <param name="index">index.</param>
        /// <param name="revision">revision.</param>
        /// <param name="cvlId">cvlId.</param>
        /// <param name="parentCvlId">parentCvlId.</param>
        /// <param name="settings">settings.</param>
        public FieldSummaryModel(string fieldTypeId = default, int? entityId = default(int?), string fieldTypeDisplayName = default, string fieldTypeDescription = default, string fieldDataType = default, object value = default(object), object displayValue = default(object), bool? isMultiValue = default(bool?), bool? isHidden = default(bool?), bool? isReadOnly = default(bool?), bool? isMandatory = default(bool?), bool? isUnique = default(bool?), bool? isExcludedFromDefaultView = default(bool?), List<string> includedInFieldSets = default(List<string>), string categoryId = default, string categoryName = default, int? index = default(int?), int? revision = default(int?), string cvlId = default, string parentCvlId = default, Dictionary<string, string> settings = default(Dictionary<string, string>))
        {
            FieldTypeId = fieldTypeId;
            EntityId = entityId;
            FieldTypeDisplayName = fieldTypeDisplayName;
            FieldTypeDescription = fieldTypeDescription;
            FieldDataType = fieldDataType;
            Value = value;
            DisplayValue = displayValue;
            IsMultiValue = isMultiValue;
            IsHidden = isHidden;
            IsReadOnly = isReadOnly;
            IsMandatory = isMandatory;
            IsUnique = isUnique;
            IsExcludedFromDefaultView = isExcludedFromDefaultView;
            IncludedInFieldSets = includedInFieldSets;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Index = index;
            Revision = revision;
            CvlId = cvlId;
            ParentCvlId = parentCvlId;
            Settings = settings;
        }
        
        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name="fieldTypeId", EmitDefaultValue=false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entityId", EmitDefaultValue=false)]
        public int? EntityId { get; set; }

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
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public object Value { get; set; }

        /// <summary>
        /// Gets or Sets DisplayValue
        /// </summary>
        [DataMember(Name="displayValue", EmitDefaultValue=false)]
        public object DisplayValue { get; set; }

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
        /// Gets or Sets CategoryName
        /// </summary>
        [DataMember(Name="categoryName", EmitDefaultValue=false)]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets Revision
        /// </summary>
        [DataMember(Name="revision", EmitDefaultValue=false)]
        public int? Revision { get; set; }

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
            sb.Append("class FieldSummaryModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  FieldTypeDisplayName: ").Append(FieldTypeDisplayName).Append("\n");
            sb.Append("  FieldTypeDescription: ").Append(FieldTypeDescription).Append("\n");
            sb.Append("  FieldDataType: ").Append(FieldDataType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  DisplayValue: ").Append(DisplayValue).Append("\n");
            sb.Append("  IsMultiValue: ").Append(IsMultiValue).Append("\n");
            sb.Append("  IsHidden: ").Append(IsHidden).Append("\n");
            sb.Append("  IsReadOnly: ").Append(IsReadOnly).Append("\n");
            sb.Append("  IsMandatory: ").Append(IsMandatory).Append("\n");
            sb.Append("  IsUnique: ").Append(IsUnique).Append("\n");
            sb.Append("  IsExcludedFromDefaultView: ").Append(IsExcludedFromDefaultView).Append("\n");
            sb.Append("  IncludedInFieldSets: ").Append(IncludedInFieldSets).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  CategoryName: ").Append(CategoryName).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
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
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as FieldSummaryModel);
        }

        /// <summary>
        /// Returns true if FieldSummaryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FieldSummaryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FieldSummaryModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    FieldTypeId == input.FieldTypeId ||
                   (FieldTypeId != null &&
                    FieldTypeId.Equals(input.FieldTypeId))
                ) && 
               (
                    EntityId == input.EntityId ||
                   (EntityId != null &&
                    EntityId.Equals(input.EntityId))
                ) && 
               (
                    FieldTypeDisplayName == input.FieldTypeDisplayName ||
                   (FieldTypeDisplayName != null &&
                    FieldTypeDisplayName.Equals(input.FieldTypeDisplayName))
                ) && 
               (
                    FieldTypeDescription == input.FieldTypeDescription ||
                   (FieldTypeDescription != null &&
                    FieldTypeDescription.Equals(input.FieldTypeDescription))
                ) && 
               (
                    FieldDataType == input.FieldDataType ||
                   (FieldDataType != null &&
                    FieldDataType.Equals(input.FieldDataType))
                ) && 
               (
                    Value == input.Value ||
                   (Value != null &&
                    Value.Equals(input.Value))
                ) && 
               (
                    DisplayValue == input.DisplayValue ||
                   (DisplayValue != null &&
                    DisplayValue.Equals(input.DisplayValue))
                ) && 
               (
                    IsMultiValue == input.IsMultiValue ||
                   (IsMultiValue != null &&
                    IsMultiValue.Equals(input.IsMultiValue))
                ) && 
               (
                    IsHidden == input.IsHidden ||
                   (IsHidden != null &&
                    IsHidden.Equals(input.IsHidden))
                ) && 
               (
                    IsReadOnly == input.IsReadOnly ||
                   (IsReadOnly != null &&
                    IsReadOnly.Equals(input.IsReadOnly))
                ) && 
               (
                    IsMandatory == input.IsMandatory ||
                   (IsMandatory != null &&
                    IsMandatory.Equals(input.IsMandatory))
                ) && 
               (
                    IsUnique == input.IsUnique ||
                   (IsUnique != null &&
                    IsUnique.Equals(input.IsUnique))
                ) && 
               (
                    IsExcludedFromDefaultView == input.IsExcludedFromDefaultView ||
                   (IsExcludedFromDefaultView != null &&
                    IsExcludedFromDefaultView.Equals(input.IsExcludedFromDefaultView))
                ) && 
               (
                    IncludedInFieldSets == input.IncludedInFieldSets ||
                    IncludedInFieldSets != null &&
                    IncludedInFieldSets.SequenceEqual(input.IncludedInFieldSets)
                ) && 
               (
                    CategoryId == input.CategoryId ||
                   (CategoryId != null &&
                    CategoryId.Equals(input.CategoryId))
                ) && 
               (
                    CategoryName == input.CategoryName ||
                   (CategoryName != null &&
                    CategoryName.Equals(input.CategoryName))
                ) && 
               (
                    Index == input.Index ||
                   (Index != null &&
                    Index.Equals(input.Index))
                ) && 
               (
                    Revision == input.Revision ||
                   (Revision != null &&
                    Revision.Equals(input.Revision))
                ) && 
               (
                    CvlId == input.CvlId ||
                   (CvlId != null &&
                    CvlId.Equals(input.CvlId))
                ) && 
               (
                    ParentCvlId == input.ParentCvlId ||
                   (ParentCvlId != null &&
                    ParentCvlId.Equals(input.ParentCvlId))
                ) && 
               (
                    Settings == input.Settings ||
                    Settings != null &&
                    Settings.SequenceEqual(input.Settings)
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
                if(FieldTypeId != null)
                    hashCode = hashCode * 59 + FieldTypeId.GetHashCode();
                if(EntityId != null)
                    hashCode = hashCode * 59 + EntityId.GetHashCode();
                if(FieldTypeDisplayName != null)
                    hashCode = hashCode * 59 + FieldTypeDisplayName.GetHashCode();
                if(FieldTypeDescription != null)
                    hashCode = hashCode * 59 + FieldTypeDescription.GetHashCode();
                if(FieldDataType != null)
                    hashCode = hashCode * 59 + FieldDataType.GetHashCode();
                if(Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if(DisplayValue != null)
                    hashCode = hashCode * 59 + DisplayValue.GetHashCode();
                if(IsMultiValue != null)
                    hashCode = hashCode * 59 + IsMultiValue.GetHashCode();
                if(IsHidden != null)
                    hashCode = hashCode * 59 + IsHidden.GetHashCode();
                if(IsReadOnly != null)
                    hashCode = hashCode * 59 + IsReadOnly.GetHashCode();
                if(IsMandatory != null)
                    hashCode = hashCode * 59 + IsMandatory.GetHashCode();
                if(IsUnique != null)
                    hashCode = hashCode * 59 + IsUnique.GetHashCode();
                if(IsExcludedFromDefaultView != null)
                    hashCode = hashCode * 59 + IsExcludedFromDefaultView.GetHashCode();
                if(IncludedInFieldSets != null)
                    hashCode = hashCode * 59 + IncludedInFieldSets.GetHashCode();
                if(CategoryId != null)
                    hashCode = hashCode * 59 + CategoryId.GetHashCode();
                if(CategoryName != null)
                    hashCode = hashCode * 59 + CategoryName.GetHashCode();
                if(Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                if(Revision != null)
                    hashCode = hashCode * 59 + Revision.GetHashCode();
                if(CvlId != null)
                    hashCode = hashCode * 59 + CvlId.GetHashCode();
                if(ParentCvlId != null)
                    hashCode = hashCode * 59 + ParentCvlId.GetHashCode();
                if(Settings != null)
                    hashCode = hashCode * 59 + Settings.GetHashCode();
                return hashCode;
            }
        }
    }

}
