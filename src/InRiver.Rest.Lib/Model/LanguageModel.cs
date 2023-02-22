using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// LanguageModel
    /// </summary>
    [DataContract]
    public class LanguageModel :  IEquatable<LanguageModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageModel" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="displayName">displayName.</param>
        public LanguageModel(string name = default, string displayName = default)
        {
            Name = name;
            DisplayName = displayName;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LanguageModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
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
            return Equals(input as LanguageModel);
        }

        /// <summary>
        /// Returns true if LanguageModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LanguageModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LanguageModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    Name == input.Name ||
                   (Name != null &&
                    Name.Equals(input.Name))
                ) && 
               (
                    DisplayName == input.DisplayName ||
                   (DisplayName != null &&
                    DisplayName.Equals(input.DisplayName))
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
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(DisplayName != null)
                    hashCode = hashCode * 59 + DisplayName.GetHashCode();
                return hashCode;
            }
        }
    }

}
