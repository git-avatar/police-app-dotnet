// <copyright file="PoliceOfficerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.Logics
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PoliceApp.Data;
    using PoliceApp.Logic.ILogics;
    using PoliceApp.Logic.NonCRUD;
    using PoliceApp.Repository;

    /// <summary>
    /// PoliceOfficerLogic class.
    /// </summary>
    public class PoliceOfficerLogic : IPoliceOfficerLogic
    {
        /// <summary>
        /// IStationRepository.
        /// </summary>
        private readonly IStationRepository stationRepository;

        /// <summary>
        /// IPoliceRepository.
        /// </summary>
        private readonly IPoliceRepository policeRepository;

        /// <summary>
        /// ICriminalRepository.
        /// </summary>
        private readonly ICriminalRepository criminalRepository;

        /// <summary>
        /// ICrimeRepository.
        /// </summary>
        private readonly ICrimeRepository crimeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceOfficerLogic"/> class.
        /// </summary>
        /// <param name="stationRepository">IStationRepositroy interface to be assigned.</param>
        /// <param name="policeRepository">IPoliceRepositroy interface to be assigned.</param>
        /// <param name="criminalRepository">ICriminalRepositroy interface to be assigned.</param>
        /// <param name="crimeRepository">ICrimeRepositroy interface to be assigned.</param>
        public PoliceOfficerLogic(IStationRepository stationRepository, IPoliceRepository policeRepository, ICriminalRepository criminalRepository, ICrimeRepository crimeRepository)
        {
            this.stationRepository = stationRepository;
            this.policeRepository = policeRepository;
            this.criminalRepository = criminalRepository;
            this.crimeRepository = crimeRepository;
        }

        /// <summary>
        /// Implements the GetOne method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Station object.</returns>
        public Station GetStation(int id)
        {
            return this.stationRepository.GetOne(id);
        }

        /// <summary>
        /// Implements the GetStations method.
        /// </summary>
        /// <returns>IList list of Station objects.</returns>
        public IList<Station> GetStations()
        {
            return this.stationRepository.GetAll().ToList();
        }

        /// <summary>
        /// Implementst the UpdateStationName method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newName">Name of the NewName.</param>
        public void UpdateStationName(int id, string newName)
        {
            this.stationRepository.UpdateName(id, newName);
        }

        /// <summary>
        /// Implements the GetPolice method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Police object.</returns>
        public Police GetPolice(int id)
        {
            return this.policeRepository.GetOne(id);
        }

        /// <summary>
        /// Implements the GetPolices method.
        /// </summary>
        /// <returns>IList list of Police objects.</returns>
        public IList<Police> GetPolices()
        {
            return this.policeRepository.GetAll().ToList();
        }

        /// <summary>
        /// Implementst the UpdateCity method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newCity">Name of the NewCity.</param>
        public void UpdateCity(int id, string newCity)
        {
            this.policeRepository.UpdateCity(id, newCity);
        }

        /// <summary>
        /// Implements the GetCriminal method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Criminal object.</returns>
        public Criminal GetCriminal(int id)
        {
            return this.criminalRepository.GetOne(id);
        }

        /// <summary>
        /// Implements the GetCriminals method.
        /// </summary>
        /// <returns>IList list of Criminal objects.</returns>
        public IList<Criminal> GetCriminals()
        {
            return this.criminalRepository.GetAll().ToList();
        }

        /// <summary>
        /// Implementst the UpdateCriminalName method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newName">Name of the NewName.</param>
        public void UpdateCriminalName(int id, string newName)
        {
            this.criminalRepository.UpdateName(id, newName);
        }

        /// <summary>
        /// Implements the GetCrime method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>Crime object.</returns>
        public Crime GetCrime(int id)
        {
            return this.crimeRepository.GetOne(id);
        }

        /// <summary>
        /// Implements the GetCrimes method.
        /// </summary>
        /// <returns>IList list of Crime objects.</returns>
        public IList<Crime> GetCrimes()
        {
            return this.crimeRepository.GetAll().ToList();
        }

        /// <summary>
        /// Implements the UpdateType method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newType">Name of the NewType.</param>
        public void UpdateType(int id, string newType)
        {
            this.crimeRepository.UpdateType(id, newType);
        }

        /// <summary>
        /// OfficerArrests method.
        /// </summary>
        /// <returns>List of Police Officers and the number of arrest they each have.</returns>
        public IList<OfficerArrests> OfficerArrests()
        {
            var arrests = from crime in this.crimeRepository.GetAll()
                          group crime by crime.PoliceId into g
                          select new
                          {
                              OfficerId = g.Key,
                              ArrestCount = g.Count(),
                          };
            var officers = from officerId in arrests
                           join officer in this.policeRepository.GetAll() on officerId.OfficerId equals officer.PoliceId
                           orderby officerId.ArrestCount descending
                           select new OfficerArrests()
                           {
                               OfficerName = officer.PoliceName,
                               ArrestCount = officerId.ArrestCount,
                           };
            return officers.ToList();
        }

        /// <summary>
        /// OfficerArrestsAsync method that executes OfficerArrests method as a task.
        /// </summary>
        /// <returns>List of Police Officers and the number of arrest they each have.</returns>
        public Task<List<OfficerArrests>> OfficerArrestsAsync()
        {
            var task = Task.Run(() => this.OfficerArrests().ToList());
            return task;
        }
    }
}
