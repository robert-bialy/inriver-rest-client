using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// LinkCriterionModel
    /// </summary>
    [DataContract]
    public class LinkCriterionModel :  IEquatable<LinkCriterionModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkCriterionModel" /> class.
        /// </summary>
        /// <param name="dataCriteria">dataCriteria.</param>
        /// <param name="linkTypeId">linkTypeId.</param>
        /// <param name="direction">direction.</param>
        /// <param name="linkExists">linkExists.</param>
        public LinkCriterionModel(List<DataCriterionModel> dataCriteria = default(List<DataCriterionModel>), string linkTypeId = default, string direction = default, bool? linkExists = default(bool?))
        {
            DataCriteria = dataCriteria;
            LinkTypeId = linkTypeId;
            Direction = direction;
            LinkExists = linkExists;
        }
        
        /// <summary>
        /// Gets or Sets DataCriteria
        /// </summary>
        [DataMember(Name="dataCriteria", EmitDefaultValue=false)]
        public List<DataCriterionModel> DataCriteria { get; set; }

        /// <summary>
        /// Gets or Sets LinkTypeId
        /// </summary>
        [DataMember(Name="linkTypeId", EmitDefaultValue=false)]
        public string LinkTypeId { get; set; }

        /// <summary>
        /// Gets or Sets Direction
        /// </summary>
        [DataMember(Name="direction", EmitDefaultValue=false)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or Sets LinkExists
        /// </summary>
        [DataMember(Name="linkExists", EmitDefaultValue=false)]
        public bool? LinkExists { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkCriterionModel {\n");
            sb.Append("  DataCriteria: ").Append(DataCriteria).Append("\n");
            sb.Append("  LinkTypeId: ").Append(LinkTypeId).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  LinkExists: ").Append(LinkExists).Append("\n");
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
            return Equals(input as LinkCriterionModel);
        }

        /// <summary>
        /// Returns true if LinkCriterionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkCriterionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkCriterionModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    DataCriteria == input.DataCriteria ||
                    DataCriteria != null &&
                    DataCriteria.SequenceEqual(input.DataCriteria)
                ) && 
                (
                    LinkTypeId == input.LinkTypeId ||
                    (LinkTypeId != null &&
                    LinkTypeId.Equals(input.LinkTypeId))
                ) && 
                (
                    Direction == input.Direction ||
                    (Direction != null &&
                    Direction.Equals(input.Direction))
                ) && 
                (
                    LinkExists == input.LinkExists ||
                    (LinkExists != null &&
                    LinkExists.Equals(input.LinkExists))
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
                if (DataCriteria != null)
                    hashCode = hashCode * 59 + DataCriteria.GetHashCode();
                if (LinkTypeId != null)
                    hashCode = hashCode * 59 + LinkTypeId.GetHashCode();
                if (Direction != null)
                    hashCode = hashCode * 59 + Direction.GetHashCode();
                if (LinkExists != null)
                    hashCode = hashCode * 59 + LinkExists.GetHashCode();
                return hashCode;
            }
        }
    }

}
