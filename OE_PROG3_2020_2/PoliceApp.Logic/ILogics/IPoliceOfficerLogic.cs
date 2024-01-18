// <copyright file="IPoliceOfficerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.ILogics
{
    using System.Collections.Generic;
    using PoliceApp.Data;
    using PoliceApp.Logic.NonCRUD;

    /// <summary>
    /// IPoliceChiefLogic interface filled with methods that the PoliceOfficerLogic will have.
    /// </summary>
    public interface IPoliceOfficerLogic
    {
        /// <summary>
        /// GetStation function used to get a Station object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Station object.</returns>
        Station GetStation(int id);

        /// <summary>
        /// GetStations function used to get Station objects of a certain dataset.
        /// </summary>
        /// <returns>List of Station objects.</returns>
        IList<Station> GetStations();

        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newName">Name of the Updated station name.</param>
        void UpdateStationName(int id, string newName);

        /// <summary>
        /// GetPolice function used to get a Police object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Police object.</returns>
        Police GetPolice(int id);

        /// <summary>
        /// GetPolices function used to get Police objects of a certain dataset.
        /// </summary>
        /// <returns>List of Police objects.</returns>
        IList<Police> GetPolices();

        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newCity">Name of the Updated city.</param>
        void UpdateCity(int id, string newCity);

        /// <summary>
        /// GetCriminal function used to get a Criminal object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Criminal object.</returns>
        Criminal GetCriminal(int id);

        /// <summary>
        /// GetCriminals function used to get Criminals objects of a certain dataset.
        /// </summary>
        /// <returns>List of Criminals objects.</returns>
        IList<Criminal> GetCriminals();

        /// <summary>
        ///  Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newName">>Name of the Updated name.</param>
        void UpdateCriminalName(int id, string newName);

        /// <summary>
        /// GetCrime function used to get a Crime object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Crime object.</returns>
        Crime GetCrime(int id);

        /// <summary>
        /// GetCrime function used to get Crime objects of a certain dataset.
        /// </summary>
        /// <returns>List of Crime objects.</returns>
        IList<Crime> GetCrimes();

        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newType">Name of the Updated type.</param>
        void UpdateType(int id, string newType);

        /// <summary>
        /// OfficerArrests Non-CRUD method.
        /// </summary>
        /// <returns>List of Police Officer names and the number of arrests they have.</returns>
        IList<OfficerArrests> OfficerArrests();
    }
}
