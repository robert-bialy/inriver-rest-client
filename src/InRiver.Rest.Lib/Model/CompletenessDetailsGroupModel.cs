using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    public class CompletenessDetailsGroupModel : IEquatable<CompletenessDetailsGroupModel>
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
        public CompletenessDetailsGroupModel(string name = default, bool isCompleted = default, CompletenessDetailsRuleModel[] rules = default)
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

        public bool Equals(CompletenessDetailsGroupModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && IsCompleted == other.IsCompleted && Equals(Rules, other.Rules);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CompletenessDetailsGroupModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var localHashCode = (Name != null ? Name.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ IsCompleted.GetHashCode();
                localHashCode = (localHashCode * 397) ^ (Rules != null ? Rules.GetHashCode() : 0);
                return localHashCode;
            }
        }
    }
}