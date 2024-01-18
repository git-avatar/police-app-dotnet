// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.BL
{
    using PoliceApp.WPF.Data;

    /// <summary>
    /// IEditior service interface used to avoid Window dependency.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// EditStation method that is used to in the logic to see if a StationModel is worked on.
        /// </summary>
        /// <param name="station">The StationModel instance that the method will work on.</param>
        /// <returns>True or False output.</returns>
        bool EditStation(StationModel station);
    }
}
