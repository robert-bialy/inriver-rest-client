using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SpecificationFieldTypeModel
    /// </summary>
    [DataContract]
    public class SpecificationFieldTypeModel :  IEquatable<SpecificationFieldTypeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationFieldTypeModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="dataType">dataType.</param>
        /// <param name="categoryId">categoryId.</param>
        /// <param name="defaultValue">defaultValue.</param>
        /// <param name="format">format.</param>
        /// <param name="unit">unit.</param>
        /// <param name="isDisabled">isDisabled.</param>
        /// <param name="isMultiValue">isMultiValue.</param>
        /// <param name="isMandatory">isMandatory.</param>
        /// <param name="index">index.</param>
        /// <param name="cvlId">cvlId.</param>
        public SpecificationFieldTypeModel(string id = default, Dictionary<string, string> name = default(Dictionary<string, string>), string dataType = default, string categoryId = default, string defaultValue = default, string format = default, string unit = default, bool? isDisabled = default(bool?), bool? isMultiValue = default(bool?), bool? isMandatory = default(bool?), int? index = default(int?), string cvlId = default)
        {
            Id = id;
            Name = name;
            DataType = dataType;
            CategoryId = categoryId;
            DefaultValue = defaultValue;
            Format = format;
            Unit = unit;
            IsDisabled = isDisabled;
            IsMultiValue = isMultiValue;
            IsMandatory = isMandatory;
            Index = index;
            CvlId = cvlId;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public Dictionary<string, string> Name { get; set; }

        /// <summary>
        /// Gets or Sets DataType
        /// </summary>
        [DataMember(Name="dataType", EmitDefaultValue=false)]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [DataMember(Name="categoryId", EmitDefaultValue=false)]
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets DefaultValue
        /// </summary>
        [DataMember(Name="defaultValue", EmitDefaultValue=false)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name="format", EmitDefaultValue=false)]
        public string Format { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name="unit", EmitDefaultValue=false)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets IsDisabled
        /// </summary>
        [DataMember(Name="isDisabled", EmitDefaultValue=false)]
        public bool? IsDisabled { get; set; }

        /// <summary>
        /// Gets or Sets IsMultiValue
        /// </summary>
        [DataMember(Name="isMultiValue", EmitDefaultValue=false)]
        public bool? IsMultiValue { get; set; }

        /// <summary>
        /// Gets or Sets IsMandatory
        /// </summary>
        [DataMember(Name="isMandatory", EmitDefaultValue=false)]
        public bool? IsMandatory { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SpecificationFieldTypeModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DataType: ").Append(DataType).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  DefaultValue: ").Append(DefaultValue).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  IsDisabled: ").Append(IsDisabled).Append("\n");
            sb.Append("  IsMultiValue: ").Append(IsMultiValue).Append("\n");
            sb.Append("  IsMandatory: ").Append(IsMandatory).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  CvlId: ").Append(CvlId).Append("\n");
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
            return Equals(input as SpecificationFieldTypeModel);
        }

        /// <summary>
        /// Returns true if SpecificationFieldTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SpecificationFieldTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecificationFieldTypeModel input)
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
                    Name == input.Name ||
                    Name != null &&
                    Name.SequenceEqual(input.Name)
                ) && 
               (
                    DataType == input.DataType ||
                   (DataType != null &&
                    DataType.Equals(input.DataType))
                ) && 
               (
                    CategoryId == input.CategoryId ||
                   (CategoryId != null &&
                    CategoryId.Equals(input.CategoryId))
                ) && 
               (
                    DefaultValue == input.DefaultValue ||
                   (DefaultValue != null &&
                    DefaultValue.Equals(input.DefaultValue))
                ) && 
               (
                    Format == input.Format ||
                   (Format != null &&
                    Format.Equals(input.Format))
                ) && 
               (
                    Unit == input.Unit ||
                   (Unit != null &&
                    Unit.Equals(input.Unit))
                ) && 
               (
                    IsDisabled == input.IsDisabled ||
                   (IsDisabled != null &&
                    IsDisabled.Equals(input.IsDisabled))
                ) && 
               (
                    IsMultiValue == input.IsMultiValue ||
                   (IsMultiValue != null &&
                    IsMultiValue.Equals(input.IsMultiValue))
                ) && 
               (
                    IsMandatory == input.IsMandatory ||
                   (IsMandatory != null &&
                    IsMandatory.Equals(input.IsMandatory))
                ) && 
               (
                    Index == input.Index ||
                   (Index != null &&
                    Index.Equals(input.Index))
                ) && 
               (
                    CvlId == input.CvlId ||
                   (CvlId != null &&
                    CvlId.Equals(input.CvlId))
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
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(DataType != null)
                    hashCode = hashCode * 59 + DataType.GetHashCode();
                if(CategoryId != null)
                    hashCode = hashCode * 59 + CategoryId.GetHashCode();
                if(DefaultValue != null)
                    hashCode = hashCode * 59 + DefaultValue.GetHashCode();
                if(Format != null)
                    hashCode = hashCode * 59 + Format.GetHashCode();
                if(Unit != null)
                    hashCode = hashCode * 59 + Unit.GetHashCode();
                if(IsDisabled != null)
                    hashCode = hashCode * 59 + IsDisabled.GetHashCode();
                if(IsMultiValue != null)
                    hashCode = hashCode * 59 + IsMultiValue.GetHashCode();
                if(IsMandatory != null)
                    hashCode = hashCode * 59 + IsMandatory.GetHashCode();
                if(Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                if(CvlId != null)
                    hashCode = hashCode * 59 + CvlId.GetHashCode();
                return hashCode;
            }
        }
    }

}
