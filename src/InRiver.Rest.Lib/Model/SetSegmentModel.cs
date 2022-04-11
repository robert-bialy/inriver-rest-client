using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace InRiver.Rest.Lib.Model
{
    /// <summary>
    /// SetSegmentModel
    /// </summary>
    [DataContract]
    public class SetSegmentModel :  IEquatable<SetSegmentModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetSegmentModel" /> class.
        /// </summary>
        [JsonConstructor]
        protected SetSegmentModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetSegmentModel" /> class.
        /// </summary>
        /// <param name="segmentId">segmentId (required).</param>
        public SetSegmentModel(int? segmentId = default(int?))
        {
            // to ensure "segmentId" is required (not null)
            if (segmentId == null)
            {
                throw new InvalidDataException("segmentId is a required property for SetSegmentModel and cannot be null");
            }
            else
            {
                this.SegmentId = segmentId;
            }
        }
        
        /// <summary>
        /// Gets or Sets SegmentId
        /// </summary>
        [DataMember(Name="segmentId", EmitDefaultValue=false)]
        public int? SegmentId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetSegmentModel {\n");
            sb.Append("  SegmentId: ").Append(SegmentId).Append("\n");
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
            return this.Equals(input as SetSegmentModel);
        }

        /// <summary>
        /// Returns true if SetSegmentModel instances are equal
        /// </summary>
        /// <param name="input">Instance of SetSegmentModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetSegmentModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SegmentId == input.SegmentId ||
                    (this.SegmentId != null &&
                    this.SegmentId.Equals(input.SegmentId))
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
                if (this.SegmentId != null)
                    hashCode = hashCode * 59 + this.SegmentId.GetHashCode();
                return hashCode;
            }
        }
    }

}
