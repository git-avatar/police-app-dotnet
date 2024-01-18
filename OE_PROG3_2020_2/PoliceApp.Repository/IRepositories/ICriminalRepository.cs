// <copyright file="ICriminalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using PoliceApp.Data;

    /// <summary>
    /// Repositroy to deal with the update method.
    /// </summary>
    public interface ICriminalRepository : IRepository<Criminal>
    {
        /// <summary>
        ///  Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newName">>Name of the Updated name.</param>
        void UpdateName(int id, string newName);
    }
}
