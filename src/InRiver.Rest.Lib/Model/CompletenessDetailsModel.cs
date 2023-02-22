using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// CompletenessDetailsModel
    /// </summary>
    [DataContract]
    public class CompletenessDetailsModel : IEqualityComparer<CompletenessDetailsModel>
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
        public CompletenessDetailsModel(int completeness, CompletenessDetailsGroupModel[] groups)
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

        public bool Equals(CompletenessDetailsModel x, CompletenessDetailsModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Completeness == y.Completeness && Equals(x.Groups, y.Groups);
        }

        public int GetHashCode(CompletenessDetailsModel obj)
        {
            unchecked
            {
                return (obj.Completeness * 397) ^ (obj.Groups != null ? obj.Groups.GetHashCode() : 0);
            }
        }
    }
}
