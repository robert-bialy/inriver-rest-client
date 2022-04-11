using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FetchObjectsModel
    /// </summary>
    [DataContract]
    public class FetchObjectsModel :  IEquatable<FetchObjectsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FetchObjectsModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected FetchObjectsModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FetchObjectsModel" /> class.
        /// </summary>
        /// <param name="entityIds">entityIds (required).</param>
        /// <param name="objects">objects (required).</param>
        /// <param name="fieldTypeIds">fieldTypeIds.</param>
        /// <param name="inbound">inbound.</param>
        /// <param name="outbound">outbound.</param>
        public FetchObjectsModel(List<int?> entityIds = default(List<int?>), string objects = default(string), string fieldTypeIds = default(string), FetchLinkObjectsModel inbound = default(FetchLinkObjectsModel), FetchLinkObjectsModel outbound = default(FetchLinkObjectsModel))
        {
            // to ensure "entityIds" is required (not null)
            if (entityIds == null)
            {
                throw new InvalidDataException("entityIds is a required property for FetchObjectsModel and cannot be null");
            }
            else
            {
                this.EntityIds = entityIds;
            }
            // to ensure "objects" is required (not null)
            if (objects == null)
            {
                throw new InvalidDataException("objects is a required property for FetchObjectsModel and cannot be null");
            }
            else
            {
                this.Objects = objects;
            }
            this.FieldTypeIds = fieldTypeIds;
            this.Inbound = inbound;
            this.Outbound = outbound;
        }
        
        /// <summary>
        /// Gets or Sets EntityIds
        /// </summary>
        [DataMember(Name="entityIds", EmitDefaultValue=false)]
        public List<int?> EntityIds { get; set; }

        /// <summary>
        /// Gets or Sets Objects
        /// </summary>
        [DataMember(Name="objects", EmitDefaultValue=false)]
        public string Objects { get; set; }

        /// <summary>
        /// Gets or Sets FieldTypeIds
        /// </summary>
        [DataMember(Name="fieldTypeIds", EmitDefaultValue=false)]
        public string FieldTypeIds { get; set; }

        /// <summary>
        /// Gets or Sets Inbound
        /// </summary>
        [DataMember(Name="inbound", EmitDefaultValue=false)]
        public FetchLinkObjectsModel Inbound { get; set; }

        /// <summary>
        /// Gets or Sets Outbound
        /// </summary>
        [DataMember(Name="outbound", EmitDefaultValue=false)]
        public FetchLinkObjectsModel Outbound { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FetchObjectsModel {\n");
            sb.Append("  EntityIds: ").Append(EntityIds).Append("\n");
            sb.Append("  Objects: ").Append(Objects).Append("\n");
            sb.Append("  FieldTypeIds: ").Append(FieldTypeIds).Append("\n");
            sb.Append("  Inbound: ").Append(Inbound).Append("\n");
            sb.Append("  Outbound: ").Append(Outbound).Append("\n");
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
            return this.Equals(input as FetchObjectsModel);
        }

        /// <summary>
        /// Returns true if FetchObjectsModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FetchObjectsModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FetchObjectsModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityIds == input.EntityIds ||
                    this.EntityIds != null &&
                    this.EntityIds.SequenceEqual(input.EntityIds)
                ) && 
                (
                    this.Objects == input.Objects ||
                    (this.Objects != null &&
                    this.Objects.Equals(input.Objects))
                ) && 
                (
                    this.FieldTypeIds == input.FieldTypeIds ||
                    (this.FieldTypeIds != null &&
                    this.FieldTypeIds.Equals(input.FieldTypeIds))
                ) && 
                (
                    this.Inbound == input.Inbound ||
                    (this.Inbound != null &&
                    this.Inbound.Equals(input.Inbound))
                ) && 
                (
                    this.Outbound == input.Outbound ||
                    (this.Outbound != null &&
                    this.Outbound.Equals(input.Outbound))
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
                if (this.EntityIds != null)
                    hashCode = hashCode * 59 + this.EntityIds.GetHashCode();
                if (this.Objects != null)
                    hashCode = hashCode * 59 + this.Objects.GetHashCode();
                if (this.FieldTypeIds != null)
                    hashCode = hashCode * 59 + this.FieldTypeIds.GetHashCode();
                if (this.Inbound != null)
                    hashCode = hashCode * 59 + this.Inbound.GetHashCode();
                if (this.Outbound != null)
                    hashCode = hashCode * 59 + this.Outbound.GetHashCode();
                return hashCode;
            }
        }
    }

}
