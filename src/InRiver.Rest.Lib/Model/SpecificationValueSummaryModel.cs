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
        public SpecificationValueSummaryModel(int? entityId = default(int?), string name = default(string), string categoryId = default(string), Object value = default(Object), Object displayValue = default(Object), string parentCvlId = default(string), string cvlId = default(string), bool? isMultiValue = default(bool?), int? index = default(int?), bool? isFormatted = default(bool?), string specificationFieldTypeId = default(string), string unit = default(string), string specificationDataType = default(string), bool? mandatory = default(bool?), bool? isHidden = default(bool?), bool? isReadOnly = default(bool?))
        {
            this.EntityId = entityId;
            this.Name = name;
            this.CategoryId = categoryId;
            this.Value = value;
            this.DisplayValue = displayValue;
            this.ParentCvlId = parentCvlId;
            this.CvlId = cvlId;
            this.IsMultiValue = isMultiValue;
            this.Index = index;
            this.IsFormatted = isFormatted;
            this.SpecificationFieldTypeId = specificationFieldTypeId;
            this.Unit = unit;
            this.SpecificationDataType = specificationDataType;
            this.Mandatory = mandatory;
            this.IsHidden = isHidden;
            this.IsReadOnly = isReadOnly;
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
        public Object Value { get; set; }

        /// <summary>
        /// Gets or Sets DisplayValue
        /// </summary>
        [DataMember(Name="displayValue", EmitDefaultValue=false)]
        public Object DisplayValue { get; set; }

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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SpecificationValueSummaryModel);
        }

        /// <summary>
        /// Returns true if SpecificationValueSummaryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SpecificationValueSummaryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecificationValueSummaryModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityId == input.EntityId ||
                    (this.EntityId != null &&
                    this.EntityId.Equals(input.EntityId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.CategoryId == input.CategoryId ||
                    (this.CategoryId != null &&
                    this.CategoryId.Equals(input.CategoryId))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.DisplayValue == input.DisplayValue ||
                    (this.DisplayValue != null &&
                    this.DisplayValue.Equals(input.DisplayValue))
                ) && 
                (
                    this.ParentCvlId == input.ParentCvlId ||
                    (this.ParentCvlId != null &&
                    this.ParentCvlId.Equals(input.ParentCvlId))
                ) && 
                (
                    this.CvlId == input.CvlId ||
                    (this.CvlId != null &&
                    this.CvlId.Equals(input.CvlId))
                ) && 
                (
                    this.IsMultiValue == input.IsMultiValue ||
                    (this.IsMultiValue != null &&
                    this.IsMultiValue.Equals(input.IsMultiValue))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.IsFormatted == input.IsFormatted ||
                    (this.IsFormatted != null &&
                    this.IsFormatted.Equals(input.IsFormatted))
                ) && 
                (
                    this.SpecificationFieldTypeId == input.SpecificationFieldTypeId ||
                    (this.SpecificationFieldTypeId != null &&
                    this.SpecificationFieldTypeId.Equals(input.SpecificationFieldTypeId))
                ) && 
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
                ) && 
                (
                    this.SpecificationDataType == input.SpecificationDataType ||
                    (this.SpecificationDataType != null &&
                    this.SpecificationDataType.Equals(input.SpecificationDataType))
                ) && 
                (
                    this.Mandatory == input.Mandatory ||
                    (this.Mandatory != null &&
                    this.Mandatory.Equals(input.Mandatory))
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
                if (this.EntityId != null)
                    hashCode = hashCode * 59 + this.EntityId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.CategoryId != null)
                    hashCode = hashCode * 59 + this.CategoryId.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.DisplayValue != null)
                    hashCode = hashCode * 59 + this.DisplayValue.GetHashCode();
                if (this.ParentCvlId != null)
                    hashCode = hashCode * 59 + this.ParentCvlId.GetHashCode();
                if (this.CvlId != null)
                    hashCode = hashCode * 59 + this.CvlId.GetHashCode();
                if (this.IsMultiValue != null)
                    hashCode = hashCode * 59 + this.IsMultiValue.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.IsFormatted != null)
                    hashCode = hashCode * 59 + this.IsFormatted.GetHashCode();
                if (this.SpecificationFieldTypeId != null)
                    hashCode = hashCode * 59 + this.SpecificationFieldTypeId.GetHashCode();
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
                if (this.SpecificationDataType != null)
                    hashCode = hashCode * 59 + this.SpecificationDataType.GetHashCode();
                if (this.Mandatory != null)
                    hashCode = hashCode * 59 + this.Mandatory.GetHashCode();
                if (this.IsHidden != null)
                    hashCode = hashCode * 59 + this.IsHidden.GetHashCode();
                if (this.IsReadOnly != null)
                    hashCode = hashCode * 59 + this.IsReadOnly.GetHashCode();
                return hashCode;
            }
        }
    }

}
