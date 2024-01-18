// <copyright file="PoliceReportertLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using NUnit.Framework;
    using PoliceApp.Data;
    using PoliceApp.Logic.NonCRUD;
    using PoliceApp.Program.MenuItems;
    using PoliceApp.Repository;

    /// <summary>
    /// PoliceReportertLogicTests o test the PoliceReporterLogic methods.
    /// </summary>
    [TestFixture]
    public class PoliceReportertLogicTests
    {
        /// <summary>
        /// TestCityMurders method, which tests the Non-CRUD method of the PoliceReporterLogic.
        /// </summary>
        [Test]
        public void TestCityMurders()
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
                new Criminal() { CriminalId = 1, CriminalName = "Name1", CriminalPhone = "00001", CriminalCity = "Name1", CriminalAddress = "Address1", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 2, CriminalName = "Name2", CriminalPhone = "00002", CriminalCity = "City2", CriminalAddress = "Address2", CriminalDOB = DateTime.Now },
                new Criminal() { CriminalId = 3, CriminalName = "Name3", CriminalPhone = "00003", CriminalCity = "Name3", CriminalAddress = "Address3", CriminalDOB = DateTime.Now },
            };
            criminalRepoMock.Setup(repo => repo.GetAll()).Returns(criminalList.AsQueryable);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            List<Crime> crimeList = new List<Crime>()
            {
                new Crime() { CrimeId = 1, CrimeType = "Murder", CrimeDate = DateTime.Now, PoliceId = 1, CriminalId = 1 },
                new Crime() { CrimeId = 2, CrimeType = "Type2", CrimeDate = DateTime.Now, PoliceId = 2, CriminalId = 2 },
                new Crime() { CrimeId = 3, CrimeType = "Murder", CrimeDate = DateTime.Now, PoliceId = 3, CriminalId = 3 },
            };
            crimeRepoMock.Setup(repo => repo.GetAll()).Returns(crimeList.AsQueryable);
            PoliceReporterLogic policeReporterLogic = new PoliceReporterLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            IList<CityMurders> result = policeReporterLogic.GetCityMurders();
            List<CityMurders> expectedResult = new List<CityMurders>()
            {
                new CityMurders() { CityName = "Name1", MurderCount = 1 },
                new CityMurders() { CityName = "Name3", MurderCount = 1 },
            };
            Assert.That(result, Is.EquivalentTo(expectedResult));
            Assert.That(result.Count == 2);
            Assert.That(result.Select(city => city.CityName), Does.Contain("Name1"));
            crimeRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            crimeRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            criminalRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            criminalRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the GetOneCrime method.
        /// </summary>
        [Test]
        public void TestGetOne()
        {
            Mock<IStationRepository> stationRepoMock = new Mock<IStationRepository>(MockBehavior.Loose);
            Mock<IPoliceRepository> policeRepoMock = new Mock<IPoliceRepository>(MockBehavior.Loose);
            Mock<ICriminalRepository> criminalRepoMock = new Mock<ICriminalRepository>(MockBehavior.Loose);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            PoliceReporterLogic policeReporterLogic = new PoliceReporterLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            policeReporterLogic.GetCrime(2);
            crimeRepoMock.Verify(repo => repo.GetOne(2), Times.Once);
            crimeRepoMock.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests the GetCrimes method.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            Mock<IStationRepository> stationRepoMock = new Mock<IStationRepository>(MockBehavior.Loose);
            Mock<IPoliceRepository> policeRepoMock = new Mock<IPoliceRepository>(MockBehavior.Loose);
            Mock<ICriminalRepository> criminalRepoMock = new Mock<ICriminalRepository>(MockBehavior.Loose);
            Mock<ICrimeRepository> crimeRepoMock = new Mock<ICrimeRepository>(MockBehavior.Loose);
            PoliceReporterLogic policeReporterLogic = new PoliceReporterLogic(stationRepoMock.Object, policeRepoMock.Object, criminalRepoMock.Object, crimeRepoMock.Object);
            policeReporterLogic.GetCrimes();
            crimeRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            crimeRepoMock.Verify(repo => repo.GetOne(2), Times.Never);
        }
    }
}
