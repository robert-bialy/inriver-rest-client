using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FetchLinkObjectsModel
    /// </summary>
    [DataContract]
    public class FetchLinkObjectsModel :  IEquatable<FetchLinkObjectsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FetchLinkObjectsModel" /> class.
        /// </summary>
        /// <param name="linkTypeIds">linkTypeIds.</param>
        /// <param name="objects">objects.</param>
        /// <param name="linkEntityObjects">linkEntityObjects.</param>
        public FetchLinkObjectsModel(string linkTypeIds = default(string), string objects = default(string), string linkEntityObjects = default(string))
        {
            this.LinkTypeIds = linkTypeIds;
            this.Objects = objects;
            this.LinkEntityObjects = linkEntityObjects;
        }
        
        /// <summary>
        /// Gets or Sets LinkTypeIds
        /// </summary>
        [DataMember(Name="linkTypeIds", EmitDefaultValue=false)]
        public string LinkTypeIds { get; set; }

        /// <summary>
        /// Gets or Sets Objects
        /// </summary>
        [DataMember(Name="objects", EmitDefaultValue=false)]
        public string Objects { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntityObjects
        /// </summary>
        [DataMember(Name="linkEntityObjects", EmitDefaultValue=false)]
        public string LinkEntityObjects { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FetchLinkObjectsModel {\n");
            sb.Append("  LinkTypeIds: ").Append(LinkTypeIds).Append("\n");
            sb.Append("  Objects: ").Append(Objects).Append("\n");
            sb.Append("  LinkEntityObjects: ").Append(LinkEntityObjects).Append("\n");
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
            return this.Equals(input as FetchLinkObjectsModel);
        }

        /// <summary>
        /// Returns true if FetchLinkObjectsModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FetchLinkObjectsModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FetchLinkObjectsModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LinkTypeIds == input.LinkTypeIds ||
                    (this.LinkTypeIds != null &&
                    this.LinkTypeIds.Equals(input.LinkTypeIds))
                ) && 
                (
                    this.Objects == input.Objects ||
                    (this.Objects != null &&
                    this.Objects.Equals(input.Objects))
                ) && 
                (
                    this.LinkEntityObjects == input.LinkEntityObjects ||
                    (this.LinkEntityObjects != null &&
                    this.LinkEntityObjects.Equals(input.LinkEntityObjects))
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
                if (this.LinkTypeIds != null)
                    hashCode = hashCode * 59 + this.LinkTypeIds.GetHashCode();
                if (this.Objects != null)
                    hashCode = hashCode * 59 + this.Objects.GetHashCode();
                if (this.LinkEntityObjects != null)
                    hashCode = hashCode * 59 + this.LinkEntityObjects.GetHashCode();
                return hashCode;
            }
        }
    }

}
