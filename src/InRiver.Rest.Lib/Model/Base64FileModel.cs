using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// Base64FileModel
    /// </summary>
    [DataContract]
    public class Base64FileModel :  IEquatable<Base64FileModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Base64FileModel" /> class.
        /// </summary>
        /// <param name="fileName">fileName.</param>
        /// <param name="data">data.</param>
        public Base64FileModel(string fileName = default, string data = default)
        {
            FileName = fileName;
            Data = data;
        }
        
        /// <summary>
        /// Gets or Sets FileName
        /// </summary>
        [DataMember(Name="fileName", EmitDefaultValue=false)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Base64FileModel {\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return Equals(input as Base64FileModel);
        }

        /// <summary>
        /// Returns true if Base64FileModel instances are equal
        /// </summary>
        /// <param name="input">Instance of Base64FileModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Base64FileModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    FileName == input.FileName ||
                    (FileName != null &&
                    FileName.Equals(input.FileName))
                ) && 
                (
                    Data == input.Data ||
                    (Data != null &&
                    Data.Equals(input.Data))
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
                if (FileName != null)
                    hashCode = hashCode * 59 + FileName.GetHashCode();
                if (Data != null)
                    hashCode = hashCode * 59 + Data.GetHashCode();
                return hashCode;
            }
        }
    }
}
