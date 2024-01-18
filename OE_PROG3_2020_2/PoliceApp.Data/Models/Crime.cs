// <copyright file="Crime.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class crime.
    /// </summary>
    [Table("crime")]
    public class Crime
    {
        /// <summary>
        /// Gets or sets crimeId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrimeId { get; set; }

        /// <summary>
        /// Gets or sets crimeType property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CrimeType { get; set; }

        /// <summary>
        /// Gets or sets crimeDate property.
        /// </summary>
        [Required]
        public DateTime CrimeDate { get; set; }

        /// <summary>
        /// Gets or sets policeId property.
        /// </summary>
        [ForeignKey(nameof(Police))]
        public int PoliceId { get; set; }

        /// <summary>
        /// Gets or sets criminalId property.
        /// </summary>
        [ForeignKey(nameof(Criminal))]
        public int CriminalId { get; set; }

        /// <summary>
        /// Gets or sets police virtual property.
        /// </summary>
        [NotMapped]
        public virtual Police Police { get; set; }

        /// <summary>
        /// Gets or sets criminal virtual property.
        /// </summary>
        [NotMapped]
        public virtual Criminal Criminal { get; set; }
    }
}
