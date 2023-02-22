using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FetchLinkobjectsModel
    /// </summary>
    [DataContract]
    public class FetchLinkObjectsModel :  IEquatable<FetchLinkObjectsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FetchLinkObjectsModel" /> class.
        /// </summary>
        /// <param name="linkTypeIds">linkTypeIds.</param>
        /// <param name="objects">objects.</param>
        /// <param name="linkEntityobjects">linkEntityobjects.</param>
        public FetchLinkObjectsModel(string linkTypeIds = default, string objects = default, string linkEntityobjects = default)
        {
            LinkTypeIds = linkTypeIds;
            Objects = objects;
            LinkEntityobjects = linkEntityobjects;
        }
        
        /// <summary>
        /// Gets or Sets LinkTypeIds
        /// </summary>
        [DataMember(Name="linkTypeIds", EmitDefaultValue=false)]
        public string LinkTypeIds { get; set; }

        /// <summary>
        /// Gets or Sets objects
        /// </summary>
        [DataMember(Name="objects", EmitDefaultValue=false)]
        public string Objects { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntityobjects
        /// </summary>
        [DataMember(Name="linkEntityobjects", EmitDefaultValue=false)]
        public string LinkEntityobjects { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FetchLinkobjectsModel {\n");
            sb.Append("  LinkTypeIds: ").Append(LinkTypeIds).Append("\n");
            sb.Append("  objects: ").Append(Objects).Append("\n");
            sb.Append("  LinkEntityobjects: ").Append(LinkEntityobjects).Append("\n");
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
            return Equals(input as FetchLinkObjectsModel);
        }

        /// <summary>
        /// Returns true if FetchLinkobjectsModel instances are equal
        /// </summary>
        /// <param name="input">Instance of FetchLinkobjectsModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FetchLinkObjectsModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    LinkTypeIds == input.LinkTypeIds ||
                    (LinkTypeIds != null &&
                    LinkTypeIds.Equals(input.LinkTypeIds))
                ) && 
                (
                    Objects == input.Objects ||
                    (Objects != null &&
                     Objects.Equals(input.Objects))
                ) && 
                (
                    LinkEntityobjects == input.LinkEntityobjects ||
                    (LinkEntityobjects != null &&
                    LinkEntityobjects.Equals(input.LinkEntityobjects))
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
                if (LinkTypeIds != null)
                    hashCode = hashCode * 59 + LinkTypeIds.GetHashCode();
                if (Objects != null)
                    hashCode = hashCode * 59 + Objects.GetHashCode();
                if (LinkEntityobjects != null)
                    hashCode = hashCode * 59 + LinkEntityobjects.GetHashCode();
                return hashCode;
            }
        }
    }

}
