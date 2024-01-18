// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// MainVM class that holds all the commands and the relevant collections.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private IMainLogic logic;
        private StationVM selectedStation;
        private ObservableCollection<StationVM> allStations;

        /// <summary>
        /// Gets or sets selectedStation.
        /// </summary>
        public StationVM SelectedStation
        {
            get { return this.selectedStation; }
            set { this.Set(ref this.selectedStation, value); }
        }

        /// <summary>
        /// Gets or sets allStations.
        /// </summary>
        public ObservableCollection<StationVM> AllStations
        {
            get { return this.allStations; }
            set { this.Set(ref this.allStations, value); }
        }

        /// <summary>
        /// Gets or sets editorFunc.
        /// </summary>
        public Func<StationVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets addCmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets delCmd.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets modCmd.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets loadCmd.
        /// </summary>
        public ICommand LoadCmd { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="mainLogic">IMainLogic interface parameter.</param>
        public MainVM(IMainLogic mainLogic)
        {
            this.logic = mainLogic;
            this.LoadCmd = new RelayCommand(() => this.AllStations = new ObservableCollection<StationVM>(this.logic.ApiGetStations()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelStations(this.selectedStation));
            this.AddCmd = new RelayCommand(() => this.logic.EditStation(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditStation(this.selectedStation, this.EditorFunc));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogic>())
        {
        }
    }
}
