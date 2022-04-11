using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// ChannelPathContentModel
    /// </summary>
    [DataContract]
    public class ChannelPathContentModel :  IEquatable<ChannelPathContentModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelPathContentModel" /> class.
        /// </summary>
        /// <param name="entityList">entityList.</param>
        /// <param name="content">content.</param>
        public ChannelPathContentModel(EntityListModel entityList = default(EntityListModel), List<StructureEntityModel> content = default(List<StructureEntityModel>))
        {
            this.EntityList = entityList;
            this.Content = content;
        }
        
        /// <summary>
        /// Gets or Sets EntityList
        /// </summary>
        [DataMember(Name="entityList", EmitDefaultValue=false)]
        public EntityListModel EntityList { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public List<StructureEntityModel> Content { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelPathContentModel {\n");
            sb.Append("  EntityList: ").Append(EntityList).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
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
            return this.Equals(input as ChannelPathContentModel);
        }

        /// <summary>
        /// Returns true if ChannelPathContentModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ChannelPathContentModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelPathContentModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityList == input.EntityList ||
                    (this.EntityList != null &&
                    this.EntityList.Equals(input.EntityList))
                ) && 
                (
                    this.Content == input.Content ||
                    this.Content != null &&
                    this.Content.SequenceEqual(input.Content)
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
                if (this.EntityList != null)
                    hashCode = hashCode * 59 + this.EntityList.GetHashCode();
                if (this.Content != null)
                    hashCode = hashCode * 59 + this.Content.GetHashCode();
                return hashCode;
            }
        }
    }

}
