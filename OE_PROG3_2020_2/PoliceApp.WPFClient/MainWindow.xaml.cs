﻿// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, "StationResult", msg =>
            {
                (this.DataContext as MainVM).LoadCmd.Execute(null);
                MessageBox.Show(msg);
            });

            (this.DataContext as MainVM).EditorFunc = (car) =>
            {
                EditorWindow win = new EditorWindow(car);
                return win.ShowDialog() == true;
            };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
