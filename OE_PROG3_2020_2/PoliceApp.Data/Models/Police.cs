// <copyright file="Police.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Police.
    /// </summary>
    [Table("police")]
    public class Police
    {
        /// <summary>
        /// Gets or sets policeId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PoliceId { get; set; }

        /// <summary>
        /// Gets or sets policeName property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PoliceName { get; set; }

        /// <summary>
        /// Gets or sets policePhone property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PolicePhone { get; set; }

        /// <summary>
        /// Gets or sets policeCity property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PoliceCity { get; set; }

        /// <summary>
        /// Gets or sets policeAddress property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PoliceAddress { get; set; }

        /// <summary>
        /// Gets or sets policeDOB property.
        /// </summary>
        [Required]
        public DateTime PoliceDOB { get; set; }

        /// <summary>
        /// Gets or sets stationId property.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Station))]
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets station virtual property.
        /// </summary>
        [NotMapped]
        public virtual Station Station { get; set; }

        /// <summary>
        /// Gets crimes virtual property.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Crime> Crimes { get; }
    }
}
