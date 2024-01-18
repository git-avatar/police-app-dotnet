// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// MainLogic class used to handle the logic.
    /// </summary>
    public class MainLogic : IMainLogic
    {
        private string url = "http://localhost:60818/StationsApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// IEdiorService interface.
        /// </summary>
        private IEditorService editorService;

        /// <summary>
        /// IMessenger interface.
        /// </summary>
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// </summary>
        /// <param name="editorService">IEditorService interface parameter.</param>
        /// <param name="messengerService">IMessenger interface parameter.</param>
        public MainLogic(IEditorService editorService, IMessenger messengerService)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
        }

        /// <summary>
        /// SendMessage method that sends a message if a given operation is successfull or not.
        /// </summary>
        /// <param name="success">Success parameter that will signal if the operation is successfull or not.</param>
        public void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "StationResult");
        }

        /// <summary>
        /// ApiGetStations method that returns a list of all the stations.
        /// </summary>
        /// <returns>List of StationVM instances.</returns>
        public List<StationVM> ApiGetStations()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<StationVM>>(json, this.jsonOptions);
            return list;
        }

        /// <summary>
        /// ApiDelStation method that deletes a given station.
        /// </summary>
        /// <param name="station">The StationVM to be deleted.</param>
        public void ApiDelStations(StationVM station)
        {
            bool success = false;
            if (station != null)
            {
                string json = this.client.GetStringAsync(this.url + "delete/" + station.StationId.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <summary>
        /// ApiEditStation used to edit or add a station.
        /// </summary>
        /// <param name="station">The station to edit/add.</param>
        /// <param name="isEditing">Declares if we are adding or editing.</param>
        /// <returns>Bool variable to signale if the edit was ok.</returns>
        public bool ApiEditStation(StationVM station, bool isEditing)
        {
            if (station == null)
            {
                return false;
            }

            string myUrl = isEditing ? this.url + "modify" : this.url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("stationId", station.StationId.ToString());
            }

            postData.Add("stationName", station.StationName);
            postData.Add("stationCity", station.StationCity);
            postData.Add("stationPhone", station.StationPhone);
            postData.Add("stationAddress", station.StationAddress);
            postData.Add("stationPostCode", station.StationPostCode);
            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).
                Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }

        /// <summary>
        /// EditStation method used to edit/add a station.
        /// </summary>
        /// <param name="station">The station to be edited.</param>
        /// <param name="editor">Func editor.</param>
        public void EditStation(StationVM station, Func<StationVM, bool> editor)
        {
            StationVM clone = new StationVM();
            if (station != null)
            {
                clone.CopyFrom(station);
            }

            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (station != null)
                {
                    success = this.ApiEditStation(clone, true);
                }
                else
                {
                    success = this.ApiEditStation(clone, false);
                }
            }

            this.SendMessage(success == true);
        }
    }
}
