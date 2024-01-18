// <copyright file="PoliceReporterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Program.MenuItems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PoliceApp.Data;
    using PoliceApp.Logic.ILogics;
    using PoliceApp.Logic.NonCRUD;
    using PoliceApp.Repository;

    /// <summary>
    /// PoliceReporterLogic class.
    /// </summary>
    public class PoliceReporterLogic : IPoliceReporterLogic
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
        /// Initializes a new instance of the <see cref="PoliceReporterLogic"/> class.
        /// </summary>
        /// <param name="stationRepository">IStationRepositroy interface to be assigned.</param>
        /// <param name="policeRepository">IPoliceRepositroy interface to be assigned.</param>
        /// <param name="criminalRepository">ICriminalRepositroy interface to be assigned.</param>
        /// <param name="crimeRepository">ICrimeRepositroy interface to be assigned.</param>
        public PoliceReporterLogic(IStationRepository stationRepository, IPoliceRepository policeRepository, ICriminalRepository criminalRepository, ICrimeRepository crimeRepository)
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
        /// GetCityMurders method implementation.
        /// </summary>
        /// <returns>A list of cityies that have murders commited in them.</returns>
        public IList<CityMurders> GetCityMurders()
        {
            var murderCriminals = from crime in this.crimeRepository.GetAll()
                                  where crime.CrimeType.ToUpper() == "MURDER"
                                  select new
                                  {
                                      CriminalId = crime.CrimeId,
                                  };
            var murderCity = from criminalId in murderCriminals
                             join criminal in this.criminalRepository.GetAll() on criminalId.CriminalId equals criminal.CriminalId
                             group criminal by criminal.CriminalCity into g
                             orderby g.Count() descending
                             select new CityMurders()
                             {
                                 CityName = g.Key,
                                 MurderCount = g.Count(),
                             };
            return murderCity.ToList();
        }

        /// <summary>
        /// GetCityMurdersAsync method that executes GetCityMurders method as a task.
        /// </summary>
        /// <returns>A list of cityies that have murders commited in them.</returns>
        public Task<List<CityMurders>> GetCityMurdersAsync()
        {
            var task = Task.Run(() => this.GetCityMurders().ToList());
            return task;
        }
    }
}
