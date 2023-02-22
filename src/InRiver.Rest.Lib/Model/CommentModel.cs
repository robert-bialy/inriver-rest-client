using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// CommentModel
    /// </summary>
    [DataContract]
    public class CommentModel :  IEquatable<CommentModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected CommentModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="text">text (required).</param>
        /// <param name="author">author.</param>
        /// <param name="createdDate">createdDate.</param>
        /// <param name="formattedCreatedDate">formattedCreatedDate.</param>
        /// <param name="entityId">entityId.</param>
        public CommentModel(int? id = default(int?), string text = default, string author = default, string createdDate = default, string formattedCreatedDate = default, int? entityId = default(int?))
        {
            // to ensure "text" is required (not null)
            if (text == null)
            {
                throw new InvalidDataException("text is a required property for CommentModel and cannot be null");
            }
            else
            {
                Text = text;
            }
            Id = id;
            Author = author;
            CreatedDate = createdDate;
            FormattedCreatedDate = formattedCreatedDate;
            EntityId = entityId;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Text
        /// </summary>
        [DataMember(Name="text", EmitDefaultValue=false)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or Sets Author
        /// </summary>
        [DataMember(Name="author", EmitDefaultValue=false)]
        public string Author { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets FormattedCreatedDate
        /// </summary>
        [DataMember(Name="formattedCreatedDate", EmitDefaultValue=false)]
        public string FormattedCreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entityId", EmitDefaultValue=false)]
        public int? EntityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommentModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  FormattedCreatedDate: ").Append(FormattedCreatedDate).Append("\n");
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

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as CommentModel);
        }

        /// <summary>
        /// Returns true if CommentModel instances are equal
        /// </summary>
        /// <param name="input">Instance of CommentModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CommentModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) && 
                (
                    Text == input.Text ||
                    (Text != null &&
                    Text.Equals(input.Text))
                ) && 
                (
                    Author == input.Author ||
                    (Author != null &&
                    Author.Equals(input.Author))
                ) && 
                (
                    CreatedDate == input.CreatedDate ||
                    (CreatedDate != null &&
                    CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    FormattedCreatedDate == input.FormattedCreatedDate ||
                    (FormattedCreatedDate != null &&
                    FormattedCreatedDate.Equals(input.FormattedCreatedDate))
                ) && 
                (
                    EntityId == input.EntityId ||
                    (EntityId != null &&
                    EntityId.Equals(input.EntityId))
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                if (Author != null)
                    hashCode = hashCode * 59 + Author.GetHashCode();
                if (CreatedDate != null)
                    hashCode = hashCode * 59 + CreatedDate.GetHashCode();
                if (FormattedCreatedDate != null)
                    hashCode = hashCode * 59 + FormattedCreatedDate.GetHashCode();
                if (EntityId != null)
                    hashCode = hashCode * 59 + EntityId.GetHashCode();
                return hashCode;
            }
        }
    }

}
