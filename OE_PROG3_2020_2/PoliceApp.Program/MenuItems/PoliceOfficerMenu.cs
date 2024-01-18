// <copyright file="PoliceOfficerMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Program.MenuItems
{
    using System;
    using PoliceApp.Data;
    using PoliceApp.Logic.Logics;
    using PoliceApp.Repository.Repositories;

    /// <summary>
    /// PoliceOfficerMenu class.
    /// </summary>
    public class PoliceOfficerMenu
    {
        private static readonly PoliceAppDbContext Context = new PoliceAppDbContext();
        private static readonly StationRepository StationRepository = new StationRepository(Context);
        private static readonly PoliceRepository PoliceRepository = new PoliceRepository(Context);
        private static readonly CriminalRepository CriminalRepository = new CriminalRepository(Context);
        private static readonly CrimeRepository CrimeRepository = new CrimeRepository(Context);
        private static readonly PoliceOfficerLogic PoliceOfficerLogic = new PoliceOfficerLogic(StationRepository, PoliceRepository, CriminalRepository, CrimeRepository);

        /// <summary>
        /// PoliceOfficerMenuFunction method to implement the logic on the corresponding database.
        /// </summary>
        public void PoliceOfficerMenuFunction()
        {
            Console.WriteLine("You are now logged in as a Police Officer.");
            Console.WriteLine("1) Station table ");
            Console.WriteLine("2) Police table ");
            Console.WriteLine("3) Criminal table ");
            Console.WriteLine("4) Crime table ");
            Console.WriteLine("5) Officer arrest count ");
            Console.WriteLine("6) Officer arrest count(Task) ");
            Console.WriteLine("7) Exit ");
            Console.Write("Please chose a table you wish to work with: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    this.StationMenuFunction();
                    break;
                case "2":
                    Console.Clear();
                    this.PoliceMenuFunction();
                    break;
                case "3":
                    Console.Clear();
                    this.CriminalMenuFunction();
                    break;
                case "4":
                    Console.Clear();
                    this.CrimeMenuFunction();
                    break;
                case "5":
                    Console.Clear();
                    this.NonCRUDMenuFunction();
                    break;
                case "6":
                    Console.Clear();
                    this.TaskNonCRUDMenuFunction();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please chose a viable option.");
                    this.PoliceOfficerMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// StationMenu method to implement the logic on the corresponding database.
        /// </summary>
        public void StationMenuFunction()
        {
            Console.WriteLine("1) Read all recodrs: ");
            Console.WriteLine("2) Read one recodrs: ");
            Console.WriteLine("3) Update record: ");
            Console.WriteLine("4) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceOfficerLogic.GetStations())
                    {
                        Console.WriteLine(
                            $"Station Id: {getAllRecord.StationId} \n" +
                            $"Station name: {getAllRecord.StationName} \n" +
                            $"Station city: {getAllRecord.StationCity} \n" +
                            $"Station phone: {getAllRecord.StationPhone} \n" +
                            $"Station address: {getAllRecord.StationAddress} \n" +
                            $"Station postal-code: {getAllRecord.StationPostCode} \n");
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceOfficerLogic.GetStation(id);
                    Console.WriteLine(
                            $"Station Id: {getRecord.StationId} \n" +
                            $"Station name: {getRecord.StationName} \n" +
                            $"Station city: {getRecord.StationCity} \n" +
                            $"Station phone: {getRecord.StationPhone} \n" +
                            $"Station address: {getRecord.StationAddress} \n" +
                            $"Station postal-code: {getRecord.StationPostCode} \n");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Station updateStation = PoliceOfficerLogic.GetStation(updateId);
                    Console.Clear();
                    Console.WriteLine(
                            $"Station Id: {updateStation.StationId} \n" +
                            $"Station name: {updateStation.StationName} \n" +
                            $"Station city: {updateStation.StationCity} \n" +
                            $"Station phone: {updateStation.StationPhone} \n" +
                            $"Station address: {updateStation.StationAddress} \n" +
                            $"Station postal-code: {updateStation.StationPostCode} \n");
                    Console.Write("Please enter the desired new name: ");
                    string updateName = Console.ReadLine();
                    PoliceOfficerLogic.UpdateStationName(updateId, updateName);
                    Console.WriteLine("Station updated succesfully!");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    this.PoliceOfficerMenuFunction();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Chose a viable option!");
                    this.StationMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// PoliceMenu method to implement the logic on the corresponding database.
        /// </summary>
        public void PoliceMenuFunction()
        {
            Console.WriteLine("1) Read all recodrs: ");
            Console.WriteLine("2) Read one recodrs: ");
            Console.WriteLine("3) Update record: ");
            Console.WriteLine("4) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceOfficerLogic.GetPolices())
                    {
                        Console.WriteLine(
                            $"Police Id: {getAllRecord.PoliceId} \n" +
                            $"Police name: {getAllRecord.PoliceName} \n" +
                            $"Police phone: {getAllRecord.PolicePhone} \n" +
                            $"Police city: {getAllRecord.PoliceCity} \n" +
                            $"Police address: {getAllRecord.PoliceAddress} \n" +
                            $"Police Dob: {getAllRecord.PoliceDOB} \n" +
                            $"Police station Id: {getAllRecord.StationId} \n");
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceOfficerLogic.GetPolice(id);
                    Console.WriteLine(
                            $"Police Id: {getRecord.PoliceId} \n" +
                            $"Police name: {getRecord.PoliceName} \n" +
                            $"Police phone: {getRecord.PolicePhone} \n" +
                            $"Police city: {getRecord.PoliceCity} \n" +
                            $"Police address: {getRecord.PoliceAddress} \n" +
                            $"Police Dob: {getRecord.PoliceDOB} \n" +
                            $"Police station Id: {getRecord.StationId}");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Police updatePolice = PoliceOfficerLogic.GetPolice(updateId);
                    Console.Clear();
                    Console.WriteLine(
                            $"Police Id: {updatePolice.PoliceId} \n" +
                            $"Police name: {updatePolice.PoliceName} \n" +
                            $"Police phone: {updatePolice.PolicePhone} \n" +
                            $"Police city: {updatePolice.PoliceCity} \n" +
                            $"Police address: {updatePolice.PoliceAddress} \n" +
                            $"Police Dob: {updatePolice.PoliceDOB} \n" +
                            $"Police station Id: {updatePolice.StationId}");
                    Console.Write("Please enter the desired new city: ");
                    string updateCity = Console.ReadLine();
                    PoliceOfficerLogic.UpdateCity(updateId, updateCity);
                    Console.WriteLine("Police updated succesfully!");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    this.PoliceOfficerMenuFunction();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Chose a viable option!");
                    this.PoliceMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// CriminalMenu method to implement the logic on the corresponding database.
        /// </summary>
        public void CriminalMenuFunction()
        {
            Console.WriteLine("1) Read all recodrs: ");
            Console.WriteLine("2) Read one recodrs: ");
            Console.WriteLine("3) Update record: ");
            Console.WriteLine("4) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceOfficerLogic.GetCriminals())
                    {
                        Console.WriteLine(
                            $"Criminal Id: {getAllRecord.CriminalId} \n" +
                            $"Criminal name: {getAllRecord.CriminalName} \n" +
                            $"Criminal phone: {getAllRecord.CriminalPhone} \n" +
                            $"Criminal city: {getAllRecord.CriminalCity} \n" +
                            $"Criminal address: {getAllRecord.CriminalAddress} \n" +
                            $"Criminal Dob: {getAllRecord.CriminalDOB} \n");
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceOfficerLogic.GetCriminal(id);
                    Console.WriteLine(
                            $"Criminal Id: {getRecord.CriminalId} \n" +
                            $"Criminal name: {getRecord.CriminalName} \n" +
                            $"Criminal phone: {getRecord.CriminalPhone} \n" +
                            $"Criminal city: {getRecord.CriminalCity} \n" +
                            $"Criminal address: {getRecord.CriminalAddress} \n" +
                            $"Criminal Dob: {getRecord.CriminalDOB} \n");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Criminal updateCriminal = PoliceOfficerLogic.GetCriminal(updateId);
                    Console.Clear();
                    Console.WriteLine(
                            $"Criminal Id: {updateCriminal.CriminalId} \n" +
                            $"Criminal name: {updateCriminal.CriminalName} \n" +
                            $"Criminal phone: {updateCriminal.CriminalPhone} \n" +
                            $"Criminal city: {updateCriminal.CriminalCity} \n" +
                            $"Criminal address: {updateCriminal.CriminalAddress} \n" +
                            $"Criminal Dob: {updateCriminal.CriminalDOB}");
                    Console.Write("Please enter the desired new name: ");
                    string updateName = Console.ReadLine();
                    PoliceOfficerLogic.UpdateCriminalName(updateId, updateName);
                    Console.WriteLine("Criminal updated succesfully!");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    this.PoliceOfficerMenuFunction();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Chose a viable option!");
                    this.CriminalMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// CrimeMenu method to implement the logic on the corresponding database.
        /// </summary>
        public void CrimeMenuFunction()
        {
            Console.WriteLine("1) Read all recodrs: ");
            Console.WriteLine("2) Read one recodrs: ");
            Console.WriteLine("3) Update record: ");
            Console.WriteLine("4) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceOfficerLogic.GetCrimes())
                    {
                        Console.WriteLine(
                            $"Crime Id: {getAllRecord.CrimeId} \n" +
                            $"Crime type: {getAllRecord.CrimeType} \n" +
                            $"Crime date: {getAllRecord.CrimeDate} \n" +
                            $"Crime police Id: {getAllRecord.PoliceId} \n" +
                            $"Crime criminal Id: {getAllRecord.CriminalId} \n");
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("What is the desired Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceOfficerLogic.GetCrime(id);
                    Console.WriteLine(
                            $"Crime Id: {getRecord.CrimeId} \n" +
                            $"Crime type: {getRecord.CrimeType} \n" +
                            $"Crime date: {getRecord.CrimeDate} \n" +
                            $"Crime police Id: {getRecord.PoliceId} \n" +
                            $"Crime criminal Id: {getRecord.CriminalId} \n");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Crime updateCrime = PoliceOfficerLogic.GetCrime(updateId);
                    Console.Clear();
                    Console.WriteLine(
                            $"Crime Id: {updateCrime.CrimeId} \n" +
                            $"Crime type: {updateCrime.CrimeType} \n" +
                            $"Crime date: {updateCrime.CrimeDate} \n" +
                            $"Crime police Id: {updateCrime.PoliceId} \n" +
                            $"Crime criminal Id: {updateCrime.CriminalId} \n");
                    Console.Write("Please enter the desired new type: ");
                    string updateType = Console.ReadLine();
                    PoliceOfficerLogic.UpdateType(updateId, updateType);
                    Console.WriteLine("Crime updated succesfully!");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    this.PoliceOfficerMenuFunction();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Chose a viable option!");
                    this.CrimeMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// NonCRUDMenuFunction to display the Non-CRUD functionality.
        /// </summary>
        public void NonCRUDMenuFunction()
        {
            foreach (var officer in PoliceOfficerLogic.OfficerArrests())
            {
                Console.WriteLine(officer + "\n");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// TaskNonCRUDMenuFunction to display the Non-CRUD functionality, working as a task.
        /// </summary>
        public void TaskNonCRUDMenuFunction()
        {
            var nonCRUDTask = PoliceOfficerLogic.OfficerArrestsAsync();
            nonCRUDTask.Wait();
            foreach (var officer in nonCRUDTask.Result)
            {
                Console.WriteLine(officer + "\n");
            }

            Console.ReadLine();
        }
    }
}
