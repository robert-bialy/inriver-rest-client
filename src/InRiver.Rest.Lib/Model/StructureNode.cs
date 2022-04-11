using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// StructureNode
    /// </summary>
    [DataContract]
    public class StructureNode :  IEquatable<StructureNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructureNode" /> class.
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="nodes">nodes.</param>
        public StructureNode(string path = default(string), Dictionary<string, StructureNode> nodes = default(Dictionary<string, StructureNode>))
        {
            this.Path = path;
            this.Nodes = nodes;
        }
        
        /// <summary>
        /// Gets or Sets Path
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or Sets Nodes
        /// </summary>
        [DataMember(Name="nodes", EmitDefaultValue=false)]
        public Dictionary<string, StructureNode> Nodes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StructureNode {\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Nodes: ").Append(Nodes).Append("\n");
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
            return this.Equals(input as StructureNode);
        }

        /// <summary>
        /// Returns true if StructureNode instances are equal
        /// </summary>
        /// <param name="input">Instance of StructureNode to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StructureNode input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Nodes == input.Nodes ||
                    this.Nodes != null &&
                    this.Nodes.SequenceEqual(input.Nodes)
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
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.Nodes != null)
                    hashCode = hashCode * 59 + this.Nodes.GetHashCode();
                return hashCode;
            }
        }
    }

}
