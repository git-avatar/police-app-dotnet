// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Models
{
    using System;

    /// <summary>
    /// ErrorViewModel class.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets requestId property.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether showRequestId method.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
