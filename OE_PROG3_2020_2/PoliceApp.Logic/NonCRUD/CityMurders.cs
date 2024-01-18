// <copyright file="CityMurders.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.NonCRUD
{
    /// <summary>
    /// CityMurders class to deal with Non-CRUD functionality.
    /// </summary>
    public class CityMurders
    {
        /// <summary>
        /// Gets or sets cityName property.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets crimeType property.
        /// </summary>
        public int MurderCount { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>String containing the city name and the most common crime type occuring there.</returns>
        public override string ToString()
        {
            return $"City: {this.CityName}, Murder count: {this.MurderCount}";
        }

        /// <summary>
        /// Equals method used to check if two objects are equal.
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>True or False depending if the objects are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CityMurders)
            {
                CityMurders cityCommonCrime = obj as CityMurders;
                return this.CityName == cityCommonCrime.CityName &&
                    this.MurderCount == cityCommonCrime.MurderCount;
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
            return this.CityName.GetHashCode() + this.MurderCount;
        }
    }
}
