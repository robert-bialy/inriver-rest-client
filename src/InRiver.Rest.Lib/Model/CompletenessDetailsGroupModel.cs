using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    public class CompletenessDetailsGroupModel : IEqualityComparer<CompletenessDetailsGroupModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletenessDetailsGroupModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected CompletenessDetailsGroupModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletenessDetailsGroupModel" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="isCompleted">isCompleted.</param>
        /// <param name="rules">rules.</param>
        public CompletenessDetailsGroupModel(string name, bool isCompleted, CompletenessDetailsRuleModel[] rules)
        {
            Name = name;
            IsCompleted = isCompleted;
            Rules = rules;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets IsCompleted
        /// </summary>
        [DataMember(Name = "isCompleted", EmitDefaultValue = false)]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or Sets Rules
        /// </summary>
        [DataMember(Name = "rules", EmitDefaultValue = false)]
        public CompletenessDetailsRuleModel[] Rules { get; set; }

        public bool Equals(CompletenessDetailsGroupModel x, CompletenessDetailsGroupModel y)
        {
            if(ReferenceEquals(x, y)) return true;
            if(ReferenceEquals(x, null)) return false;
            if(ReferenceEquals(y, null)) return false;
            if(x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && x.IsCompleted == y.IsCompleted && Equals(x.Rules, y.Rules);
        }

        public int GetHashCode(CompletenessDetailsGroupModel obj)
        {
            unchecked
            {
                var localHashCode =(obj.Name != null ? obj.Name.GetHashCode() : 0);
                localHashCode =(localHashCode * 397) ^ obj.IsCompleted.GetHashCode();
                localHashCode =(localHashCode * 397) ^(obj.Rules != null ? obj.Rules.GetHashCode() : 0);
                return localHashCode;
            }
        }
    }
}