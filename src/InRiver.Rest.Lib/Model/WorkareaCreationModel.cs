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
    /// WorkareaCreationModel
    /// </summary>
    [DataContract]
    public class WorkareaCreationModel :  IEquatable<WorkareaCreationModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaCreationModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected WorkareaCreationModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaCreationModel" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="isShared">isShared (required).</param>
        /// <param name="query">query.</param>
        /// <param name="entityIds">entityIds.</param>
        /// <param name="index">index.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="username">username.</param>
        public WorkareaCreationModel(string name = default(string), bool? isShared = default(bool?), QueryModel query = default(QueryModel), List<int?> entityIds = default(List<int?>), int? index = default(int?), string parentId = default(string), string username = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for WorkareaCreationModel and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "isShared" is required (not null)
            if (isShared == null)
            {
                throw new InvalidDataException("isShared is a required property for WorkareaCreationModel and cannot be null");
            }
            else
            {
                this.IsShared = isShared;
            }
            this.Query = query;
            this.EntityIds = entityIds;
            this.Index = index;
            this.ParentId = parentId;
            this.Username = username;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets IsShared
        /// </summary>
        [DataMember(Name="isShared", EmitDefaultValue=false)]
        public bool? IsShared { get; set; }

        /// <summary>
        /// Gets or Sets Query
        /// </summary>
        [DataMember(Name="query", EmitDefaultValue=false)]
        public QueryModel Query { get; set; }

        /// <summary>
        /// Gets or Sets EntityIds
        /// </summary>
        [DataMember(Name="entityIds", EmitDefaultValue=false)]
        public List<int?> EntityIds { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [DataMember(Name="parentId", EmitDefaultValue=false)]
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkareaCreationModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  IsShared: ").Append(IsShared).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  EntityIds: ").Append(EntityIds).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
            return this.Equals(input as WorkareaCreationModel);
        }

        /// <summary>
        /// Returns true if WorkareaCreationModel instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkareaCreationModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkareaCreationModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.IsShared == input.IsShared ||
                    (this.IsShared != null &&
                    this.IsShared.Equals(input.IsShared))
                ) && 
                (
                    this.Query == input.Query ||
                    (this.Query != null &&
                    this.Query.Equals(input.Query))
                ) && 
                (
                    this.EntityIds == input.EntityIds ||
                    this.EntityIds != null &&
                    this.EntityIds.SequenceEqual(input.EntityIds)
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    (this.ParentId != null &&
                    this.ParentId.Equals(input.ParentId))
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.IsShared != null)
                    hashCode = hashCode * 59 + this.IsShared.GetHashCode();
                if (this.Query != null)
                    hashCode = hashCode * 59 + this.Query.GetHashCode();
                if (this.EntityIds != null)
                    hashCode = hashCode * 59 + this.EntityIds.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.ParentId != null)
                    hashCode = hashCode * 59 + this.ParentId.GetHashCode();
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                return hashCode;
            }
        }
    }

}
