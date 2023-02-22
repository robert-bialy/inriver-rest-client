using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// EntityListModel
    /// </summary>
    [DataContract]
    public class EntityListModel :  IEquatable<EntityListModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityListModel" /> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="entityIds">entityIds.</param>
        public EntityListModel(int? count = default(int?), List<int?> entityIds = default(List<int?>))
        {
            Count = count;
            EntityIds = entityIds;
        }
        
        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue=false)]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or Sets EntityIds
        /// </summary>
        [DataMember(Name="entityIds", EmitDefaultValue=false)]
        public List<int?> EntityIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityListModel {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  EntityIds: ").Append(EntityIds).Append("\n");
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
            return Equals(input as EntityListModel);
        }

        /// <summary>
        /// Returns true if EntityListModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntityListModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntityListModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    Count == input.Count ||
                    (Count != null &&
                    Count.Equals(input.Count))
                ) && 
                (
                    EntityIds == input.EntityIds ||
                    EntityIds != null &&
                    EntityIds.SequenceEqual(input.EntityIds)
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
                if (Count != null)
                    hashCode = hashCode * 59 + Count.GetHashCode();
                if (EntityIds != null)
                    hashCode = hashCode * 59 + EntityIds.GetHashCode();
                return hashCode;
            }
        }
    }

}
