// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    /// <summary>
    /// IEditor service interface used for editing.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// EditStation method used for editing the station.
        /// </summary>
        /// <param name="station">The StationVM to be edited.</param>
        /// <returns>Bool value that depends on if the Station was edited successfully or not.</returns>
        bool EditStation(StationVM station);
    }
}
