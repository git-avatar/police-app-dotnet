// <copyright file="StationPoliceCount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.NonCRUD
{
    /// <summary>
    /// StationPoliceCount class, used for Non-CRUD functionality.
    /// </summary>
    public class StationPoliceCount
    {
        /// <summary>
        /// Gets or sets satationName property.
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets officerCount property.
        /// </summary>
        public int OfficerCount { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>String containing the StationName and the OfficerCount.</returns>
        public override string ToString()
        {
            return $"Station name: {this.StationName}, Officer count: {this.OfficerCount}";
        }

        /// <summary>
        /// Equals method used to check if two objects are equal.
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>True or False depending if the objects are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is StationPoliceCount)
            {
                StationPoliceCount stationPoliceCount = obj as StationPoliceCount;
                return this.StationName == stationPoliceCount.StationName &&
                    this.OfficerCount == stationPoliceCount.OfficerCount;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// GetHashCode method.
        /// </summary>
        /// <returns>Integer value that can be used for hash calculations.</returns>
        public override int GetHashCode()
        {
            return this.StationName.GetHashCode() + this.OfficerCount;
        }
    }
}
