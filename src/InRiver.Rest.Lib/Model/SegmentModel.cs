using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SegmentModel
    /// </summary>
    [DataContract]
    public class SegmentModel :  IEquatable<SegmentModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="roles">roles.</param>
        public SegmentModel(int? id = default(int?), string name = default, string description = default, List<RoleModel> roles = default(List<RoleModel>))
        {
            Id = id;
            Name = name;
            Description = description;
            Roles = roles;
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
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Roles
        /// </summary>
        [DataMember(Name="roles", EmitDefaultValue=false)]
        public List<RoleModel> Roles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SegmentModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
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
            return Equals(input as SegmentModel);
        }

        /// <summary>
        /// Returns true if SegmentModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SegmentModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SegmentModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) && 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
                ) && 
                (
                    Roles == input.Roles ||
                    Roles != null &&
                    Roles.SequenceEqual(input.Roles)
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Roles != null)
                    hashCode = hashCode * 59 + Roles.GetHashCode();
                return hashCode;
            }
        }
    }

}
