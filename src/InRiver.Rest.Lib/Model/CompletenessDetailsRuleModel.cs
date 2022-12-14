using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    public class CompletenessDetailsRuleModel : IEquatable<CompletenessDetailsRuleModel>
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

        public bool Equals(CompletenessDetailsRuleModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && IsCompleted == other.IsCompleted;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CompletenessDetailsRuleModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ IsCompleted.GetHashCode();
            }
        }
    }
}