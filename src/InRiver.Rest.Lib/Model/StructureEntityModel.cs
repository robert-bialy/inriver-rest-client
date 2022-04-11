using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// StructureEntityModel
    /// </summary>
    [DataContract]
    public class StructureEntityModel :  IEquatable<StructureEntityModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructureEntityModel" /> class.
        /// </summary>
        /// <param name="entityId">entityId.</param>
        /// <param name="entityTypeId">entityTypeId.</param>
        /// <param name="name">name.</param>
        /// <param name="sortOrder">sortOrder.</param>
        /// <param name="path">path.</param>
        /// <param name="linkEntityId">linkEntityId.</param>
        /// <param name="linkTypeIdFromParent">linkTypeIdFromParent.</param>
        public StructureEntityModel(int? entityId = default(int?), string entityTypeId = default(string), string name = default(string), int? sortOrder = default(int?), string path = default(string), int? linkEntityId = default(int?), string linkTypeIdFromParent = default(string))
        {
            this.EntityId = entityId;
            this.EntityTypeId = entityTypeId;
            this.Name = name;
            this.SortOrder = sortOrder;
            this.Path = path;
            this.LinkEntityId = linkEntityId;
            this.LinkTypeIdFromParent = linkTypeIdFromParent;
        }
        
        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entityId", EmitDefaultValue=false)]
        public int? EntityId { get; set; }

        /// <summary>
        /// Gets or Sets EntityTypeId
        /// </summary>
        [DataMember(Name="entityTypeId", EmitDefaultValue=false)]
        public string EntityTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets SortOrder
        /// </summary>
        [DataMember(Name="sortOrder", EmitDefaultValue=false)]
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or Sets Path
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or Sets LinkEntityId
        /// </summary>
        [DataMember(Name="linkEntityId", EmitDefaultValue=false)]
        public int? LinkEntityId { get; set; }

        /// <summary>
        /// Gets or Sets LinkTypeIdFromParent
        /// </summary>
        [DataMember(Name="linkTypeIdFromParent", EmitDefaultValue=false)]
        public string LinkTypeIdFromParent { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StructureEntityModel {\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  EntityTypeId: ").Append(EntityTypeId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SortOrder: ").Append(SortOrder).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  LinkEntityId: ").Append(LinkEntityId).Append("\n");
            sb.Append("  LinkTypeIdFromParent: ").Append(LinkTypeIdFromParent).Append("\n");
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
            return this.Equals(input as StructureEntityModel);
        }

        /// <summary>
        /// Returns true if StructureEntityModel instances are equal
        /// </summary>
        /// <param name="input">Instance of StructureEntityModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StructureEntityModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityId == input.EntityId ||
                    (this.EntityId != null &&
                    this.EntityId.Equals(input.EntityId))
                ) && 
                (
                    this.EntityTypeId == input.EntityTypeId ||
                    (this.EntityTypeId != null &&
                    this.EntityTypeId.Equals(input.EntityTypeId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.SortOrder == input.SortOrder ||
                    (this.SortOrder != null &&
                    this.SortOrder.Equals(input.SortOrder))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.LinkEntityId == input.LinkEntityId ||
                    (this.LinkEntityId != null &&
                    this.LinkEntityId.Equals(input.LinkEntityId))
                ) && 
                (
                    this.LinkTypeIdFromParent == input.LinkTypeIdFromParent ||
                    (this.LinkTypeIdFromParent != null &&
                    this.LinkTypeIdFromParent.Equals(input.LinkTypeIdFromParent))
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
                if (this.EntityId != null)
                    hashCode = hashCode * 59 + this.EntityId.GetHashCode();
                if (this.EntityTypeId != null)
                    hashCode = hashCode * 59 + this.EntityTypeId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.SortOrder != null)
                    hashCode = hashCode * 59 + this.SortOrder.GetHashCode();
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.LinkEntityId != null)
                    hashCode = hashCode * 59 + this.LinkEntityId.GetHashCode();
                if (this.LinkTypeIdFromParent != null)
                    hashCode = hashCode * 59 + this.LinkTypeIdFromParent.GetHashCode();
                return hashCode;
            }
        }
    }

}
