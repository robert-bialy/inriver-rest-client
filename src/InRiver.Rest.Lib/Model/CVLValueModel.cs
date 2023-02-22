using System;
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
        public CVLValueModel(string key = default, object value = default(object), int? index = default(int?), string parentKey = default)
        {
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new InvalidDataException("key is a required property for CVLValueModel and cannot be null");
            }
            else
            {
                Key = key;
            }
            Value = value;
            Index = index;
            ParentKey = parentKey;
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
        public object Value { get; set; }

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
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as CVLValueModel);
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
                    Key == input.Key ||
                    (Key != null &&
                    Key.Equals(input.Key))
                ) && 
                (
                    Value == input.Value ||
                    (Value != null &&
                    Value.Equals(input.Value))
                ) && 
                (
                    Index == input.Index ||
                    (Index != null &&
                    Index.Equals(input.Index))
                ) && 
                (
                    ParentKey == input.ParentKey ||
                    (ParentKey != null &&
                    ParentKey.Equals(input.ParentKey))
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
                if (Key != null)
                    hashCode = hashCode * 59 + Key.GetHashCode();
                if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                if (Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                if (ParentKey != null)
                    hashCode = hashCode * 59 + ParentKey.GetHashCode();
                return hashCode;
            }
        }
    }

}
