using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// UserRoleModel
    /// </summary>
    [DataContract]
    public class UserRoleModel :  IEquatable<UserRoleModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected UserRoleModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleModel" /> class.
        /// </summary>
        /// <param name="username">username (required).</param>
        /// <param name="roleName">roleName (required).</param>
        public UserRoleModel(string username = default(string), string roleName = default(string))
        {
            // to ensure "username" is required (not null)
            if (username == null)
            {
                throw new InvalidDataException("username is a required property for UserRoleModel and cannot be null");
            }
            else
            {
                this.Username = username;
            }
            // to ensure "roleName" is required (not null)
            if (roleName == null)
            {
                throw new InvalidDataException("roleName is a required property for UserRoleModel and cannot be null");
            }
            else
            {
                this.RoleName = roleName;
            }
        }
        
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets RoleName
        /// </summary>
        [DataMember(Name="roleName", EmitDefaultValue=false)]
        public string RoleName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserRoleModel {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  RoleName: ").Append(RoleName).Append("\n");
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
            return this.Equals(input as UserRoleModel);
        }

        /// <summary>
        /// Returns true if UserRoleModel instances are equal
        /// </summary>
        /// <param name="input">Instance of UserRoleModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserRoleModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
                ) && 
                (
                    this.RoleName == input.RoleName ||
                    (this.RoleName != null &&
                    this.RoleName.Equals(input.RoleName))
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
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                if (this.RoleName != null)
                    hashCode = hashCode * 59 + this.RoleName.GetHashCode();
                return hashCode;
            }
        }
    }

}
