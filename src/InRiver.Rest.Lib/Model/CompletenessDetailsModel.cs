using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// CompletenessDetailsModel
    /// </summary>
    [DataContract]
    public class CompletenessDetailsModel : IEquatable<CompletenessDetailsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletenessDetailsModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected CompletenessDetailsModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CVLModel" /> class.
        /// </summary>
        /// <param name="completeness">completeness.</param>
        /// <param name="groups">groups.</param>
        public CompletenessDetailsModel(int completeness = default, CompletenessDetailsGroupModel[] groups = default)
        {
            Completeness = completeness;
            Groups = groups;
        }

        /// <summary>
        /// Gets or Sets Completeness
        /// </summary>
        [DataMember(Name = "completeness", EmitDefaultValue = false)]
        public int Completeness { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public CompletenessDetailsGroupModel[] Groups { get; set; }

        public bool Equals(CompletenessDetailsModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Completeness == other.Completeness && Equals(Groups, other.Groups);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CompletenessDetailsModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Completeness * 397) ^ (Groups != null ? Groups.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CVLModel {\n");
            sb.Append("  Completeness: ").Append(Completeness).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
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
    }
}
