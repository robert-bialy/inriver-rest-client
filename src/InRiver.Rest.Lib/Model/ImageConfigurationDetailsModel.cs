using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// ImageConfigurationDetailsModel
    /// </summary>
    [DataContract]
    public class ImageConfigurationDetailsModel :  IEquatable<ImageConfigurationDetailsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageConfigurationDetailsModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="extension">extension.</param>
        /// <param name="outputExtension">outputExtension.</param>
        /// <param name="arguments">arguments.</param>
        public ImageConfigurationDetailsModel(int? id = default(int?), string name = default(string), string extension = default(string), string outputExtension = default(string), string arguments = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.Extension = extension;
            this.OutputExtension = outputExtension;
            this.Arguments = arguments;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Extension
        /// </summary>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or Sets OutputExtension
        /// </summary>
        [DataMember(Name="outputExtension", EmitDefaultValue=false)]
        public string OutputExtension { get; set; }

        /// <summary>
        /// Gets or Sets Arguments
        /// </summary>
        [DataMember(Name="arguments", EmitDefaultValue=false)]
        public string Arguments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ImageConfigurationDetailsModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Extension: ").Append(Extension).Append("\n");
            sb.Append("  OutputExtension: ").Append(OutputExtension).Append("\n");
            sb.Append("  Arguments: ").Append(Arguments).Append("\n");
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
            return this.Equals(input as ImageConfigurationDetailsModel);
        }

        /// <summary>
        /// Returns true if ImageConfigurationDetailsModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ImageConfigurationDetailsModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ImageConfigurationDetailsModel input)
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
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Extension == input.Extension ||
                    (this.Extension != null &&
                    this.Extension.Equals(input.Extension))
                ) && 
                (
                    this.OutputExtension == input.OutputExtension ||
                    (this.OutputExtension != null &&
                    this.OutputExtension.Equals(input.OutputExtension))
                ) && 
                (
                    this.Arguments == input.Arguments ||
                    (this.Arguments != null &&
                    this.Arguments.Equals(input.Arguments))
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
                if (this.Extension != null)
                    hashCode = hashCode * 59 + this.Extension.GetHashCode();
                if (this.OutputExtension != null)
                    hashCode = hashCode * 59 + this.OutputExtension.GetHashCode();
                if (this.Arguments != null)
                    hashCode = hashCode * 59 + this.Arguments.GetHashCode();
                return hashCode;
            }
        }
    }

}
