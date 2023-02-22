using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// CVLModel
    /// </summary>
    [DataContract]
    public class CVLModel :  IEquatable<CVLModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CVLModel" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="dataType">dataType.</param>
        public CVLModel(string id = default, string parentId = default, string dataType = default)
        {
            Id = id;
            ParentId = parentId;
            DataType = dataType;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [DataMember(Name="parentId", EmitDefaultValue=false)]
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or Sets DataType
        /// </summary>
        [DataMember(Name="dataType", EmitDefaultValue=false)]
        public string DataType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CVLModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  DataType: ").Append(DataType).Append("\n");
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
            return Equals(input as CVLModel);
        }

        /// <summary>
        /// Returns true if CVLModel instances are equal
        /// </summary>
        /// <param name="input">Instance of CVLModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CVLModel input)
        {
            if(input == null)
                return false;

            return 
               (
                    Id == input.Id ||
                   (Id != null &&
                    Id.Equals(input.Id))
                ) && 
               (
                    ParentId == input.ParentId ||
                   (ParentId != null &&
                    ParentId.Equals(input.ParentId))
                ) && 
               (
                    DataType == input.DataType ||
                   (DataType != null &&
                    DataType.Equals(input.DataType))
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
                if(Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if(ParentId != null)
                    hashCode = hashCode * 59 + ParentId.GetHashCode();
                if(DataType != null)
                    hashCode = hashCode * 59 + DataType.GetHashCode();
                return hashCode;
            }
        }
    }

}
