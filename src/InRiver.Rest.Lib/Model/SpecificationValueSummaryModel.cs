using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SpecificationValueSummaryModel
    /// </summary>
    [DataContract]
    public class SpecificationValueSummaryModel :  IEquatable<SpecificationValueSummaryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationValueSummaryModel" /> class.
        /// </summary>
        /// <param name="entityId">entityId.</param>
        /// <param name="name">name.</param>
        /// <param name="categoryId">categoryId.</param>
        /// <param name="value">value.</param>
        /// <param name="displayValue">displayValue.</param>
        /// <param name="parentCvlId">parentCvlId.</param>
        /// <param name="cvlId">cvlId.</param>
        /// <param name="isMultiValue">isMultiValue.</param>
        /// <param name="index">index.</param>
        /// <param name="isFormatted">isFormatted.</param>
        /// <param name="specificationFieldTypeId">specificationFieldTypeId.</param>
        /// <param name="unit">unit.</param>
        /// <param name="specificationDataType">specificationDataType.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="isHidden">isHidden.</param>
        /// <param name="isReadOnly">isReadOnly.</param>
        public SpecificationValueSummaryModel(int? entityId = default(int?), string name = default, string categoryId = default, object value = default(object), object displayValue = default(object), string parentCvlId = default, string cvlId = default, bool? isMultiValue = default(bool?), int? index = default(int?), bool? isFormatted = default(bool?), string specificationFieldTypeId = default, string unit = default, string specificationDataType = default, bool? mandatory = default(bool?), bool? isHidden = default(bool?), bool? isReadOnly = default(bool?))
        {
            EntityId = entityId;
            Name = name;
            CategoryId = categoryId;
            Value = value;
            DisplayValue = displayValue;
            ParentCvlId = parentCvlId;
            CvlId = cvlId;
            IsMultiValue = isMultiValue;
            Index = index;
            IsFormatted = isFormatted;
            SpecificationFieldTypeId = specificationFieldTypeId;
            Unit = unit;
            SpecificationDataType = specificationDataType;
            Mandatory = mandatory;
            IsHidden = isHidden;
            IsReadOnly = isReadOnly;
        }
        
        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entityId", EmitDefaultValue=false)]
        public int? EntityId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [DataMember(Name="categoryId", EmitDefaultValue=false)]
        public string CategoryId { get; set; }

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
        /// Gets or Sets ParentCvlId
        /// </summary>
        [DataMember(Name="parentCvlId", EmitDefaultValue=false)]
        public string ParentCvlId { get; set; }

        /// <summary>
        /// Gets or Sets CvlId
        /// </summary>
        [DataMember(Name="cvlId", EmitDefaultValue=false)]
        public string CvlId { get; set; }

        /// <summary>
        /// Gets or Sets IsMultiValue
        /// </summary>
        [DataMember(Name="isMultiValue", EmitDefaultValue=false)]
        public bool? IsMultiValue { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets IsFormatted
        /// </summary>
        [DataMember(Name="isFormatted", EmitDefaultValue=false)]
        public bool? IsFormatted { get; set; }

        /// <summary>
        /// Gets or Sets SpecificationFieldTypeId
        /// </summary>
        [DataMember(Name="specificationFieldTypeId", EmitDefaultValue=false)]
        public string SpecificationFieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name="unit", EmitDefaultValue=false)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets SpecificationDataType
        /// </summary>
        [DataMember(Name="specificationDataType", EmitDefaultValue=false)]
        public string SpecificationDataType { get; set; }

        /// <summary>
        /// Gets or Sets Mandatory
        /// </summary>
        [DataMember(Name="mandatory", EmitDefaultValue=false)]
        public bool? Mandatory { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SpecificationValueSummaryModel {\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  DisplayValue: ").Append(DisplayValue).Append("\n");
            sb.Append("  ParentCvlId: ").Append(ParentCvlId).Append("\n");
            sb.Append("  CvlId: ").Append(CvlId).Append("\n");
            sb.Append("  IsMultiValue: ").Append(IsMultiValue).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  IsFormatted: ").Append(IsFormatted).Append("\n");
            sb.Append("  SpecificationFieldTypeId: ").Append(SpecificationFieldTypeId).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  SpecificationDataType: ").Append(SpecificationDataType).Append("\n");
            sb.Append("  Mandatory: ").Append(Mandatory).Append("\n");
            sb.Append("  IsHidden: ").Append(IsHidden).Append("\n");
            sb.Append("  IsReadOnly: ").Append(IsReadOnly).Append("\n");
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
            return Equals(input as SpecificationValueSummaryModel);
        }

        /// <summary>
        /// Returns true if SpecificationValueSummaryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SpecificationValueSummaryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecificationValueSummaryModel input)
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
                    Name == input.Name ||
                   (Name != null &&
                    Name.Equals(input.Name))
                ) && 
               (
                    CategoryId == input.CategoryId ||
                   (CategoryId != null &&
                    CategoryId.Equals(input.CategoryId))
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
                    ParentCvlId == input.ParentCvlId ||
                   (ParentCvlId != null &&
                    ParentCvlId.Equals(input.ParentCvlId))
                ) && 
               (
                    CvlId == input.CvlId ||
                   (CvlId != null &&
                    CvlId.Equals(input.CvlId))
                ) && 
               (
                    IsMultiValue == input.IsMultiValue ||
                   (IsMultiValue != null &&
                    IsMultiValue.Equals(input.IsMultiValue))
                ) && 
               (
                    Index == input.Index ||
                   (Index != null &&
                    Index.Equals(input.Index))
                ) && 
               (
                    IsFormatted == input.IsFormatted ||
                   (IsFormatted != null &&
                    IsFormatted.Equals(input.IsFormatted))
                ) && 
               (
                    SpecificationFieldTypeId == input.SpecificationFieldTypeId ||
                   (SpecificationFieldTypeId != null &&
                    SpecificationFieldTypeId.Equals(input.SpecificationFieldTypeId))
                ) && 
               (
                    Unit == input.Unit ||
                   (Unit != null &&
                    Unit.Equals(input.Unit))
                ) && 
               (
                    SpecificationDataType == input.SpecificationDataType ||
                   (SpecificationDataType != null &&
                    SpecificationDataType.Equals(input.SpecificationDataType))
                ) && 
               (
                    Mandatory == input.Mandatory ||
                   (Mandatory != null &&
                    Mandatory.Equals(input.Mandatory))
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
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(CategoryId != null)
                    hashCode = hashCode * 59 + CategoryId.GetHashCode();
                if(Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if(DisplayValue != null)
                    hashCode = hashCode * 59 + DisplayValue.GetHashCode();
                if(ParentCvlId != null)
                    hashCode = hashCode * 59 + ParentCvlId.GetHashCode();
                if(CvlId != null)
                    hashCode = hashCode * 59 + CvlId.GetHashCode();
                if(IsMultiValue != null)
                    hashCode = hashCode * 59 + IsMultiValue.GetHashCode();
                if(Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                if(IsFormatted != null)
                    hashCode = hashCode * 59 + IsFormatted.GetHashCode();
                if(SpecificationFieldTypeId != null)
                    hashCode = hashCode * 59 + SpecificationFieldTypeId.GetHashCode();
                if(Unit != null)
                    hashCode = hashCode * 59 + Unit.GetHashCode();
                if(SpecificationDataType != null)
                    hashCode = hashCode * 59 + SpecificationDataType.GetHashCode();
                if(Mandatory != null)
                    hashCode = hashCode * 59 + Mandatory.GetHashCode();
                if(IsHidden != null)
                    hashCode = hashCode * 59 + IsHidden.GetHashCode();
                if(IsReadOnly != null)
                    hashCode = hashCode * 59 + IsReadOnly.GetHashCode();
                return hashCode;
            }
        }
    }

}
