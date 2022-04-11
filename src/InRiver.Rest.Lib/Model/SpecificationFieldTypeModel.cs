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
        public SpecificationFieldTypeModel(string id = default(string), Dictionary<string, string> name = default(Dictionary<string, string>), string dataType = default(string), string categoryId = default(string), string defaultValue = default(string), string format = default(string), string unit = default(string), bool? isDisabled = default(bool?), bool? isMultiValue = default(bool?), bool? isMandatory = default(bool?), int? index = default(int?), string cvlId = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.DataType = dataType;
            this.CategoryId = categoryId;
            this.DefaultValue = defaultValue;
            this.Format = format;
            this.Unit = unit;
            this.IsDisabled = isDisabled;
            this.IsMultiValue = isMultiValue;
            this.IsMandatory = isMandatory;
            this.Index = index;
            this.CvlId = cvlId;
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SpecificationFieldTypeModel);
        }

        /// <summary>
        /// Returns true if SpecificationFieldTypeModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SpecificationFieldTypeModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecificationFieldTypeModel input)
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
                    this.Name == input.Name ||
                    this.Name != null &&
                    this.Name.SequenceEqual(input.Name)
                ) && 
                (
                    this.DataType == input.DataType ||
                    (this.DataType != null &&
                    this.DataType.Equals(input.DataType))
                ) && 
                (
                    this.CategoryId == input.CategoryId ||
                    (this.CategoryId != null &&
                    this.CategoryId.Equals(input.CategoryId))
                ) && 
                (
                    this.DefaultValue == input.DefaultValue ||
                    (this.DefaultValue != null &&
                    this.DefaultValue.Equals(input.DefaultValue))
                ) && 
                (
                    this.Format == input.Format ||
                    (this.Format != null &&
                    this.Format.Equals(input.Format))
                ) && 
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
                ) && 
                (
                    this.IsDisabled == input.IsDisabled ||
                    (this.IsDisabled != null &&
                    this.IsDisabled.Equals(input.IsDisabled))
                ) && 
                (
                    this.IsMultiValue == input.IsMultiValue ||
                    (this.IsMultiValue != null &&
                    this.IsMultiValue.Equals(input.IsMultiValue))
                ) && 
                (
                    this.IsMandatory == input.IsMandatory ||
                    (this.IsMandatory != null &&
                    this.IsMandatory.Equals(input.IsMandatory))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.DataType != null)
                    hashCode = hashCode * 59 + this.DataType.GetHashCode();
                if (this.CategoryId != null)
                    hashCode = hashCode * 59 + this.CategoryId.GetHashCode();
                if (this.DefaultValue != null)
                    hashCode = hashCode * 59 + this.DefaultValue.GetHashCode();
                if (this.Format != null)
                    hashCode = hashCode * 59 + this.Format.GetHashCode();
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
                if (this.IsDisabled != null)
                    hashCode = hashCode * 59 + this.IsDisabled.GetHashCode();
                if (this.IsMultiValue != null)
                    hashCode = hashCode * 59 + this.IsMultiValue.GetHashCode();
                if (this.IsMandatory != null)
                    hashCode = hashCode * 59 + this.IsMandatory.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.CvlId != null)
                    hashCode = hashCode * 59 + this.CvlId.GetHashCode();
                return hashCode;
            }
        }
    }

}
