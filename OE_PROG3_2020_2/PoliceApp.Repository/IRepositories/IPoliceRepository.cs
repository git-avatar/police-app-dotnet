// <copyright file="IPoliceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using PoliceApp.Data;

    /// <summary>
    /// Repositroy to deal with the update method.
    /// </summary>
    public interface IPoliceRepository : IRepository<Police>
    {
        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newCity">Name of the Updated city.</param>
        void UpdateCity(int id, string newCity);
    }
}
