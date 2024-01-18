// <copyright file="PoliceChiefMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Program.MenuItems
{
    using System;
    using PoliceApp.Data;
    using PoliceApp.Logic.Logics;
    using PoliceApp.Repository.Repositories;

    /// <summary>
    /// PoliceChiefMenu class.
    /// </summary>
    public class PoliceChiefMenu
    {
        private static readonly PoliceAppDbContext Context = new PoliceAppDbContext();
        private static readonly StationRepository StationRepository = new StationRepository(Context);
        private static readonly PoliceRepository PoliceRepository = new PoliceRepository(Context);
        private static readonly CriminalRepository CriminalRepository = new CriminalRepository(Context);
        private static readonly CrimeRepository CrimeRepository = new CrimeRepository(Context);
        private static readonly PoliceChiefLogic PoliceChiefLogic = new PoliceChiefLogic(StationRepository, PoliceRepository, CriminalRepository, CrimeRepository);

        /// <summary>
        /// PoliceChiefMenuFunction method to implement the logic on the corresponding database.
        /// </summary>
        public void PoliceChiefMenuFunction()
        {
            Console.WriteLine("You are now logged in as a Police Chief.");
            Console.WriteLine("1) Station table ");
            Console.WriteLine("2) Police table ");
            Console.WriteLine("3) Criminal table ");
            Console.WriteLine("4) Crime table ");
            Console.WriteLine("5) Station police count ");
            Console.WriteLine("6) Station police count(Task) ");
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
                    this.PoliceChiefMenuFunction();
                    break;
            }
        }

        /// <summary>
        /// StationMenu method to implement the logic on the corresponding database.
        /// </summary>
        public void StationMenuFunction()
        {
            Console.WriteLine("1) Add new record: ");
            Console.WriteLine("2) Add new records(multiple): ");
            Console.WriteLine("3) Read all recodrs: ");
            Console.WriteLine("4) Read one recodrs: ");
            Console.WriteLine("5) Remove one record: ");
            Console.WriteLine("6) Remove one record(by Id): ");
            Console.WriteLine("7) Remove records(multiple): ");
            Console.WriteLine("8) Update record: ");
            Console.WriteLine("9) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                    Console.Write("Please enter the station name: ");
                    string addStationName = Console.ReadLine();
                    Console.Write("Please enter the station city: ");
                    string addStationCity = Console.ReadLine();
                    Console.Write("Please enter the station phone: ");
                    string addStationPhone = Console.ReadLine();
                    Console.Write("Please enter the station address: ");
                    string addStationAddress = Console.ReadLine();
                    Console.Write("Please enter the station postal-code: ");
                    string addStationPostalCode = Console.ReadLine();
                    Station addStation = new Station()
                    {
                        StationName = addStationName,
                        StationCity = addStationCity,
                        StationPhone = addStationPhone,
                        StationAddress = addStationAddress,
                        StationPostCode = addStationPostalCode,
                    };
                    PoliceChiefLogic.AddStation(addStation);
                    Console.WriteLine("Station succesfully added!");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("How many records do you wish to add: ");
                    int numAdd = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numAdd; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                        Console.Write("Please enter the station name: ");
                        string addRangeStationName = Console.ReadLine();
                        Console.Write("Please enter the station city: ");
                        string addRangeStationCity = Console.ReadLine();
                        Console.Write("Please enter the station phone: ");
                        string addRangeStationPhone = Console.ReadLine();
                        Console.Write("Please enter the station address: ");
                        string addRangeStationAddress = Console.ReadLine();
                        Console.Write("Please enter the station postal-code: ");
                        string addRangeStationPostalCode = Console.ReadLine();
                        Station addRangeStation = new Station()
                        {
                            StationName = addRangeStationName,
                            StationCity = addRangeStationCity,
                            StationPhone = addRangeStationPhone,
                            StationAddress = addRangeStationAddress,
                            StationPostCode = addRangeStationPostalCode,
                        };
                        PoliceChiefLogic.AddStation(addRangeStation);
                        Console.WriteLine("Station succesfully added!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceChiefLogic.GetStations())
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
                case "4":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceChiefLogic.GetStation(id);
                    Console.WriteLine(
                            $"Station Id: {getRecord.StationId} \n" +
                            $"Station name: {getRecord.StationName} \n" +
                            $"Station city: {getRecord.StationCity} \n" +
                            $"Station phone: {getRecord.StationPhone} \n" +
                            $"Station address: {getRecord.StationAddress} \n" +
                            $"Station postal-code: {getRecord.StationPostCode} \n");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    var removeRecord = PoliceChiefLogic.GetStation(removeId);
                    PoliceChiefLogic.RemoveStation(removeRecord);
                    Console.WriteLine("Station deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeById = Convert.ToInt32(Console.ReadLine());
                    PoliceChiefLogic.RemoveStation(removeById);
                    Console.WriteLine("Station deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("How many records do you wish to delete: ");
                    int numDelete = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numDelete; i++)
                    {
                        Console.Clear();
                        Console.Write("Please enter the Id of the record you want to delete: ");
                        int removeRangeById = Convert.ToInt32(Console.ReadLine());
                        PoliceChiefLogic.RemoveStation(removeRangeById);
                        Console.WriteLine("Station deleted succesfully!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Station updateStation = PoliceChiefLogic.GetStation(updateId);
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
                    PoliceChiefLogic.UpdateStationName(updateId, updateName);
                    Console.WriteLine("Station updated succesfully!");
                    Console.ReadLine();
                    break;
                case "9":
                    Console.Clear();
                    this.PoliceChiefMenuFunction();
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
            Console.WriteLine("1) Add new record: ");
            Console.WriteLine("2) Add new records(multiple): ");
            Console.WriteLine("3) Read all recodrs: ");
            Console.WriteLine("4) Read one recodrs: ");
            Console.WriteLine("5) Remove one record: ");
            Console.WriteLine("6) Remove one record(by Id): ");
            Console.WriteLine("7) Remove records(multiple): ");
            Console.WriteLine("8) Update record: ");
            Console.WriteLine("9) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                    Console.Write("Please enter police name: ");
                    string addPoliceName = Console.ReadLine();
                    Console.Write("Please enter police phone: ");
                    string addPolicePhone = Console.ReadLine();
                    Console.Write("Please eneter police city: ");
                    string addPoliceCity = Console.ReadLine();
                    Console.Write("Please enter police address: ");
                    string addPoliceAddress = Console.ReadLine();
                    Console.Write("Please enter police date of birth: ");
                    DateTime addPoliceDob = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Please enter police station id: ");
                    int addPoliceStationId = Convert.ToInt32(Console.ReadLine());
                    Police addPolice = new Police()
                    {
                        PoliceName = addPoliceName,
                        PolicePhone = addPolicePhone,
                        PoliceCity = addPoliceCity,
                        PoliceAddress = addPoliceAddress,
                        PoliceDOB = addPoliceDob,
                        StationId = addPoliceStationId,
                    };
                    PoliceChiefLogic.AddPolice(addPolice);
                    Console.WriteLine("Police succesfully added!");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("How many records do you wish to add: ");
                    int numAdd = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numAdd; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                        Console.Write("Please enter police name: ");
                        string addRangePoliceName = Console.ReadLine();
                        Console.Write("Please enter police phone: ");
                        string addRangePolicePhone = Console.ReadLine();
                        Console.Write("Please eneter police city: ");
                        string addRangePoliceCity = Console.ReadLine();
                        Console.Write("Please enter police address: ");
                        string addRangePoliceAddress = Console.ReadLine();
                        Console.Write("Please enter police date of birth: ");
                        DateTime addRangePoliceDob = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Please enter police station id: ");
                        int addRangePoliceStationId = Convert.ToInt32(Console.ReadLine());
                        Police addRangePolice = new Police()
                        {
                            PoliceName = addRangePoliceName,
                            PolicePhone = addRangePolicePhone,
                            PoliceCity = addRangePoliceCity,
                            PoliceAddress = addRangePoliceAddress,
                            PoliceDOB = addRangePoliceDob,
                            StationId = addRangePoliceStationId,
                        };
                        PoliceChiefLogic.AddPolice(addRangePolice);
                        Console.WriteLine("Police succesfully added!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceChiefLogic.GetPolices())
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
                case "4":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceChiefLogic.GetPolice(id);
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
                case "5":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    var removeRecord = PoliceChiefLogic.GetPolice(removeId);
                    PoliceChiefLogic.RemovePolice(removeRecord);
                    Console.WriteLine("Police deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeById = Convert.ToInt32(Console.ReadLine());
                    PoliceChiefLogic.RemovePolice(removeById);
                    Console.WriteLine("Police deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("How many records do you wish to delete: ");
                    int numDelete = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numDelete; i++)
                    {
                        Console.Clear();
                        Console.Write("Please enter the Id of the record you want to delete: ");
                        int removeRangeById = Convert.ToInt32(Console.ReadLine());
                        PoliceChiefLogic.RemovePolice(removeRangeById);
                        Console.WriteLine("Police deleted succesfully!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Police updatePolice = PoliceChiefLogic.GetPolice(updateId);
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
                    PoliceChiefLogic.UpdateCity(updateId, updateCity);
                    Console.WriteLine("Police updated succesfully!");
                    Console.ReadLine();
                    break;
                case "9":
                    Console.Clear();
                    this.PoliceChiefMenuFunction();
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
            Console.WriteLine("1) Add new record: ");
            Console.WriteLine("2) Add new records(multiple): ");
            Console.WriteLine("3) Read all recodrs: ");
            Console.WriteLine("4) Read one recodrs: ");
            Console.WriteLine("5) Remove one record: ");
            Console.WriteLine("6) Remove one record(by Id): ");
            Console.WriteLine("7) Remove records(multiple): ");
            Console.WriteLine("8) Update record: ");
            Console.WriteLine("9) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                    Console.Write("Please enter criminal name: ");
                    string addCriminalName = Console.ReadLine();
                    Console.Write("Please enter criminal phone: ");
                    string addCriminalPhone = Console.ReadLine();
                    Console.Write("Please eneter criminal city: ");
                    string addCriminalCity = Console.ReadLine();
                    Console.Write("Please enter criminal address: ");
                    string addCriminalAddress = Console.ReadLine();
                    Console.Write("Please enter criminal date of birth: ");
                    DateTime addCriminalDob = Convert.ToDateTime(Console.ReadLine());
                    Criminal addCriminal = new Criminal()
                    {
                        CriminalName = addCriminalName,
                        CriminalPhone = addCriminalPhone,
                        CriminalCity = addCriminalCity,
                        CriminalAddress = addCriminalAddress,
                        CriminalDOB = addCriminalDob,
                    };
                    PoliceChiefLogic.AddCriminal(addCriminal);
                    Console.WriteLine("Criminal succesfully added!");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("How many records do you wish to add: ");
                    int numAdd = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numAdd; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                        Console.Write("Please enter criminal name: ");
                        string addRangeCriminalName = Console.ReadLine();
                        Console.Write("Please enter criminal phone: ");
                        string addRangeCriminalPhone = Console.ReadLine();
                        Console.Write("Please eneter criminal city: ");
                        string addRangeCriminalCity = Console.ReadLine();
                        Console.Write("Please enter criminal address: ");
                        string addRangeCriminalAddress = Console.ReadLine();
                        Console.Write("Please enter criminal date of birth: ");
                        DateTime addRangeCriminalDob = Convert.ToDateTime(Console.ReadLine());
                        Criminal addRangeCriminal = new Criminal()
                        {
                            CriminalName = addRangeCriminalName,
                            CriminalPhone = addRangeCriminalPhone,
                            CriminalCity = addRangeCriminalCity,
                            CriminalAddress = addRangeCriminalAddress,
                            CriminalDOB = addRangeCriminalDob,
                        };
                        PoliceChiefLogic.AddCriminal(addRangeCriminal);
                        Console.WriteLine("Criminal succesfully added!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceChiefLogic.GetCriminals())
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
                case "4":
                    Console.Clear();
                    Console.Write("What is the desired Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceChiefLogic.GetCriminal(id);
                    Console.WriteLine(
                            $"Criminal Id: {getRecord.CriminalId} \n" +
                            $"Criminal name: {getRecord.CriminalName} \n" +
                            $"Criminal phone: {getRecord.CriminalPhone} \n" +
                            $"Criminal city: {getRecord.CriminalCity} \n" +
                            $"Criminal address: {getRecord.CriminalAddress} \n" +
                            $"Criminal Dob: {getRecord.CriminalDOB} \n");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    var removeRecord = PoliceChiefLogic.GetCriminal(removeId);
                    PoliceChiefLogic.RemoveCriminal(removeRecord);
                    Console.WriteLine("Criminal deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeById = Convert.ToInt32(Console.ReadLine());
                    PoliceChiefLogic.RemoveCriminal(removeById);
                    Console.WriteLine("Criminal deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("How many records do you wish to delete: ");
                    int numDelete = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numDelete; i++)
                    {
                        Console.Clear();
                        Console.Write("Please enter the Id of the record you want to delete: ");
                        int removeRangeById = Convert.ToInt32(Console.ReadLine());
                        PoliceChiefLogic.RemoveCriminal(removeRangeById);
                        Console.WriteLine("Criminal deleted succesfully!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Criminal updateCriminal = PoliceChiefLogic.GetCriminal(updateId);
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
                    PoliceChiefLogic.UpdateCriminalName(updateId, updateName);
                    Console.WriteLine("Criminal updated succesfully!");
                    Console.ReadLine();
                    break;
                case "9":
                    Console.Clear();
                    this.PoliceChiefMenuFunction();
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
            Console.WriteLine("1) Add new record: ");
            Console.WriteLine("2) Add new records(multiple): ");
            Console.WriteLine("3) Read all recodrs: ");
            Console.WriteLine("4) Read one recodrs: ");
            Console.WriteLine("5) Remove one record: ");
            Console.WriteLine("6) Remove one record(by Id): ");
            Console.WriteLine("7) Remove records(multiple): ");
            Console.WriteLine("8) Update record: ");
            Console.WriteLine("9) Back: ");
            Console.Write("Chose the desired option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                    Console.Write("Please enter crime type: ");
                    string addCrimeType = Console.ReadLine();
                    Console.Write("Please enter crime date: ");
                    DateTime addCrimeDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Please eneter crime police officer Id: ");
                    int addCrimePolice = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter crime criminal Id: ");
                    int addCrimeCriminal = Convert.ToInt32(Console.ReadLine());
                    Crime addCrime = new Crime()
                    {
                        CrimeType = addCrimeType,
                        CrimeDate = addCrimeDate,
                        PoliceId = addCrimePolice,
                        CriminalId = addCrimeCriminal,
                    };
                    PoliceChiefLogic.AddCrime(addCrime);
                    Console.WriteLine("Crime succesfully added!");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("How many records do you wish to add: ");
                    int numAdd = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numAdd; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("To succesfully add a new record, please follow and fill the following data. ");
                        Console.Write("Please enter crime type: ");
                        string addRangeCrimeType = Console.ReadLine();
                        Console.Write("Please enter crime date: ");
                        DateTime addRangeCrimeDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Please eneter crime police officer Id: ");
                        int addRangeCrimePolice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter crime criminal Id: ");
                        int addRangeCrimeCriminal = Convert.ToInt32(Console.ReadLine());
                        Crime addRangeCrime = new Crime()
                        {
                            CrimeType = addRangeCrimeType,
                            CrimeDate = addRangeCrimeDate,
                            PoliceId = addRangeCrimePolice,
                            CrimeId = addRangeCrimeCriminal,
                        };
                        PoliceChiefLogic.AddCrime(addRangeCrime);
                        Console.WriteLine("Crime succesfully added!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    foreach (var getAllRecord in PoliceChiefLogic.GetCrimes())
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
                case "4":
                    Console.Clear();
                    Console.Write("What is the desired Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var getRecord = PoliceChiefLogic.GetCrime(id);
                    Console.WriteLine(
                            $"Crime Id: {getRecord.CrimeId} \n" +
                            $"Crime type: {getRecord.CrimeType} \n" +
                            $"Crime date: {getRecord.CrimeDate} \n" +
                            $"Crime police Id: {getRecord.PoliceId} \n" +
                            $"Crime criminal Id: {getRecord.CriminalId} \n");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    var removeRecord = PoliceChiefLogic.GetCrime(removeId);
                    PoliceChiefLogic.RemoveCrime(removeRecord);
                    Console.WriteLine("Crime deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Please enter the Id of the record you want to delete: ");
                    int removeById = Convert.ToInt32(Console.ReadLine());
                    PoliceChiefLogic.RemoveCrime(removeById);
                    Console.WriteLine("Crime deleted succesfully!");
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("How many records do you wish to delete: ");
                    int numDelete = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numDelete; i++)
                    {
                        Console.Clear();
                        Console.Write("Please enter the Id of the record you want to delete: ");
                        int removeRangeById = Convert.ToInt32(Console.ReadLine());
                        PoliceChiefLogic.RemoveCrime(removeRangeById);
                        Console.WriteLine("Crime deleted succesfully!");
                        System.Threading.Thread.Sleep(1000);
                    }

                    Console.ReadLine();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Please enter the desired record to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Crime updateCrime = PoliceChiefLogic.GetCrime(updateId);
                    Console.Clear();
                    Console.WriteLine(
                            $"Crime Id: {updateCrime.CrimeId} \n" +
                            $"Crime type: {updateCrime.CrimeType} \n" +
                            $"Crime date: {updateCrime.CrimeDate} \n" +
                            $"Crime police Id: {updateCrime.PoliceId} \n" +
                            $"Crime criminal Id: {updateCrime.CriminalId} \n");
                    Console.Write("Please enter the desired new type: ");
                    string updateType = Console.ReadLine();
                    PoliceChiefLogic.UpdateType(updateId, updateType);
                    Console.WriteLine("Crime updated succesfully!");
                    Console.ReadLine();
                    break;
                case "9":
                    Console.Clear();
                    this.PoliceChiefMenuFunction();
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
            foreach (var station in PoliceChiefLogic.GetStationPoliceCounts())
            {
                Console.WriteLine(station + "\n");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// TaskNonCRUDMenuFunction to display the Non-CRUD functionality, working as a task.
        /// </summary>
        public void TaskNonCRUDMenuFunction()
        {
            var nonCRUDTask = PoliceChiefLogic.GetStationPoliceCountsAsync();
            nonCRUDTask.Wait();
            foreach (var station in nonCRUDTask.Result)
            {
                Console.WriteLine(station + "\n");
            }

            Console.ReadLine();
        }
    }
}
