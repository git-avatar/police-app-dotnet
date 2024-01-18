// <copyright file="Station.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Station class.
    /// </summary>
    [Table("station")]
    public class Station
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Station"/> class.
        /// Station consturctor.
        /// </summary>
        public Station()
        {
            this.GetPolice = new HashSet<Police>();
        }

        /// <summary>
        /// Gets or sets stationId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets stationName property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets stationCity property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string StationCity { get; set; }

        /// <summary>
        /// Gets or sets stationPhone property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string StationPhone { get; set; }

        /// <summary>
        /// Gets or sets stationAddress property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string StationAddress { get; set; }

        /// <summary>
        /// Gets or sets stationPostalCode property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string StationPostCode { get; set; }

        /// <summary>
        /// Gets getPolice virtual property.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Police> GetPolice { get; }
    }
}
