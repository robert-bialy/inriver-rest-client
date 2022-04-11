using System;
using System.Collections.Generic;
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
        public CommentModel(int? id = default(int?), string text = default(string), string author = default(string), string createdDate = default(string), string formattedCreatedDate = default(string), int? entityId = default(int?))
        {
            // to ensure "text" is required (not null)
            if (text == null)
            {
                throw new InvalidDataException("text is a required property for CommentModel and cannot be null");
            }
            else
            {
                this.Text = text;
            }
            this.Id = id;
            this.Author = author;
            this.CreatedDate = createdDate;
            this.FormattedCreatedDate = formattedCreatedDate;
            this.EntityId = entityId;
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CommentModel);
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
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Text == input.Text ||
                    (this.Text != null &&
                    this.Text.Equals(input.Text))
                ) && 
                (
                    this.Author == input.Author ||
                    (this.Author != null &&
                    this.Author.Equals(input.Author))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.FormattedCreatedDate == input.FormattedCreatedDate ||
                    (this.FormattedCreatedDate != null &&
                    this.FormattedCreatedDate.Equals(input.FormattedCreatedDate))
                ) && 
                (
                    this.EntityId == input.EntityId ||
                    (this.EntityId != null &&
                    this.EntityId.Equals(input.EntityId))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.Author != null)
                    hashCode = hashCode * 59 + this.Author.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.FormattedCreatedDate != null)
                    hashCode = hashCode * 59 + this.FormattedCreatedDate.GetHashCode();
                if (this.EntityId != null)
                    hashCode = hashCode * 59 + this.EntityId.GetHashCode();
                return hashCode;
            }
        }
    }

}
