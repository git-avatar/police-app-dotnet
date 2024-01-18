// <copyright file="PoliceChiefLogic.cs" company="PlaceholderCompany">
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
    using PoliceApp.Repository.Repositories;

    /// <summary>
    /// PoliceChiefLogic class.
    /// </summary>
    public class PoliceChiefLogic : IPoliceChiefLogic
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
        /// Initializes a new instance of the <see cref="PoliceChiefLogic"/> class.
        /// </summary>
        /// <param name="stationRepository">IStationRepositroy interface to be assigned.</param>
        /// <param name="policeRepository">IPoliceRepositroy interface to be assigned.</param>
        /// <param name="criminalRepository">ICriminalRepositroy interface to be assigned.</param>
        /// <param name="crimeRepository">ICrimeRepositroy interface to be assigned.</param>
        public PoliceChiefLogic(IStationRepository stationRepository = null, IPoliceRepository policeRepository = null, ICriminalRepository criminalRepository = null, ICrimeRepository crimeRepository = null)
        {
            PoliceAppDbContext context = new PoliceAppDbContext();
            if (stationRepository == null)
            {
                this.stationRepository = new StationRepository(context);
            }
            else
            {
                this.stationRepository = stationRepository;
            }

            if (policeRepository == null)
            {
                this.policeRepository = new PoliceRepository(context);
            }
            else
            {
                this.policeRepository = policeRepository;
            }

            if (criminalRepository == null)
            {
                this.criminalRepository = new CriminalRepository(context);
            }
            else
            {
                this.criminalRepository = criminalRepository;
            }

            if (crimeRepository == null)
            {
                this.crimeRepository = new CrimeRepository(context);
            }
            else
            {
                this.crimeRepository = crimeRepository;
            }
        }

        /// <summary>
        /// Implements the Add method.
        /// </summary>
        /// <param name="station">Station object.</param>
        public void AddStation(Station station)
        {
            this.stationRepository.Add(station);
        }

        /// <summary>
        /// Implements the AddRange method.
        /// </summary>
        /// <param name="stations">IQueryable list of Station objects.</param>
        public void AddStations(IQueryable<Station> stations)
        {
            this.stationRepository.AddRange(stations);
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
        /// Implements the Remove method(Id).
        /// </summary>
        /// <param name="id">Id of the entity we want to remove.</param>
        public void RemoveStation(int id)
        {
            this.stationRepository.Remove(id);
        }

        /// <summary>
        /// Implements the Remove method.
        /// </summary>
        /// <param name="station">Station object to be removed.</param>
        public void RemoveStation(Station station)
        {
            this.stationRepository.Remove(station);
        }

        /// <summary>
        /// Implements the RemoveOne method.
        /// </summary>
        /// <param name="id">Id of the entity to remove.</param>
        /// <returns>Value if the station was removed correctly or not.</returns>
        public bool RemoveOneStation(int id)
        {
            return this.stationRepository.RemoveOne(id);
        }

        /// <summary>
        /// Implements the RemoveStations method.
        /// </summary>
        /// <param name="stations">IQueryable list of Station objects.</param>
        public void RemoveStations(IQueryable<Station> stations)
        {
            this.stationRepository.RemoveRange(stations);
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
        /// Implementst the UpdateStation method.
        /// </summary>
        /// <param name="id">Id of the desired station.</param>
        /// <param name="newStation">Station to be updated.</param>
        public void UpdateStation(int id, Station newStation)
        {
            this.stationRepository.UpdateStation(id, newStation);
        }

        /// <summary>
        /// Implementst the UpdateOneStation method.
        /// </summary>
        /// <param name="id">Id of the desired station.</param>
        /// <param name="newStation">Station to be updated.</param>
        /// <returns>Bool value based on was the update successfull or not.</returns>
        public bool UpdateOneStation(int id, Station newStation)
        {
            var checkStation = this.stationRepository.GetAll().SingleOrDefault(x => x.StationId == id);
            if (checkStation == null)
            {
                return false;
            }

            return this.stationRepository.UpdateOneStation(id, newStation);
        }

        /// <summary>
        /// Implements the AddPolice method.
        /// </summary>
        /// <param name="police">Police object.</param>
        public void AddPolice(Police police)
        {
            this.policeRepository.Add(police);
        }

        /// <summary>
        /// Implements the AddPolices method.
        /// </summary>
        /// <param name="polices">IQueryable list of Police objects.</param>
        public void AddPolices(IQueryable<Police> polices)
        {
            this.policeRepository.AddRange(polices);
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
        /// Implements the RemovePolice method(Id).
        /// </summary>
        /// <param name="id">Id of the entity we want to remove.</param>
        public void RemovePolice(int id)
        {
            this.policeRepository.Remove(id);
        }

        /// <summary>
        /// Implements the RemovePolice method.
        /// </summary>
        /// <param name="police">Police object to be removed.</param>
        public void RemovePolice(Police police)
        {
            this.policeRepository.Remove(police);
        }

        /// <summary>
        /// Implements the RemovePolices method.
        /// </summary>
        /// <param name="polices">IQueryable list of Police objects.</param>
        public void RemovePolices(IQueryable<Police> polices)
        {
            this.policeRepository.RemoveRange(polices);
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
        /// Implements the AddCriminal method.
        /// </summary>
        /// <param name="criminal">Criminal object.</param>
        public void AddCriminal(Criminal criminal)
        {
            this.criminalRepository.Add(criminal);
        }

        /// <summary>
        /// Implements the AddCriminals method.
        /// </summary>
        /// <param name="criminals">IQueryable list of Criminal objects.</param>
        public void AddCriminals(IQueryable<Criminal> criminals)
        {
            this.criminalRepository.AddRange(criminals);
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
        /// Implements the RemoveCriminal method(Id).
        /// </summary>
        /// <param name="id">Id of the entity we want to remove.</param>
        public void RemoveCriminal(int id)
        {
            this.criminalRepository.Remove(id);
        }

        /// <summary>
        /// Implements the RemoveCriminal method.
        /// </summary>
        /// <param name="criminal">Criminal object to be removed.</param>
        public void RemoveCriminal(Criminal criminal)
        {
            this.criminalRepository.Remove(criminal);
        }

        /// <summary>
        /// Implements the RemoveCriminals method.
        /// </summary>
        /// <param name="criminals">IQueryable list of Criminal objects.</param>
        public void RemoveCriminals(IQueryable<Criminal> criminals)
        {
            this.criminalRepository.RemoveRange(criminals);
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
        /// Implements the AddCrime method.
        /// </summary>
        /// <param name="crime">Crime object.</param>
        public void AddCrime(Crime crime)
        {
            this.crimeRepository.Add(crime);
        }

        /// <summary>
        /// Implements AddCrimes method.
        /// </summary>
        /// <param name="crimes">IQueryable list of Crime objects.</param>
        public void AddCrimes(IQueryable<Crime> crimes)
        {
            this.crimeRepository.AddRange(crimes);
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
        /// Implements the RemoveCrime method(Id).
        /// </summary>
        /// <param name="id">Id of the crime we want to remove.</param>
        public void RemoveCrime(int id)
        {
            this.crimeRepository.Remove(id);
        }

        /// <summary>
        /// Implements the RemoveCrime method.
        /// </summary>
        /// <param name="crime">Crime object to be removed.</param>
        public void RemoveCrime(Crime crime)
        {
            this.crimeRepository.Remove(crime);
        }

        /// <summary>
        /// Implements the RemoveCrimes method.
        /// </summary>
        /// <param name="crimes">IQueryable list of Crime objects.</param>
        public void RemoveCrimes(IQueryable<Crime> crimes)
        {
            this.crimeRepository.RemoveRange(crimes);
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
        /// GetStationPoliceCounts method.
        /// </summary>
        /// <returns>List of stations and the number of police officers assigned to those sations.</returns>
        public IList<StationPoliceCount> GetStationPoliceCounts()
        {
            var officers = from officer in this.policeRepository.GetAll()
                           group officer by officer.StationId into g
                           select new
                           {
                               StationId = g.Key,
                               OfficerCount = g.Count(),
                           };
            var stations = from stationId in officers
                           join station in this.stationRepository.GetAll() on stationId.StationId equals station.StationId
                           orderby stationId.OfficerCount descending
                           select new StationPoliceCount()
                           {
                               StationName = station.StationName,
                               OfficerCount = stationId.OfficerCount,
                           };
            return stations.ToList();
        }

        /// <summary>
        /// GetStationPoliceCountsAsync method that executes theGetStationPoliceCounts method as a task.
        /// </summary>
        /// <returns>List of stations and the number of police officers assigned to those sations.</returns>
        public Task<List<StationPoliceCount>> GetStationPoliceCountsAsync()
        {
            var task = Task.Run(() => this.GetStationPoliceCounts().ToList());
            return task;
        }
    }
}
