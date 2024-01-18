// <copyright file="StationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PoliceApp.Data;

    /// <summary>
    /// StationRepository class.
    /// </summary>
    public class StationRepository : Repo<Station>, IStationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext to deal with data.</param>
        public StationRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Implements the GetOne method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        public override Station GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.StationId == id);
        }

        /// <summary>
        /// Implements the update method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newName">Name of the Updated name.</param>
        public void UpdateName(int id, string newName)
        {
            var station = this.GetOne(id);
            station.StationName = newName;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Mehtod to Update all the properties for a station instance.
        /// </summary>
        /// <param name="id">The id of the selected station.</param>
        /// <param name="newStation">The selected station to update.</param>
        /// <returns>Update method signaling if the update was correct or not.</returns>
        public bool UpdateOneStation(int id, Station newStation)
        {
            if (newStation != null)
            {
                int myId = id;
                var station = this.GetOne(id);
                station.StationName = newStation.StationName;
                station.StationCity = newStation.StationCity;
                station.StationPhone = newStation.StationPhone;
                station.StationAddress = newStation.StationAddress;
                station.StationPostCode = newStation.StationPostCode;
                this.Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Mehtod to Update all the properties for a station instance.
        /// </summary>
        /// <param name="id">The id of the selected station.</param>
        /// <param name="newStation">The selected station to update.</param>
        public void UpdateStation(int id, Station newStation)
        {
            if (newStation != null)
            {
                int myId = id;
                var station = this.GetOne(id);
                station.StationName = newStation.StationName;
                station.StationCity = newStation.StationCity;
                station.StationPhone = newStation.StationPhone;
                station.StationAddress = newStation.StationAddress;
                station.StationPostCode = newStation.StationPostCode;
                this.Context.SaveChanges();
            }
        }
    }
}
