// <copyright file="StationListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// StationListViewModel class.
    /// </summary>
    public class StationListViewModel
    {
        /// <summary>
        /// Gets or sets editedStation property, used for editing a desired station.
        /// </summary>
        public Station EditedStation { get; set; }

        /// <summary>
        /// Gets or sets listOfStations property, used for listing out the list of stations.
        /// </summary>
        public List<Station> ListOfStations { get; set; }
    }
}