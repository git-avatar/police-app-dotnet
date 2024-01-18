// <copyright file="ICrimeRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using PoliceApp.Data;

    /// <summary>
    /// Repositroy to deal with the update method.
    /// </summary>
    public interface ICrimeRepository : IRepository<Crime>
    {
        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newType">Name of the Updated type.</param>
        void UpdateType(int id, string newType);
    }
}
