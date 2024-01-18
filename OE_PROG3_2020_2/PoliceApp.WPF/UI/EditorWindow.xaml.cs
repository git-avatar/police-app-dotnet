// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.UI
{
    using System.Windows;
    using PoliceApp.WPF.Data;
    using PoliceApp.WPF.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        /// <summary>
        /// EditorViewModel reference used to edit a station.
        /// </summary>
        private readonly EditorViewModel VM;

        /// <summary>
        /// Gets external Station property used to give back the station.
        /// </summary>
        public StationModel Station { get => this.VM.Station; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// EditorWindow zero-parameter constructor used to set the EditorViewModel VM datafield.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();
            this.VM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// EditorWindow one-parameter constructor responsible for adding the capability of editing an older staiton.
        /// </summary>
        /// <param name="oldStation">Station instance to be edited.</param>
        public EditorWindow(StationModel oldStation)
            : this()
        {
            this.VM.Station = oldStation;
        }

        /// <summary>
        /// OkClick, which is resposible for setting the DialogResult to true.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event argument.</param>
        private void OKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// CancelClick, which is resposible for setting the DialogResult to false.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event argument.</param>
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
