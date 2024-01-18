// <copyright file="PoliceChiefLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using PoliceApp.Data;
    using PoliceApp.Logic.Logics;
    using PoliceApp.Logic.NonCRUD;
    using PoliceApp.Repository;

    /// <summary>
    /// PoliceChiefLogicTests to test the PoliceChiefLogic methods.
    /// </summary>
    [TestFixture]
    public class PoliceChiefLogicTests
    {
        /// <summary>
        /// TestSationPoliceCount method, which tests the Non-CRUD method of the PoliceChiefLogic.
        /// </summary>
        [Test]
        public void TestSationPoliceCount()
        {
            Mock<IStationRepository> stationRepoMock = new Mock<IStationRepository>(MockBehavior.Loose);
            List<Station> stationList = new List<Station>()
            {
                new Station() { StationId = 1, StationName = "Name1", StationCity = "City1", StationPhone = "00001", StationAddress = "Address1", StationPostCode = "PostalCode1" },
                new Station() { StationId = 2, StationName = "Name2", StationCity = "City2", StationPhone = "00002", StationAddress = "Address2", StationPostCode = "PostalCode2" },
                new Station() { StationId = 3, StationName = "Name3", StationCity = "City3", StationPhone = "00003", StationAddress = "Address3", StationPostCode = "PostalCode3" },
                new Station() { StationId = 4, StationName = "Name4", StationCity = "City4", StationPhone = "00004", StationAddress = "Address4", StationPostCode = "PostalCode4" },
            };
            stationRepoMock.Setup(repo => repo.GetAll()).Returns(stationList.AsQueryable());
            Mock<IPoliceRepository> policeRepoMock = new Mock<IPoliceRepository>(MockBehavior.Loose);
            List<Police> policeList = new List<Police>()
            {
                new Police() { PoliceId = 1, PoliceName = "Name1", PolicePhone = "00001", PoliceCity = "City1", PoliceAddress = "Address1", PoliceDOB = DateTime.Now, StationId = 1 },
                new Police() { PoliceId = 2, PoliceName = "Name2", PolicePhone = "00002", PoliceCity = "City2", PoliceAddress = "Address2", PoliceDOB = DateTime.Now, StationId = 2 },
                new Police() { PoliceId = 3, PoliceName = "Name3", PolicePhone = "00003", PoliceCity = "City3", PoliceAddress = "Address3", PoliceDOB = DateTime.Now, StationId = 3 },
                new Police() { PoliceId = 4, PoliceName = "Name4", PolicePhone = "00004", PoliceCity = "City4", PoliceAddress = "Address4", PoliceDOB = DateTime.Now, StationId = 3 },
            };
            policeRepoMock.Setup(repo => repo.GetAll()).Returns(policeList.AsQueryable);
            Mock<ICriminalRepository> criminalRepoMock = new Mock<ICriminalRepository>(MockBehavior.Loose);
            List<Criminal> criminalList = new List<Criminal>()
            {
                new Criminal() { CriminalId = 1, CriminalName = "Name1", CriminalPhone = "00001", CriminalCity = "City1", CriminalAddress = "Address1", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 2, CriminalName = "Name2", CriminalPhone = "00002", CriminalCity = "City2", CriminalAddress = "Address2", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 3, CriminalName = "Name3", CriminalPhone = "00003", CriminalCity = "City3", CriminalAddress = "Address3", CriminalDOB = DateTime.Now },
            };
            criminalRepoMock.Setup(repo => repo.GetAll()).Returns(criminalList.AsQueryable);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            List<Crime> crimeList = new List<Crime>()
            {
                new Crime() { CrimeId = 1, CrimeType = "Type1", CrimeDate = DateTime.Now, PoliceId = 1, CriminalId = 1 },
                new Crime() { CrimeId = 2, CrimeType = "Type2", CrimeDate = DateTime.Now, PoliceId = 2, CriminalId = 2 },
                new Crime() { CrimeId = 3, CrimeType = "Type3", CrimeDate = DateTime.Now, PoliceId = 3, CriminalId = 3 },
            };
            crimeRepoMock.Setup(repo => repo.GetAll()).Returns(crimeList.AsQueryable);
            PoliceChiefLogic policeChiefLogic = new PoliceChiefLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            IList<StationPoliceCount> result = policeChiefLogic.GetStationPoliceCounts();
            List<StationPoliceCount> expectedResult = new List<StationPoliceCount>()
            {
                new StationPoliceCount() { StationName = "Name1", OfficerCount = 1 },
                new StationPoliceCount() { StationName = "Name2", OfficerCount = 1 },
                new StationPoliceCount() { StationName = "Name3", OfficerCount = 2 },
            };
            Assert.That(result, Is.EquivalentTo(expectedResult));
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Select(station => station.StationName), Does.Contain("Name1"));
            Assert.That(result.Select(station => station.StationName), Does.Not.Contain("Name4"));
            stationRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            stationRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            policeRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            policeRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the AddStation method.
        /// </summary>
        [Test]
        public void TestAddStation()
        {
            Mock<IStationRepository> stationRepoMock = new Mock<IStationRepository>(MockBehavior.Loose);
            List<Station> stationList = new List<Station>()
            {
                new Station() { StationId = 1, StationName = "Name1", StationCity = "City1", StationPhone = "00001", StationAddress = "Address1", StationPostCode = "PostalCode1" },
                new Station() { StationId = 2, StationName = "Name2", StationCity = "City2", StationPhone = "00002", StationAddress = "Address2", StationPostCode = "PostalCode2" },
                new Station() { StationId = 3, StationName = "Name3", StationCity = "City3", StationPhone = "00003", StationAddress = "Address3", StationPostCode = "PostalCode3" },
                new Station() { StationId = 4, StationName = "Name4", StationCity = "City4", StationPhone = "00004", StationAddress = "Address4", StationPostCode = "PostalCode4" },
            };
            stationRepoMock.Setup(repo => repo.GetAll()).Returns(stationList.AsQueryable());
            Mock<IPoliceRepository> policeRepoMock = new Mock<IPoliceRepository>(MockBehavior.Loose);
            List<Police> policeList = new List<Police>()
            {
                new Police() { PoliceId = 1, PoliceName = "Name1", PolicePhone = "00001", PoliceCity = "City1", PoliceAddress = "Address1", PoliceDOB = DateTime.Now, StationId = 1 },
                new Police() { PoliceId = 2, PoliceName = "Name2", PolicePhone = "00002", PoliceCity = "City2", PoliceAddress = "Address2", PoliceDOB = DateTime.Now, StationId = 2 },
                new Police() { PoliceId = 3, PoliceName = "Name3", PolicePhone = "00003", PoliceCity = "City3", PoliceAddress = "Address3", PoliceDOB = DateTime.Now, StationId = 3 },
                new Police() { PoliceId = 4, PoliceName = "Name4", PolicePhone = "00004", PoliceCity = "City4", PoliceAddress = "Address4", PoliceDOB = DateTime.Now, StationId = 4 },
            };
            policeRepoMock.Setup(repo => repo.GetAll()).Returns(policeList.AsQueryable);
            Mock<ICriminalRepository> criminalRepoMock = new Mock<ICriminalRepository>(MockBehavior.Loose);
            List<Criminal> criminalList = new List<Criminal>()
            {
                new Criminal() { CriminalId = 1, CriminalName = "Name1", CriminalPhone = "00001", CriminalCity = "City1", CriminalAddress = "Address1", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 2, CriminalName = "Name2", CriminalPhone = "00002", CriminalCity = "City2", CriminalAddress = "Address2", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 3, CriminalName = "Name3", CriminalPhone = "00003", CriminalCity = "City3", CriminalAddress = "Address3", CriminalDOB = DateTime.Now },
            };
            criminalRepoMock.Setup(repo => repo.GetAll()).Returns(criminalList.AsQueryable);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            List<Crime> crimeList = new List<Crime>()
            {
                new Crime() { CrimeId = 1, CrimeType = "Type1", CrimeDate = DateTime.Now, PoliceId = 1, CriminalId = 1 },
                new Crime() { CrimeId = 2, CrimeType = "Type2", CrimeDate = DateTime.Now, PoliceId = 2, CriminalId = 2 },
                new Crime() { CrimeId = 3, CrimeType = "Type3", CrimeDate = DateTime.Now, PoliceId = 3, CriminalId = 3 },
            };
            crimeRepoMock.Setup(repo => repo.GetAll()).Returns(crimeList.AsQueryable);
            PoliceChiefLogic policeChiefLogic = new PoliceChiefLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            Station addStation = new Station() { StationId = 5, StationName = "Name5", StationCity = "City5", StationPhone = "00005", StationAddress = "Address5", StationPostCode = "PostalCode5" };
            stationRepoMock.Setup(repo => repo.Add(addStation)).Callback(() => stationList.Add(addStation));
            policeChiefLogic.AddStation(addStation);
            Assert.That(policeChiefLogic.GetStations().Count, Is.EqualTo(5));
            stationRepoMock.Verify(repo => repo.Add(addStation), Times.Once);
        }

        /// <summary>
        /// Tests the RemoveCriminal method.
        /// </summary>
        [Test]
        public void TestRemoveCriminal()
        {
            Mock<IStationRepository> stationRepoMock = new Mock<IStationRepository>(MockBehavior.Loose);
            List<Station> stationList = new List<Station>()
            {
                new Station() { StationId = 1, StationName = "Name1", StationCity = "City1", StationPhone = "00001", StationAddress = "Address1", StationPostCode = "PostalCode1" },
                new Station() { StationId = 2, StationName = "Name2", StationCity = "City2", StationPhone = "00002", StationAddress = "Address2", StationPostCode = "PostalCode2" },
                new Station() { StationId = 3, StationName = "Name3", StationCity = "City3", StationPhone = "00003", StationAddress = "Address3", StationPostCode = "PostalCode3" },
                new Station() { StationId = 4, StationName = "Name4", StationCity = "City4", StationPhone = "00004", StationAddress = "Address4", StationPostCode = "PostalCode4" },
            };
            stationRepoMock.Setup(repo => repo.GetAll()).Returns(stationList.AsQueryable());
            Mock<IPoliceRepository> policeRepoMock = new Mock<IPoliceRepository>(MockBehavior.Loose);
            List<Police> policeList = new List<Police>()
            {
                new Police() { PoliceId = 1, PoliceName = "Name1", PolicePhone = "00001", PoliceCity = "City1", PoliceAddress = "Address1", PoliceDOB = DateTime.Now, StationId = 1 },
                new Police() { PoliceId = 2, PoliceName = "Name2", PolicePhone = "00002", PoliceCity = "City2", PoliceAddress = "Address2", PoliceDOB = DateTime.Now, StationId = 2 },
                new Police() { PoliceId = 3, PoliceName = "Name3", PolicePhone = "00003", PoliceCity = "City3", PoliceAddress = "Address3", PoliceDOB = DateTime.Now, StationId = 3 },
                new Police() { PoliceId = 4, PoliceName = "Name4", PolicePhone = "00004", PoliceCity = "City4", PoliceAddress = "Address4", PoliceDOB = DateTime.Now, StationId = 4 },
            };
            policeRepoMock.Setup(repo => repo.GetAll()).Returns(policeList.AsQueryable);
            Mock<ICriminalRepository> criminalRepoMock = new Mock<ICriminalRepository>(MockBehavior.Loose);
            List<Criminal> criminalList = new List<Criminal>()
            {
                new Criminal() { CriminalId = 1, CriminalName = "Name1", CriminalPhone = "00001", CriminalCity = "City1", CriminalAddress = "Address1", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 2, CriminalName = "Name2", CriminalPhone = "00002", CriminalCity = "City2", CriminalAddress = "Address2", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 3, CriminalName = "Name3", CriminalPhone = "00003", CriminalCity = "City3", CriminalAddress = "Address3", CriminalDOB = DateTime.Now },
            };
            criminalRepoMock.Setup(repo => repo.GetAll()).Returns(criminalList.AsQueryable);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            List<Crime> crimeList = new List<Crime>()
            {
                new Crime() { CrimeId = 1, CrimeType = "Type1", CrimeDate = DateTime.Now, PoliceId = 1, CriminalId = 1 },
                new Crime() { CrimeId = 2, CrimeType = "Type2", CrimeDate = DateTime.Now, PoliceId = 2, CriminalId = 2 },
                new Crime() { CrimeId = 3, CrimeType = "Type3", CrimeDate = DateTime.Now, PoliceId = 3, CriminalId = 3 },
            };
            crimeRepoMock.Setup(repo => repo.GetAll()).Returns(crimeList.AsQueryable);
            PoliceChiefLogic policeChiefLogic = new PoliceChiefLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            criminalRepoMock.Setup(repo => repo.GetOne(1)).Returns(criminalList[1 - 1]);
            Criminal removed = policeChiefLogic.GetCriminal(1);
            criminalRepoMock.Setup(repo => repo.Remove(removed)).Callback(() => criminalList.Remove(removed));
            policeChiefLogic.RemoveCriminal(removed);
            Assert.That(policeChiefLogic.GetCriminals().Count, Is.EqualTo(2));
            criminalRepoMock.Verify(repo => repo.Remove(removed), Times.Once);
        }
    }
}
