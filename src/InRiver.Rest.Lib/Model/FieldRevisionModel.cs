using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// FieldRevisionModel
    /// </summary>
    [DataContract]
    public class FieldRevisionModel : IEquatable<FieldRevisionModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldRevisionModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected FieldRevisionModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldRevisionModel" /> class.
        /// </summary>
        /// <param name="fieldTypeId"></param>
        /// <param name="value"></param>
        /// <param name="language"></param>
        /// <param name="revision"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="formattedModifiedDate"></param>
        /// <param name="entityId"></param>
        public FieldRevisionModel(
            string fieldTypeId,
            object value,
            string language,
            int revision,
            string modifiedBy,
            string formattedModifiedDate,
            int entityId)
        {
            FieldTypeId = fieldTypeId;
            Value = value;
            Language = language;
            Revision = revision;
            ModifiedBy = modifiedBy;
            FormattedModifiedDate = formattedModifiedDate;
            EntityId = entityId;
        }

        /// <summary>
        /// Gets or Sets FieldTypeId
        /// </summary>
        [DataMember(Name = "fieldTypeId", EmitDefaultValue = false)]
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public object Value { get; set; }

        /// <summary>
        /// Gets or Sets Language
        /// </summary>
        [DataMember(Name = "language", EmitDefaultValue = false)]
        public string Language { get; set; }

        /// <summary>
        /// Gets or Sets Revision
        /// </summary>
        [DataMember(Name = "revision", EmitDefaultValue = false)]
        public int Revision { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedBy
        /// </summary>
        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedDate
        /// </summary>
        [DataMember(Name = "modifiedDate", EmitDefaultValue = false)]
        public string ModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets FormattedModifiedDate
        /// </summary>
        [DataMember(Name = "formattedModifiedDate", EmitDefaultValue = false)]
        public string FormattedModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name = "entityId", EmitDefaultValue = false)]
        public int EntityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CVLModel {\n");
            sb.Append("  FieldTypeId: ").Append(FieldTypeId).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
            sb.Append("  ModifiedBy: ").Append(ModifiedBy).Append("\n");
            sb.Append("  ModifiedDate: ").Append(ModifiedDate).Append("\n");
            sb.Append("  FormattedModifiedDate: ").Append(FormattedModifiedDate).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
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

        public bool Equals(FieldRevisionModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FieldTypeId == other.FieldTypeId && Equals(Value, other.Value) && Language == other.Language && Revision == other.Revision && ModifiedBy == other.ModifiedBy && ModifiedDate == other.ModifiedDate && FormattedModifiedDate == other.FormattedModifiedDate && EntityId == other.EntityId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FieldRevisionModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var localHashCode = (FieldTypeId != null ? FieldTypeId.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ (Language != null ? Language.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ Revision;
                localHashCode = (localHashCode * 397) ^ (ModifiedBy != null ? ModifiedBy.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ (ModifiedDate != null ? ModifiedDate.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ (FormattedModifiedDate != null ? FormattedModifiedDate.GetHashCode() : 0);
                localHashCode = (localHashCode * 397) ^ EntityId;
                return localHashCode;
            }
        }
    }
}
