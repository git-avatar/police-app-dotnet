// <copyright file="IPoliceChiefLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.ILogics
{
    using System.Collections.Generic;
    using System.Linq;
    using PoliceApp.Data;
    using PoliceApp.Logic.NonCRUD;

    /// <summary>
    /// IPoliceChiefLogic interface filled with methods that the PoliceChiefLogic will have.
    /// </summary>
    public interface IPoliceChiefLogic
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
        /// AddStation function used to add a Station object.
        /// </summary>
        /// <param name="station">Station to be added.</param>
        void AddStation(Station station);

        /// <summary>
        /// AddStations function used to add a list of Station objects.
        /// </summary>
        /// <param name="stations">IQueryable objects of type Station.</param>
        void AddStations(IQueryable<Station> stations);

        /// <summary>
        /// Remove function used to remove a Station of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        void RemoveStation(int id);

        /// <summary>
        /// Remove function used to remove an Station object.
        /// </summary>
        /// <param name="station">Station to be removed.</param>
        void RemoveStation(Station station);

        /// <summary>
        /// Remove function used to remove a Station.
        /// </summary>
        /// <param name="id">Idof the desired element.</param>
        /// <returns>Bool value based on if the station was removed or not.</returns>
        bool RemoveOneStation(int id);

        /// <summary>
        /// RemoveStations function used to remove a list of Station objects.
        /// </summary>
        /// <param name="stations">IQueryable objects of type Station.</param>
        void RemoveStations(IQueryable<Station> stations);

        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newName">Name of the Updated station name.</param>
        void UpdateStationName(int id, string newName);

        /// <summary>
        /// UpdateStation function used to update one Station objects.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newStation">Station instance to be updated.</param>
        void UpdateStation(int id, Station newStation);

        /// <summary>
        /// UpdateStation function used to update one Station objects.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newStation">Station instance to be updated.</param>
        /// <returns>Bool value based on was the station updated or not.</returns>
        bool UpdateOneStation(int id, Station newStation);

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
        /// AddPolice function used to add a Police object.
        /// </summary>
        /// <param name="police">Police to be added.</param>
        void AddPolice(Police police);

        /// <summary>
        /// AddPolices function used to add a list of Police objects.
        /// </summary>
        /// <param name="polices">IQueryable objects of type Police.</param>
        void AddPolices(IQueryable<Police> polices);

        /// <summary>
        /// Remove function used to remove a Police of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        void RemovePolice(int id);

        /// <summary>
        /// Remove function used to remove an Police object.
        /// </summary>
        /// <param name="police">Police to be removed.</param>
        void RemovePolice(Police police);

        /// <summary>
        /// RemovePolices function used to remove a list of Police objects.
        /// </summary>
        /// <param name="polices">IQueryable objects of type Police.</param>
        void RemovePolices(IQueryable<Police> polices);

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
        /// AddCriminal function used to add a Criminal object.
        /// </summary>
        /// <param name="criminal">Criminal to be added.</param>
        void AddCriminal(Criminal criminal);

        /// <summary>
        /// AddCriminals function used to add a list of Criminal objects.
        /// </summary>
        /// <param name="criminals">IQueryable objects of type Criminal.</param>
        void AddCriminals(IQueryable<Criminal> criminals);

        /// <summary>
        /// Remove function used to remove a Criminal of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        void RemoveCriminal(int id);

        /// <summary>
        /// Remove function used to remove an Criminal object.
        /// </summary>
        /// <param name="criminal">Criminal to be removed.</param>
        void RemoveCriminal(Criminal criminal);

        /// <summary>
        /// RemoveCriminals function used to remove a list of Criminal objects.
        /// </summary>
        /// <param name="criminals">IQueryable objects of type Criminal.</param>
        void RemoveCriminals(IQueryable<Criminal> criminals);

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
        /// AddCrime function used to add a Crime object.
        /// </summary>
        /// <param name="crime">Crime to be added.</param>
        void AddCrime(Crime crime);

        /// <summary>
        /// AddCrimes function used to add a list of Crimes objects.
        /// </summary>
        /// <param name="crimes">IQueryable objects of type Crimes.</param>
        void AddCrimes(IQueryable<Crime> crimes);

        /// <summary>
        /// Remove function used to remove a Crime of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        void RemoveCrime(int id);

        /// <summary>
        /// Remove function used to remove an Crime object.
        /// </summary>
        /// <param name="crime">Crime to be removed.</param>
        void RemoveCrime(Crime crime);

        /// <summary>
        /// RemoveCrimes function used to remove a list of Crime objects.
        /// </summary>
        /// <param name="crimes">IQueryable objects of type Crime.</param>
        void RemoveCrimes(IQueryable<Crime> crimes);

        /// <summary>
        /// Makes an update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newType">Name of the Updated type.</param>
        void UpdateType(int id, string newType);

        /// <summary>
        /// GetStationPoliceCounts Non-CRUD method.
        /// </summary>
        /// <returns>List of StationPoliceCount objects.</returns>
        IList<StationPoliceCount> GetStationPoliceCounts();
    }
}
