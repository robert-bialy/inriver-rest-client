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
    /// UserRolesModel
    /// </summary>
    [DataContract]
    public class UserRolesModel :  IEquatable<UserRolesModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRolesModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected UserRolesModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRolesModel" /> class.
        /// </summary>
        /// <param name="username">username(required).</param>
        /// <param name="roleNames">roleNames.</param>
        public UserRolesModel(string username = default, List<string> roleNames = default(List<string>))
        {
            // to ensure "username" is required(not null)
            if(username == null)
            {
                throw new InvalidDataException("username is a required property for UserRolesModel and cannot be null");
            }
            else
            {
                Username = username;
            }
            RoleNames = roleNames;
        }
        
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets RoleNames
        /// </summary>
        [DataMember(Name="roleNames", EmitDefaultValue=false)]
        public List<string> RoleNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserRolesModel {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  RoleNames: ").Append(RoleNames).Append("\n");
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
            return Equals(input as UserRolesModel);
        }

        /// <summary>
        /// Returns true if UserRolesModel instances are equal
        /// </summary>
        /// <param name="input">Instance of UserRolesModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserRolesModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    Username == input.Username ||
                   (Username != null &&
                    Username.Equals(input.Username))
                ) && 
               (
                    RoleNames == input.RoleNames ||
                    RoleNames != null &&
                    RoleNames.SequenceEqual(input.RoleNames)
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
                if(Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                if(RoleNames != null)
                    hashCode = hashCode * 59 + RoleNames.GetHashCode();
                return hashCode;
            }
        }
    }
}
