using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SyndicationModel
    /// </summary>
    [DataContract]
    public class SyndicationModel :  IEquatable<SyndicationModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyndicationModel" /> class.
        /// </summary>
        /// <param name="extensionDisplayName">extensionDisplayName.</param>
        /// <param name="extensionId">extensionId.</param>
        /// <param name="id">id.</param>
        /// <param name="mappingName">mappingName.</param>
        /// <param name="name">name.</param>
        /// <param name="outputFormat">outputFormat.</param>
        /// <param name="workareaName">workareaName.</param>
        /// <param name="workareaId">workareaId.</param>
        public SyndicationModel(string extensionDisplayName = default, string extensionId = default, int? id = default(int?), string mappingName = default, string name = default, string outputFormat = default, string workareaName = default, string workareaId = default)
        {
            ExtensionDisplayName = extensionDisplayName;
            ExtensionId = extensionId;
            Id = id;
            MappingName = mappingName;
            Name = name;
            OutputFormat = outputFormat;
            WorkareaName = workareaName;
            WorkareaId = workareaId;
        }
        
        /// <summary>
        /// Gets or Sets ExtensionDisplayName
        /// </summary>
        [DataMember(Name="extensionDisplayName", EmitDefaultValue=false)]
        public string ExtensionDisplayName { get; set; }

        /// <summary>
        /// Gets or Sets ExtensionId
        /// </summary>
        [DataMember(Name="extensionId", EmitDefaultValue=false)]
        public string ExtensionId { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets MappingName
        /// </summary>
        [DataMember(Name="mappingName", EmitDefaultValue=false)]
        public string MappingName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets OutputFormat
        /// </summary>
        [DataMember(Name="outputFormat", EmitDefaultValue=false)]
        public string OutputFormat { get; set; }

        /// <summary>
        /// Gets or Sets WorkareaName
        /// </summary>
        [DataMember(Name="workareaName", EmitDefaultValue=false)]
        public string WorkareaName { get; set; }

        /// <summary>
        /// Gets or Sets WorkareaId
        /// </summary>
        [DataMember(Name="workareaId", EmitDefaultValue=false)]
        public string WorkareaId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SyndicationModel {\n");
            sb.Append("  ExtensionDisplayName: ").Append(ExtensionDisplayName).Append("\n");
            sb.Append("  ExtensionId: ").Append(ExtensionId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MappingName: ").Append(MappingName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OutputFormat: ").Append(OutputFormat).Append("\n");
            sb.Append("  WorkareaName: ").Append(WorkareaName).Append("\n");
            sb.Append("  WorkareaId: ").Append(WorkareaId).Append("\n");
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
            return Equals(input as SyndicationModel);
        }

        /// <summary>
        /// Returns true if SyndicationModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SyndicationModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SyndicationModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    ExtensionDisplayName == input.ExtensionDisplayName ||
                   (ExtensionDisplayName != null &&
                    ExtensionDisplayName.Equals(input.ExtensionDisplayName))
                ) && 
               (
                    ExtensionId == input.ExtensionId ||
                   (ExtensionId != null &&
                    ExtensionId.Equals(input.ExtensionId))
                ) && 
               (
                    Id == input.Id ||
                   (Id != null &&
                    Id.Equals(input.Id))
                ) && 
               (
                    MappingName == input.MappingName ||
                   (MappingName != null &&
                    MappingName.Equals(input.MappingName))
                ) && 
               (
                    Name == input.Name ||
                   (Name != null &&
                    Name.Equals(input.Name))
                ) && 
               (
                    OutputFormat == input.OutputFormat ||
                   (OutputFormat != null &&
                    OutputFormat.Equals(input.OutputFormat))
                ) && 
               (
                    WorkareaName == input.WorkareaName ||
                   (WorkareaName != null &&
                    WorkareaName.Equals(input.WorkareaName))
                ) && 
               (
                    WorkareaId == input.WorkareaId ||
                   (WorkareaId != null &&
                    WorkareaId.Equals(input.WorkareaId))
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
                if(ExtensionDisplayName != null)
                    hashCode = hashCode * 59 + ExtensionDisplayName.GetHashCode();
                if(ExtensionId != null)
                    hashCode = hashCode * 59 + ExtensionId.GetHashCode();
                if(Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if(MappingName != null)
                    hashCode = hashCode * 59 + MappingName.GetHashCode();
                if(Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if(OutputFormat != null)
                    hashCode = hashCode * 59 + OutputFormat.GetHashCode();
                if(WorkareaName != null)
                    hashCode = hashCode * 59 + WorkareaName.GetHashCode();
                if(WorkareaId != null)
                    hashCode = hashCode * 59 + WorkareaId.GetHashCode();
                return hashCode;
            }
        }
    }

}
