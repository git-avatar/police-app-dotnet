// <copyright file="Station.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Station model class.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets stationId property.
        /// </summary>
        [Display(Name = "Station id")]
        [Required]
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets stationName property.
        /// </summary>
        [Display(Name = "Station Name")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets stationCity property.
        /// </summary>
        [Display(Name = "Station City")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StationCity { get; set; }

        /// <summary>
        /// Gets or sets stationPhone property.
        /// </summary>
        [Display(Name = "Station Phone")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StationPhone { get; set; }

        /// <summary>
        /// Gets or sets stationAddress property.
        /// </summary>
        [Display(Name = "Station Address")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StationAddress { get; set; }

        /// <summary>
        /// Gets or sets stationPostCode property.
        /// </summary>
        [Display(Name = "Station Postal Code")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StationPostCode { get; set; }
    }
}
