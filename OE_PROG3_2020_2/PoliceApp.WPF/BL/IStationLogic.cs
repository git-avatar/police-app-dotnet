// <copyright file="IStationLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.BL
{
    using System.Collections.Generic;
    using PoliceApp.WPF.Data;

    /// <summary>
    /// IStationLogic interface used to list all the CRUD operations that the logic will handle.
    /// </summary>
    internal interface IStationLogic
    {
        /// <summary>
        /// GetStations method resposible for listing all the DB entities.
        /// </summary>
        /// <param name="stations">List of stations in the DB.</param>
        void GetStations(IList<StationModel> stations);

        /// <summary>
        /// AddStation method resposible for adding stations.
        /// </summary>
        /// <param name="stations">List of stations to be added.</param>
        void AddStation(IList<StationModel> stations);

        /// <summary>
        /// ModStation method resposible for modifying stations.
        /// </summary>
        /// <param name="stationToModify">Station to be modified.</param>
        void ModStation(StationModel stationToModify);

        /// <summary>
        /// DelStation method resposible for deleting stations.
        /// </summary>
        /// <param name="stations">List of stations.</param>
        /// <param name="station">Station to be deleted.</param>
        void DelStation(IList<StationModel> stations, StationModel station);
    }
}
