using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// CVLValueModel
    /// </summary>
    [DataContract]
    public class CVLValueModel :  IEquatable<CVLValueModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CVLValueModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected CVLValueModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CVLValueModel" /> class.
        /// </summary>
        /// <param name="key">key (required).</param>
        /// <param name="value">value.</param>
        /// <param name="index">index.</param>
        /// <param name="parentKey">parentKey.</param>
        public CVLValueModel(string key = default(string), Object value = default(Object), int? index = default(int?), string parentKey = default(string))
        {
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new InvalidDataException("key is a required property for CVLValueModel and cannot be null");
            }
            else
            {
                this.Key = key;
            }
            this.Value = value;
            this.Index = index;
            this.ParentKey = parentKey;
        }
        
        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name="key", EmitDefaultValue=false)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public Object Value { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets ParentKey
        /// </summary>
        [DataMember(Name="parentKey", EmitDefaultValue=false)]
        public string ParentKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CVLValueModel {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  ParentKey: ").Append(ParentKey).Append("\n");
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
            return this.Equals(input as CVLValueModel);
        }

        /// <summary>
        /// Returns true if CVLValueModel instances are equal
        /// </summary>
        /// <param name="input">Instance of CVLValueModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CVLValueModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.ParentKey == input.ParentKey ||
                    (this.ParentKey != null &&
                    this.ParentKey.Equals(input.ParentKey))
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
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.ParentKey != null)
                    hashCode = hashCode * 59 + this.ParentKey.GetHashCode();
                return hashCode;
            }
        }
    }

}
