// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.VM
{
    using GalaSoft.MvvmLight;
    using PoliceApp.WPF.Data;

    /// <summary>
    /// EditorViewModel class that is responsible for the EditorWindow model.
    /// </summary>
    internal class EditorViewModel : ViewModelBase
    {
        /// <summary>
        /// Station varible that needs to be edited.
        /// </summary>
        private StationModel station;

        /// <summary>
        /// Gets or sets station.
        /// </summary>
        public StationModel Station { get => this.station; set => this.Set(ref this.station, value); }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// EditorViewModel constructor resposible for editing values.
        /// </summary>
        public EditorViewModel()
        {
            this.station = new StationModel();
            if (this.IsInDesignMode)
            {
                this.station.StationName = "DefaultName";
                this.station.StationCity = "DefaultCity";
                this.station.StationPhone = "0000-0000";
                this.station.StationAddress = "DefaultAddress";
                this.station.StationPostCode = "00000";
            }
        }
    }
}
