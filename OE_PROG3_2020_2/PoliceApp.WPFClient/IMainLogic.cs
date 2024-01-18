// <copyright file="IMainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// IMainLogic interface that holds all the methods of the MainLogic class.
    /// </summary>
    public interface IMainLogic
    {
        /// <summary>
        /// ApiGetStations method that is responsible for geting all the stations.
        /// </summary>
        /// <returns>List of StationVM intances.</returns>
        List<StationVM> ApiGetStations();

        /// <summary>
        /// ApiDelStations method that is responsible for deleting a station.
        /// </summary>
        /// <param name="station">The StationVM to be removed.</param>
        void ApiDelStations(StationVM station);

        /// <summary>
        /// EditStation method that is responsible for adding/modifying a station.
        /// </summary>
        /// <param name="station">The StationVM to be addeded/modified.</param>
        /// <param name="editor">Func editor.</param>
        void EditStation(StationVM station, Func<StationVM, bool> editor);
    }
}
