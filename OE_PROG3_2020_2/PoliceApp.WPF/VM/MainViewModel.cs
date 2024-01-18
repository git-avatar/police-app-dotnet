// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.VM
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using PoliceApp.WPF.BL;
    using PoliceApp.WPF.Data;

    /// <summary>
    /// MainViewModel class resposible for MainWindow model.
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// stationLogic which is resposible for providing the logic methods.
        /// </summary>
        private IStationLogic stationLogic;

        /// <summary>
        /// selectedStation used to notify which player is currently selected in the MainWindow.
        /// </summary>
        private StationModel selectedStation;

        /// <summary>
        /// Gets or sets selectedStation.
        /// </summary>
        public StationModel SelectedStation { get => this.selectedStation; set => this.Set(ref this.selectedStation, value); }

        /// <summary>
        /// Gets stations which are used to display all the stations in the DB.
        /// </summary>
        public ObservableCollection<StationModel> Stations { get; private set; }

        /// <summary>
        /// Gets getCmd used to get all stations from a list.
        /// </summary>
        public ICommand GetCmd { get; private set; }

        /// <summary>
        /// Gets addCmd used to add a station to the list.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets delCmd used to delete a station from the list.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets modCmd used to modify a station in the list.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// MainViewModel constructor used to set all the private set properties.
        /// </summary>
        /// <param name="stationLogic">StaitonLogic interface used for the CRUD operations.</param>
        public MainViewModel(IStationLogic stationLogic)
        {
            this.stationLogic = stationLogic;
            this.Stations = new ObservableCollection<StationModel>();
            if (this.IsInDesignMode)
            {
                StationModel station2 = new StationModel() { StationName = "SecondStation", StationCity = "SecondCity", StationPhone = "2222-2222", StationAddress = "SecondAddress", StationPostCode = "SecondPostCode" };
                StationModel station3 = new StationModel() { StationName = "ThirdStation", StationCity = "ThirdCity", StationPhone = "3333-3333", StationAddress = "ThirdAddress", StationPostCode = "ThirdPostCode" };
                this.Stations.Add(station2);
                this.Stations.Add(station3);
            }

            this.GetCmd = new RelayCommand(() => this.stationLogic.GetStations(this.Stations));
            this.AddCmd = new RelayCommand(() => this.stationLogic.AddStation(this.Stations));
            this.DelCmd = new RelayCommand(() => this.stationLogic.DelStation(this.Stations, this.SelectedStation));
            this.ModCmd = new RelayCommand(() => this.stationLogic.ModStation(this.SelectedStation));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// MainViewModel which acts as an IoC which creates automatically instances for us to use.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IStationLogic>())
        {
        }
    }
}
