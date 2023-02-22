using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// MediaInfoModel
    /// </summary>
    [DataContract]
    public class MediaInfoModel :  IEquatable<MediaInfoModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaInfoModel" /> class.
        /// </summary>
        /// <param name="fileId">fileId.</param>
        /// <param name="url">url.</param>
        /// <param name="fileName">fileName.</param>
        /// <param name="extension">extension.</param>
        /// <param name="fileSize">fileSize.</param>
        /// <param name="dateCreated">dateCreated.</param>
        /// <param name="lastModified">lastModified.</param>
        /// <param name="entityId">entityId.</param>
        public MediaInfoModel(int? fileId = default(int?), string url = default, string fileName = default, string extension = default, long? fileSize = default(long?), string dateCreated = default, string lastModified = default, int? entityId = default(int?))
        {
            FileId = fileId;
            Url = url;
            FileName = fileName;
            Extension = extension;
            FileSize = fileSize;
            DateCreated = dateCreated;
            LastModified = lastModified;
            EntityId = entityId;
        }
        
        /// <summary>
        /// Gets or Sets FileId
        /// </summary>
        [DataMember(Name="fileId", EmitDefaultValue=false)]
        public int? FileId { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets FileName
        /// </summary>
        [DataMember(Name="fileName", EmitDefaultValue=false)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or Sets Extension
        /// </summary>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or Sets FileSize
        /// </summary>
        [DataMember(Name="fileSize", EmitDefaultValue=false)]
        public long? FileSize { get; set; }

        /// <summary>
        /// Gets or Sets DateCreated
        /// </summary>
        [DataMember(Name="dateCreated", EmitDefaultValue=false)]
        public string DateCreated { get; set; }

        /// <summary>
        /// Gets or Sets LastModified
        /// </summary>
        [DataMember(Name="lastModified", EmitDefaultValue=false)]
        public string LastModified { get; set; }

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
            sb.Append("class MediaInfoModel {\n");
            sb.Append("  FileId: ").Append(FileId).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  Extension: ").Append(Extension).Append("\n");
            sb.Append("  FileSize: ").Append(FileSize).Append("\n");
            sb.Append("  DateCreated: ").Append(DateCreated).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
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
            return Equals(input as MediaInfoModel);
        }

        /// <summary>
        /// Returns true if MediaInfoModel instances are equal
        /// </summary>
        /// <param name="input">Instance of MediaInfoModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MediaInfoModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    FileId == input.FileId ||
                    (FileId != null &&
                    FileId.Equals(input.FileId))
                ) && 
                (
                    Url == input.Url ||
                    (Url != null &&
                    Url.Equals(input.Url))
                ) && 
                (
                    FileName == input.FileName ||
                    (FileName != null &&
                    FileName.Equals(input.FileName))
                ) && 
                (
                    Extension == input.Extension ||
                    (Extension != null &&
                    Extension.Equals(input.Extension))
                ) && 
                (
                    FileSize == input.FileSize ||
                    (FileSize != null &&
                    FileSize.Equals(input.FileSize))
                ) && 
                (
                    DateCreated == input.DateCreated ||
                    (DateCreated != null &&
                    DateCreated.Equals(input.DateCreated))
                ) && 
                (
                    LastModified == input.LastModified ||
                    (LastModified != null &&
                    LastModified.Equals(input.LastModified))
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
                if (FileId != null)
                    hashCode = hashCode * 59 + FileId.GetHashCode();
                if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                if (FileName != null)
                    hashCode = hashCode * 59 + FileName.GetHashCode();
                if (Extension != null)
                    hashCode = hashCode * 59 + Extension.GetHashCode();
                if (FileSize != null)
                    hashCode = hashCode * 59 + FileSize.GetHashCode();
                if (DateCreated != null)
                    hashCode = hashCode * 59 + DateCreated.GetHashCode();
                if (LastModified != null)
                    hashCode = hashCode * 59 + LastModified.GetHashCode();
                if (EntityId != null)
                    hashCode = hashCode * 59 + EntityId.GetHashCode();
                return hashCode;
            }
        }
    }

}
