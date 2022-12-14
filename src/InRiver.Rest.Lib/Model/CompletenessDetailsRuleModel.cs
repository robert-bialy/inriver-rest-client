using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    public class CompletenessDetailsRuleModel : IEqualityComparer<CompletenessDetailsRuleModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletenessDetailsRuleModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected CompletenessDetailsRuleModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletenessDetailsRuleModel" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="isCompleted">isCompleted.</param>
        /// <param name="rules">rules.</param>
        public CompletenessDetailsRuleModel(string name = default, bool isCompleted = default)
        {
            Name = name;
            IsCompleted = isCompleted;
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

        public bool Equals(CompletenessDetailsRuleModel x, CompletenessDetailsRuleModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && x.IsCompleted == y.IsCompleted;
        }

        public int GetHashCode(CompletenessDetailsRuleModel obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^ obj.IsCompleted.GetHashCode();
            }
        }
    }
}