// <copyright file="IPoliceReporterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.ILogics
{
    using System.Collections.Generic;
    using PoliceApp.Data;
    using PoliceApp.Logic.NonCRUD;

    /// <summary>
    /// IPoliceReporterLogic interface filled with methods that the PoliceReporterLogic will have.
    /// </summary>
    public interface IPoliceReporterLogic
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
        /// GetCityMurders method.
        /// </summary>
        /// <returns>List of City names and the murder count in that city.</returns>
        IList<CityMurders> GetCityMurders();
    }
}
