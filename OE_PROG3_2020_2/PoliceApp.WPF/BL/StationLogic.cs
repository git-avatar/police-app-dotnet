// <copyright file="StationLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.BL
{
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Messaging;
    using PoliceApp.Data;
    using PoliceApp.Logic.Logics;
    using PoliceApp.WPF.Data;

    /// <summary>
    /// StationLogic resposible for implelenting all the CRUD methods in the application.
    /// </summary>
    internal class StationLogic : IStationLogic
    {
        /// <summary>
        /// Creates a PoliceChiefLogic enitity that is resposible for logic operations.
        /// </summary>
        private static readonly PoliceChiefLogic PoliceChiefLogic = new PoliceChiefLogic();

        /// <summary>
        /// IEditorService responsible for editing of a station using a window.
        /// </summary>
        private IEditorService editorService;

        /// <summary>
        /// IMessenger responsible for informing of a successfull or unsuccessfull operation.
        /// </summary>
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationLogic"/> class.
        /// StationLogic constructor resposible for setting the IEditorService and the IMessenger interfaces.
        /// </summary>
        /// <param name="editorService">EditorService interface.</param>
        /// <param name="messengerService">MessengerService interface.</param>
        public StationLogic(IEditorService editorService, IMessenger messengerService)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
        }

        /// <summary>
        /// GetStations method resposible.
        /// </summary>
        /// <param name="stations">List of stations to be displayed.</param>
        public void GetStations(IList<StationModel> stations)
        {
            if (stations != null)
            {
                stations.Clear();
                IList<StationModel> modelStations = EntityToModelConverter(PoliceChiefLogic.GetStations());
                foreach (StationModel station in modelStations)
                {
                    stations.Add(station);
                }
            }
        }

        /// <summary>
        /// AddStation method ressposible for adding stations to the UI and DB.
        /// </summary>
        /// <param name="stations">List of stations to be added.</param>
        public void AddStation(IList<StationModel> stations)
        {
            if (stations != null)
            {
                StationModel modelStation = new StationModel();
                if (this.editorService.EditStation(modelStation) == true)
                {
                    stations.Add(modelStation);
                    Station entityStation = ModelToEntityConverter(modelStation);
                    PoliceChiefLogic.AddStation(entityStation);
                    this.GetStations(stations);
                    this.messengerService.Send("ADD OK", "LogicResult");
                }
                else
                {
                    this.messengerService.Send("ADD CANCELED", "LogicResult");
                }
            }
        }

        /// <summary>
        /// DelStation method resposible for deleting a station from the UI and from the DB.
        /// </summary>
        /// <param name="stations">List of all the stations in the DB.</param>
        /// <param name="station">Station to be deleted.</param>
        public void DelStation(IList<StationModel> stations, StationModel station)
        {
            if (station == null || !stations.Remove(station))
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
            else
            {
                PoliceChiefLogic.RemoveStation(station.StationId);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
        }

        /// <summary>
        /// ModStation method resposible for modifying(updating) one station in instance.
        /// </summary>
        /// <param name="stationToModify">Station to be modified.</param>
        public void ModStation(StationModel stationToModify)
        {
            if (stationToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            StationModel clone = new StationModel();
            clone.CopyFrom(stationToModify);

            if (this.editorService.EditStation(clone) == true)
            {
                stationToModify.CopyFrom(clone);

                Station entityStation = new Station();
                entityStation.StationId = stationToModify.StationId;
                entityStation.StationName = stationToModify.StationName;
                entityStation.StationCity = stationToModify.StationCity;
                entityStation.StationPhone = stationToModify.StationPhone;
                entityStation.StationAddress = stationToModify.StationAddress;
                entityStation.StationPostCode = stationToModify.StationPostCode;
                PoliceChiefLogic.UpdateStation(stationToModify.StationId, entityStation);
                this.messengerService.Send("EDIT OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// EntityToModelConverter method used to convert entity Stations into StationModels model entities.
        /// </summary>
        /// <param name="entityStations">List of stations to be converted.</param>
        /// <returns>List of StationModel instances.</returns>
        private static IList<StationModel> EntityToModelConverter(IList<Station> entityStations)
        {
            IList<StationModel> stationModels = new List<StationModel>();
            foreach (Station entityStation in entityStations)
            {
                StationModel currentStation = new StationModel();
                currentStation.StationId = entityStation.StationId;
                currentStation.StationName = entityStation.StationName;
                currentStation.StationCity = entityStation.StationCity;
                currentStation.StationPhone = entityStation.StationPhone;
                currentStation.StationAddress = entityStation.StationAddress;
                currentStation.StationPostCode = entityStation.StationPostCode;
                stationModels.Add(currentStation);
            }

            return stationModels;
        }

        /// <summary>
        /// ModelToEntityConverter method used to convert StationModel entites into Station entities.
        /// </summary>
        /// <param name="stationModel">StationModel to be converted.</param>
        /// <returns>Station entity with all the properties of the stationModel parameter.</returns>
        private static Station ModelToEntityConverter(StationModel stationModel)
        {
            Station currentStation = new Station();
            currentStation.StationId = stationModel.StationId;
            currentStation.StationName = stationModel.StationName;
            currentStation.StationCity = stationModel.StationCity;
            currentStation.StationPhone = stationModel.StationPhone;
            currentStation.StationAddress = stationModel.StationAddress;
            currentStation.StationPostCode = stationModel.StationPostCode;
            return currentStation;
        }
    }
}
