// <copyright file="OfficerArrests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.NonCRUD
{
    /// <summary>
    /// OfficerArrests class, used for Non-CRUD functionality.
    /// </summary>
    public class OfficerArrests
    {
        /// <summary>
        /// Gets or sets officerName property.
        /// </summary>
        public string OfficerName { get; set; }

        /// <summary>
        /// Gets or sets arrestCount property.
        /// </summary>
        public int ArrestCount { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>String containing the OfficerName and the ArrestCount.</returns>
        public override string ToString()
        {
            return $"Officer name: {this.OfficerName}, Arrest count: {this.ArrestCount}";
        }

        /// <summary>
        /// Equals method used to check if two objects are equal.
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>True or False depending if the objects are the same or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is OfficerArrests)
            {
                OfficerArrests officerArrests = obj as OfficerArrests;
                return this.OfficerName == officerArrests.OfficerName &&
                    this.ArrestCount == officerArrests.ArrestCount;
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
            return this.OfficerName.GetHashCode() + this.ArrestCount;
        }
    }
}
