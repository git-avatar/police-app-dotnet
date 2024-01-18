// <copyright file="Criminal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Criminal class.
    /// </summary>
    [Table("criminal")]
    public class Criminal
    {
        /// <summary>
        /// Gets or sets criminalId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CriminalId { get; set; }

        /// <summary>
        /// Gets or sets criminalName property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CriminalName { get; set; }

        /// <summary>
        /// Gets or sets criminalPhone property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CriminalPhone { get; set; }

        /// <summary>
        /// Gets or sets criminalCity property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CriminalCity { get; set; }

        /// <summary>
        /// Gets or sets criminalAddress property.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CriminalAddress { get; set; }

        /// <summary>
        /// Gets or sets criminalDOB property.
        /// </summary>
        [Required]
        public DateTime CriminalDOB { get; set; }

        /// <summary>
        /// Gets crimes virtual property.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Crime> Crimes { get; }
    }
}
