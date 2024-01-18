// <copyright file="StationsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PoliceApp.Logic.ILogics;
    using PoliceApp.WEB.Models;

    /// <summary>
    /// StationController class.
    /// </summary>
    public class StationsController : Controller
    {
        /// <summary>
        /// IPoliceLogic instance.
        /// </summary>
        private IPoliceChiefLogic logic;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// StationListViewModel instance.
        /// </summary>
        private StationListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsController"/> class.
        /// StationController constructor that incializes all the necessary variables.
        /// </summary>
        /// <param name="logic">IPoliceChiefLogic instance.</param>
        /// <param name="mapper">IMapper instance.</param>
        public StationsController(IPoliceChiefLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new StationListViewModel();
            this.vm.EditedStation = new Models.Station();

            IList<Data.Station> stations = logic.GetStations();
            this.vm.ListOfStations = mapper.Map<IList<Data.Station>, List<Models.Station>>(stations);
        }

        private Models.Station GetStationModel(int id)
        {
            Data.Station oneStation = this.logic.GetStation(id);
            return this.mapper.Map<Data.Station, Models.Station>(oneStation);
        }

        /// <summary>
        /// Index method used to show the main webpage.
        /// </summary>
        /// <returns>IActionResult instance.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("StationsIndex", this.vm);
        }

        /// <summary>
        /// Details method that shows the chosen station details.
        /// </summary>
        /// <param name="id">The id of the chosen station.</param>
        /// <returns>IActionResult instance.</returns>
        public IActionResult Details(int id)
        {
            return this.View("StationDetails", this.GetStationModel(id));
        }

        /// <summary>
        /// Remove method that removes the chosen station.
        /// </summary>
        /// <param name="id">The id of the chosen station.</param>
        /// <returns>IActionResult instance.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editedResult"] = "Delete FAIL";
            if (this.logic.RemoveOneStation(id))
            {
                this.TempData["editedResult"] = "Delete OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edit method used to edit a chosen station.
        /// </summary>
        /// <param name="id">Id of the chosen station.</param>
        /// <returns>IActionResult instance.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedStation = this.GetStationModel(id);
            return this.View("StationsIndex", this.vm);
        }

        /// <summary>
        /// Edit method used to implement the edition of a chosen station.
        /// </summary>
        /// <param name="station">The chosen station model.</param>
        /// <param name="editAction">The chosen operation of the editAction.</param>
        /// <returns>IActionResult instance.</returns>
        [HttpPost]
        public IActionResult Edit(Models.Station station, string editAction)
        {
            if (this.ModelState.IsValid && station != null)
            {
                this.TempData["editResult"] = "Edit FAIL";
                if (editAction == "AddNew")
                {
                    try
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
                        this.TempData["editResult"] = "Edit OK";
                    }
                    catch (ArgumentException)
                    {
                    }
                }
                else
                {
                    Data.Station updateStation = new Data.Station()
                    {
                        StationName = station.StationName,
                        StationCity = station.StationCity,
                        StationPhone = station.StationPhone,
                        StationAddress = station.StationAddress,
                        StationPostCode = station.StationPostCode,
                    };
                    if (this.logic.UpdateOneStation(station.StationId, updateStation))
                    {
                        this.TempData["editResult"] = "Edit OK";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedStation = station;
                return this.View("StationsIndex", this.vm);
            }
        }
    }
}