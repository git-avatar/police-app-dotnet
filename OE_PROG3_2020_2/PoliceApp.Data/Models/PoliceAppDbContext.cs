// <copyright file="PoliceAppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// PoliceAppDbContext class.
    /// </summary>
    public partial class PoliceAppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceAppDbContext"/> class.
        /// PoliceAppDbContext constructor.
        /// </summary>
        public PoliceAppDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets stations property.
        /// </summary>
        public DbSet<Station> Stations { get; set; }

        /// <summary>
        /// Gets or sets polices property.
        /// </summary>
        public DbSet<Police> Polices { get; set; }

        /// <summary>
        /// Gets or sets criminals property.
        /// </summary>
        public DbSet<Criminal> Criminals { get; set; }

        /// <summary>
        /// Gets or sets crimes property.
        /// </summary>
        public DbSet<Crime> Crimes { get; set; }

        /// <summary>
        /// OnConfiguring method, connects to the database using the connection string.
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder parameter.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentException("Options builder can not be null.");
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PoliceAppDatabase.mdf;Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        /// <summary>
        /// OnModelCreateing method, sets up the relations between the tables and fills them up.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder parameter.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.Entity<Police>(entity =>
            {
                entity.HasOne(police => police.Station).
                WithMany(station => station.GetPolice).
                HasForeignKey(police => police.StationId).
                OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Crime>(entity =>
            {
                entity.HasOne(crime => crime.Police).
                WithMany(police => police.Crimes).
                HasForeignKey(crime => crime.PoliceId).
                OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Crime>(entity =>
            {
                entity.HasOne(crime => crime.Criminal).
                WithMany(criminal => criminal.Crimes).
                HasForeignKey(crime => crime.CriminalId).
                OnDelete(DeleteBehavior.ClientSetNull);
            });

            Station station1 = new Station() { StationId = 1, StationName = "Akaroa Police Station", StationCity = "Akaroa", StationPhone = "(03) 304 1031", StationAddress = "9 Rue Lavaud", StationPostCode = "7520" };
            Station station2 = new Station() { StationId = 2, StationName = "Alexandra Police Station", StationCity = "Alexandra", StationPhone = "(03) 440 2501", StationAddress = "2 Kelman St", StationPostCode = "9340" };
            Station station3 = new Station() { StationId = 3, StationName = "Auckland Central Police Station", StationCity = "Auckland", StationPhone = "(09) 375 4650", StationAddress = "15 College Hill", StationPostCode = "1142" };
            Station station4 = new Station() { StationId = 4, StationName = "Balclutha Police Station", StationCity = "Balclutha", StationPhone = "(03) 418 0307", StationAddress = "9 Renfrew St", StationPostCode = "9240" };
            Station station5 = new Station() { StationId = 5, StationName = "Bluff Police Station", StationCity = "Bluff", StationPhone = "(03) 212 8845", StationAddress = "80 Barrow St", StationPostCode = "9842" };

            Police police1 = new Police() { PoliceId = 1, PoliceName = "Robin T Adkins", PolicePhone = "410-292-7093", PoliceCity = "Akaroa", PoliceAddress = "2043 Marie Street", PoliceDOB = new DateTime(1983, 2, 18), StationId = station1.StationId };
            Police police2 = new Police() { PoliceId = 2, PoliceName = "Vicente G Lipps", PolicePhone = "812-201-5329", PoliceCity = "Akaroa", PoliceAddress = "3501 Winifred Way", PoliceDOB = new DateTime(1973, 5, 13), StationId = station1.StationId };
            Police police3 = new Police() { PoliceId = 3, PoliceName = "John R Ross", PolicePhone = "206-314-6977", PoliceCity = "Alexandra", PoliceAddress = "3107 Sun Valley Road", PoliceDOB = new DateTime(1990, 12, 3), StationId = station2.StationId };
            Police police4 = new Police() { PoliceId = 4, PoliceName = "Vincent P Sandoval", PolicePhone = "619-994-5417", PoliceCity = "Auckland", PoliceAddress = "1105 Ocello Street", PoliceDOB = new DateTime(1983, 1, 31), StationId = station3.StationId };
            Police police5 = new Police() { PoliceId = 5, PoliceName = "Carol P Hess", PolicePhone = "916-825-9540", PoliceCity = "Auckland", PoliceAddress = "2508 Frederick Street", PoliceDOB = new DateTime(1993, 4, 8), StationId = station3.StationId };
            Police police6 = new Police() { PoliceId = 6, PoliceName = "Angel M Marcus", PolicePhone = "773-501-6945", PoliceCity = "Balclutha", PoliceAddress = "4070 Kembery Drive", PoliceDOB = new DateTime(1972, 8, 9), StationId = station4.StationId };
            Police police7 = new Police() { PoliceId = 7, PoliceName = "Donna W Little", PolicePhone = "734-812-5923", PoliceCity = "Nordere", PoliceAddress = "4531 Woodbridge Lane", PoliceDOB = new DateTime(1987, 6, 20), StationId = station4.StationId };
            Police police8 = new Police() { PoliceId = 8, PoliceName = "David K Tucker", PolicePhone = "606-362-5787", PoliceCity = "Balclutha", PoliceAddress = "2178 Mayo Street", PoliceDOB = new DateTime(1968, 5, 12), StationId = station4.StationId };
            Police police9 = new Police() { PoliceId = 9, PoliceName = "Laurel J Valliere", PolicePhone = "408-202-4060", PoliceCity = "Bluff", PoliceAddress = "160 Pretty View Lane", PoliceDOB = new DateTime(1992, 8, 14), StationId = station5.StationId };
            Police police10 = new Police() { PoliceId = 10, PoliceName = "Jesse A Wash", PolicePhone = "757-945-5428", PoliceCity = "Bluff", PoliceAddress = "3920 Biddie Lane", PoliceDOB = new DateTime(1994, 10, 27), StationId = station5.StationId };

            Criminal criminal1 = new Criminal() { CriminalId = 1, CriminalName = "Yolanda S Villicana", CriminalPhone = "708-569-0858", CriminalCity = "Akaroa", CriminalAddress = "2178 Emeral Dreams Drive", CriminalDOB = new DateTime(199, 4, 13) };
            Criminal criminal2 = new Criminal() { CriminalId = 2, CriminalName = "George K Jay", CriminalPhone = "646-270-8000", CriminalCity = "Akaroa", CriminalAddress = "1330 Taylor Street", CriminalDOB = new DateTime(1977, 7, 23) };
            Criminal criminal3 = new Criminal() { CriminalId = 3, CriminalName = "Lee K Sullivan", CriminalPhone = "318-578-1065", CriminalCity = "Alexandra", CriminalAddress = "2470 Shadowmar Drive", CriminalDOB = new DateTime(1983, 6, 25) };
            Criminal criminal4 = new Criminal() { CriminalId = 4, CriminalName = "Jarrod S Miller", CriminalPhone = "252-573-4732", CriminalCity = "Alexandra", CriminalAddress = "874 Green Acres Road", CriminalDOB = new DateTime(1998, 9, 13) };
            Criminal criminal5 = new Criminal() { CriminalId = 5, CriminalName = "Margaret R Rupp", CriminalPhone = "915-203-6780", CriminalCity = "Balclutha", CriminalAddress = "4116 Birch Street", CriminalDOB = new DateTime(1978, 11, 15) };
            Criminal criminal6 = new Criminal() { CriminalId = 6, CriminalName = "Christopher L Blood", CriminalPhone = "757-758-7159", CriminalCity = "Balclutha", CriminalAddress = "835 Lawman Avenue", CriminalDOB = new DateTime(1983, 10, 4) };
            Criminal criminal7 = new Criminal() { CriminalId = 7, CriminalName = "Ramiro S Keller", CriminalPhone = "641-680-5609", CriminalCity = "Auckland", CriminalAddress = "2972 Park Boulevard", CriminalDOB = new DateTime(1992, 5, 16) };
            Criminal criminal8 = new Criminal() { CriminalId = 8, CriminalName = "Laura F Wilson", CriminalPhone = "434-607-0045", CriminalCity = "Auckland", CriminalAddress = "2157 Coulter Lane", CriminalDOB = new DateTime(1993, 8, 25) };
            Criminal criminal9 = new Criminal() { CriminalId = 9, CriminalName = "Helen B Redman", CriminalPhone = "216-470-9601", CriminalCity = "Auckland", CriminalAddress = "4458 James Martin Circle", CriminalDOB = new DateTime(1969, 9, 23) };
            Criminal criminal10 = new Criminal() { CriminalId = 10, CriminalName = "Brian D Dodge", CriminalPhone = "508-615-9947", CriminalCity = "Auckland", CriminalAddress = "82 Lyon Avenue", CriminalDOB = new DateTime(1977, 7, 17) };
            Criminal criminal11 = new Criminal() { CriminalId = 11, CriminalName = "Arlene K Livingston", CriminalPhone = "806-471-8223", CriminalCity = "Bluff", CriminalAddress = "922 Baker Avenue", CriminalDOB = new DateTime(1998, 6, 29) };
            Criminal criminal12 = new Criminal() { CriminalId = 12, CriminalName = "David V Maddox", CriminalPhone = "732-503-1374", CriminalCity = "Bluff", CriminalAddress = "3093 Stonepot Road", CriminalDOB = new DateTime(1995, 8, 27) };

            Crime crime1 = new Crime() { CrimeId = 1, CrimeType = "Murder", CrimeDate = new DateTime(2010, 11, 14), PoliceId = police1.PoliceId, CriminalId = criminal1.CriminalId };
            Crime crime2 = new Crime() { CrimeId = 2, CrimeType = "Assult", CrimeDate = new DateTime(2011, 6, 14), PoliceId = police2.PoliceId, CriminalId = criminal2.CriminalId };
            Crime crime3 = new Crime() { CrimeId = 3, CrimeType = "Robbery", CrimeDate = new DateTime(2009, 12, 30), PoliceId = police3.PoliceId, CriminalId = criminal3.CriminalId };
            Crime crime4 = new Crime() { CrimeId = 4, CrimeType = "Speeding", CrimeDate = new DateTime(2012, 3, 12), PoliceId = police3.PoliceId, CriminalId = criminal4.CriminalId };
            Crime crime5 = new Crime() { CrimeId = 5, CrimeType = "Murder", CrimeDate = new DateTime(2013, 8, 25), PoliceId = police4.PoliceId, CriminalId = criminal7.CriminalId };
            Crime crime6 = new Crime() { CrimeId = 6, CrimeType = "Rape", CrimeDate = new DateTime(2015, 3, 28), PoliceId = police4.PoliceId, CriminalId = criminal8.CriminalId };
            Crime crime7 = new Crime() { CrimeId = 7, CrimeType = "Kidnaping", CrimeDate = new DateTime(2018, 6, 30), PoliceId = police4.PoliceId, CriminalId = criminal9.CriminalId };
            Crime crime8 = new Crime() { CrimeId = 8, CrimeType = "Assult", CrimeDate = new DateTime(2014, 8, 9), PoliceId = police5.PoliceId, CriminalId = criminal10.CriminalId };
            Crime crime9 = new Crime() { CrimeId = 9, CrimeType = "Battery", CrimeDate = new DateTime(2017, 10, 11), PoliceId = police6.PoliceId, CriminalId = criminal5.CriminalId };
            Crime crime10 = new Crime() { CrimeId = 10, CrimeType = "Assult", CrimeDate = new DateTime(2016, 11, 23), PoliceId = police7.PoliceId, CriminalId = criminal6.CriminalId };
            Crime crime11 = new Crime() { CrimeId = 11, CrimeType = "Speeding", CrimeDate = new DateTime(2015, 4, 21), PoliceId = police9.PoliceId, CriminalId = criminal11.CriminalId };
            Crime crime12 = new Crime() { CrimeId = 12, CrimeType = "Murder", CrimeDate = new DateTime(2013, 6, 28), PoliceId = police10.PoliceId, CriminalId = criminal12.CriminalId };

            modelBuilder.Entity<Station>().HasData(station1, station2, station3, station4, station5);
            modelBuilder.Entity<Police>().HasData(police1, police2, police3, police4, police5, police6, police7, police8, police9, police10);
            modelBuilder.Entity<Criminal>().HasData(criminal1, criminal2, criminal3, criminal4, criminal5, criminal6, criminal7, criminal8, criminal9, criminal10, criminal11, criminal12);
            modelBuilder.Entity<Crime>().HasData(crime1, crime2, crime3, crime4, crime5, crime6, crime7, crime8, crime9, crime10, crime11, crime12);
        }
    }
}
