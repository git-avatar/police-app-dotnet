// <copyright file="MainMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Program.MenuItems
{
    using System;

    /// <summary>
    /// MainMenu class.
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// MainMenu method, used to implement all the seperate table menus.
        /// </summary>
        public void MainMenuFunction()
        {
            PoliceChiefMenu policeChiefMenu = new PoliceChiefMenu();
            PoliceOfficerMenu policeOfficerMenu = new PoliceOfficerMenu();
            PoliceReporterMenu policeReporterMenu = new PoliceReporterMenu();
            Console.WriteLine("1) Police Chief privilage ");
            Console.WriteLine("2) Police Officer privilage ");
            Console.WriteLine("3) Police Reporter privilage ");
            Console.WriteLine("4) Exit ");
            Console.Write("Please chose a privilage you wish to work with: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    policeChiefMenu.PoliceChiefMenuFunction();
                    break;
                case "2":
                    Console.Clear();
                    policeOfficerMenu.PoliceOfficerMenuFunction();
                    break;
                case "3":
                    Console.Clear();
                    policeReporterMenu.PoliceReporterMenuFunction();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please chose a viable option.");
                    this.MainMenuFunction();
                    break;
            }
        }
    }
}
