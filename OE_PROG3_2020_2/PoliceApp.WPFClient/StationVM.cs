// <copyright file="StationVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// StationVM class used to represent a station.
    /// </summary>
    public class StationVM : ObservableObject
    {
        private int stationId;
        private string stationName;
        private string stationCity;
        private string stationPhone;
        private string stationAddress;
        private string stationPostCode;

        /// <summary>
        /// Gets or sets stationId.
        /// </summary>
        public int StationId
        {
            get { return this.stationId; }
            set { this.Set(ref this.stationId, value); }
        }

        /// <summary>
        /// Gets or sets stationName.
        /// </summary>
        public string StationName
        {
            get { return this.stationName; }
            set { this.Set(ref this.stationName, value); }
        }

        /// <summary>
        /// Gets or sets stationCity.
        /// </summary>
        public string StationCity
        {
            get { return this.stationCity; }
            set { this.Set(ref this.stationCity, value); }
        }

        /// <summary>
        /// Gets or sets stationPhone.
        /// </summary>
        public string StationPhone
        {
            get { return this.stationPhone; }
            set { this.Set(ref this.stationPhone, value); }
        }

        /// <summary>
        /// Gets or sets stationAddress.
        /// </summary>
        public string StationAddress
        {
            get { return this.stationAddress; }
            set { this.Set(ref this.stationAddress, value); }
        }

        /// <summary>
        /// Gets or sets stationPostCode.
        /// </summary>
        public string StationPostCode
        {
            get { return this.stationPostCode; }
            set { this.Set(ref this.stationPostCode, value); }
        }

        /// <summary>
        /// CopyFrom method that copies the content of one StationVM into another.
        /// </summary>
        /// <param name="other">StationVM to copy from.</param>
        public void CopyFrom(StationVM other)
        {
            if (other == null)
            {
                return;
            }

            this.StationId = other.StationId;
            this.StationName = other.StationName;
            this.StationCity = other.StationCity;
            this.StationPhone = other.StationPhone;
            this.StationAddress = other.StationAddress;
            this.StationPostCode = other.StationPostCode;
        }
    }
}
