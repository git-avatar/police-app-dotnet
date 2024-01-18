// <copyright file="IStationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using PoliceApp.Data;

    /// <summary>
    /// Repositroy to deal with the update method.
    /// </summary>
    public interface IStationRepository : IRepository<Station>
    {
        /// <summary>
        ///  Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newName">Name of the Updated station name.</param>
        void UpdateName(int id, string newName);

        /// <summary>
        /// Used to implement the UpdateAll method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newStation">The station instance to update.</param>
        void UpdateStation(int id, Station newStation);

        /// <summary>
        /// Used to implement the UpdateAll method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newStation">The station instance to update.</param>
        /// <returns>Bool value which signals if the update was done correctly.</returns>
        bool UpdateOneStation(int id, Station newStation);
    }
}
