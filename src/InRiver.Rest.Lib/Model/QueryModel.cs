using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// QueryModel
    /// </summary>
    [DataContract]
    public class QueryModel :  IEquatable<QueryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryModel" /> class.
        /// </summary>
        /// <param name="systemCriteria">systemCriteria.</param>
        /// <param name="dataCriteria">dataCriteria.</param>
        /// <param name="linkCriterion">linkCriterion.</param>
        public QueryModel(List<SystemCriterionModel> systemCriteria = default(List<SystemCriterionModel>), List<DataCriterionModel> dataCriteria = default(List<DataCriterionModel>), LinkCriterionModel linkCriterion = default(LinkCriterionModel))
        {
            this.SystemCriteria = systemCriteria;
            this.DataCriteria = dataCriteria;
            this.LinkCriterion = linkCriterion;
        }
        
        /// <summary>
        /// Gets or Sets SystemCriteria
        /// </summary>
        [DataMember(Name="systemCriteria", EmitDefaultValue=false)]
        public List<SystemCriterionModel> SystemCriteria { get; set; }

        /// <summary>
        /// Gets or Sets DataCriteria
        /// </summary>
        [DataMember(Name="dataCriteria", EmitDefaultValue=false)]
        public List<DataCriterionModel> DataCriteria { get; set; }

        /// <summary>
        /// Gets or Sets LinkCriterion
        /// </summary>
        [DataMember(Name="linkCriterion", EmitDefaultValue=false)]
        public LinkCriterionModel LinkCriterion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QueryModel {\n");
            sb.Append("  SystemCriteria: ").Append(SystemCriteria).Append("\n");
            sb.Append("  DataCriteria: ").Append(DataCriteria).Append("\n");
            sb.Append("  LinkCriterion: ").Append(LinkCriterion).Append("\n");
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
            return this.Equals(input as QueryModel);
        }

        /// <summary>
        /// Returns true if QueryModel instances are equal
        /// </summary>
        /// <param name="input">Instance of QueryModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QueryModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SystemCriteria == input.SystemCriteria ||
                    this.SystemCriteria != null &&
                    this.SystemCriteria.SequenceEqual(input.SystemCriteria)
                ) && 
                (
                    this.DataCriteria == input.DataCriteria ||
                    this.DataCriteria != null &&
                    this.DataCriteria.SequenceEqual(input.DataCriteria)
                ) && 
                (
                    this.LinkCriterion == input.LinkCriterion ||
                    (this.LinkCriterion != null &&
                    this.LinkCriterion.Equals(input.LinkCriterion))
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
                if (this.SystemCriteria != null)
                    hashCode = hashCode * 59 + this.SystemCriteria.GetHashCode();
                if (this.DataCriteria != null)
                    hashCode = hashCode * 59 + this.DataCriteria.GetHashCode();
                if (this.LinkCriterion != null)
                    hashCode = hashCode * 59 + this.LinkCriterion.GetHashCode();
                return hashCode;
            }
        }
    }

}
