// <copyright file="StationsApiController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PoliceApp.Logic.ILogics;

    /// <summary>
    /// StationsApiController used for the WPFClient side.
    /// </summary>
    public class StationsApiController : Controller
    {
        /// <summary>
        /// IPoliceChiefLogic interface used for the logic methods.
        /// </summary>
        private IPoliceChiefLogic logic;

        /// <summary>
        /// IMapper interface used to map data types to model types.
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsApiController"/> class.
        /// </summary>
        /// <param name="logic">IPoliceChiefLogic interface.</param>
        /// <param name="mapper">IMapper interface.</param>
        public StationsApiController(IPoliceChiefLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// GetAllStations method used to return stations.
        /// </summary>
        /// <returns>IEnumerable list of model stations.</returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Station> GetAllStations()
        {
            var stations = this.logic.GetStations();
            return this.mapper.Map<IList<Data.Station>, List<Models.Station>>(stations);
        }

        /// <summary>
        /// DeleteOneStation method used to delete one station.
        /// </summary>
        /// <param name="id">The id of the station to be deleted.</param>
        /// <returns>ApiResult indicating wether the deletion was successful.</returns>
        [HttpGet]
        [ActionName("delete")]
        public ApiResult DeleteOneStation(int id)
        {
            return new ApiResult() { OperationResult = this.logic.RemoveOneStation(id) };
        }

        /// <summary>
        /// AddOneStation method used to add a station.
        /// </summary>
        /// <param name="station">The model station to be added.</param>
        /// <returns>ApiResult indicating if the addition was successful.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneStation(Models.Station station)
        {
            Data.Station addStation = new Data.Station()
            {
                StationName = station.StationName,
                StationCity = station.StationCity,
                StationPhone = station.StationPhone,
                StationAddress = station.StationAddress,
                StationPostCode = station.StationPostCode,
            };
            this.logic.AddStation(addStation);
            return new ApiResult() { OperationResult = true };
        }

        /// <summary>
        /// ModifyOneStation method used to modify a selected station.
        /// </summary>
        /// <param name="station">The model station to be edited.</param>
        /// <returns>ApiResult that signifies if the modification was successful.</returns>
        [HttpPost]
        [ActionName("modify")]
        public ApiResult ModifyOneStation(Models.Station station)
        {
            Data.Station modStation = new Data.Station()
            {
                StationName = station.StationName,
                StationCity = station.StationCity,
                StationPhone = station.StationPhone,
                StationAddress = station.StationAddress,
                StationPostCode = station.StationPostCode,
            };
            return new ApiResult() { OperationResult = this.logic.UpdateOneStation(station.StationId, modStation) };
        }
    }
}
