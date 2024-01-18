// <copyright file="MyIoc.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// IOC for the locatior.
    /// </summary>
    public class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets instance of the IOC.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
