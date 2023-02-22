using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// WorkareaFolderModel
    /// </summary>
    [DataContract]
    public class WorkareaFolderModel :  IEquatable<WorkareaFolderModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkareaFolderModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="isQuery">isQuery.</param>
        /// <param name="index">index.</param>
        public WorkareaFolderModel(string id = default, string name = default, bool? isQuery = default(bool?), int? index = default(int?))
        {
            Id = id;
            Name = name;
            IsQuery = isQuery;
            Index = index;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets IsQuery
        /// </summary>
        [DataMember(Name="isQuery", EmitDefaultValue=false)]
        public bool? IsQuery { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkareaFolderModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  IsQuery: ").Append(IsQuery).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
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
            return Equals(input as WorkareaFolderModel);
        }

        /// <summary>
        /// Returns true if WorkareaFolderModel instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkareaFolderModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkareaFolderModel input)
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
                    IsQuery == input.IsQuery ||
                    (IsQuery != null &&
                    IsQuery.Equals(input.IsQuery))
                ) && 
                (
                    Index == input.Index ||
                    (Index != null &&
                    Index.Equals(input.Index))
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
                if (IsQuery != null)
                    hashCode = hashCode * 59 + IsQuery.GetHashCode();
                if (Index != null)
                    hashCode = hashCode * 59 + Index.GetHashCode();
                return hashCode;
            }
        }
    }

}
