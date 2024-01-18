// <copyright file="StationModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.Data
{
    using System.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// StationModel class, which inherits from the ObservablObjest.
    /// </summary>
    public class StationModel : ObservableObject
    {
        /// <summary>
        /// Variable that will store the Station Id.
        /// </summary>
        private int stationId;

        /// <summary>
        /// Variable that will store the Station Name.
        /// </summary>
        private string stationName;

        /// <summary>
        /// Variable that will store the Station City.
        /// </summary>
        private string stationCity;

        /// <summary>
        /// Variable that will store the Station Phone.
        /// </summary>
        private string stationPhone;

        /// <summary>
        /// Variable that will store the Station Address.
        /// </summary>
        private string stationAddress;

        /// <summary>
        /// Variable that will store the Station Postal Code.
        /// </summary>
        private string stationPostCode;

        /// <summary>
        /// Gets or sets stationId variable.
        /// </summary>
        public int StationId { get => this.stationId; set => this.Set(ref this.stationId, value); }

        /// <summary>
        /// Gets or sets stationName variable.
        /// </summary>
        public string StationName { get => this.stationName; set => this.Set(ref this.stationName, value); }

        /// <summary>
        /// Gets or sets stationCity variable.
        /// </summary>
        public string StationCity { get => this.stationCity; set => this.Set(ref this.stationCity, value); }

        /// <summary>
        /// Gets or sets stationPhone variable.
        /// </summary>
        public string StationPhone { get => this.stationPhone; set => this.Set(ref this.stationPhone, value); }

        /// <summary>
        /// Gets or sets stationAddress variable.
        /// </summary>
        public string StationAddress { get => this.stationAddress; set => this.Set(ref this.stationAddress, value); }

        /// <summary>
        /// Gets or sets stationPostCode.
        /// </summary>
        public string StationPostCode { get => this.stationPostCode; set => this.Set(ref this.stationPostCode, value); }

        /// <summary>
        /// CopyFrom method to copy one StationModel instance into a different one.
        /// </summary>
        /// <param name="other">The stationModel instance to copy from.</param>
        public void CopyFrom(StationModel other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
