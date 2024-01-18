// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1515:Single-line comment should be preceded by blank line", Justification = "<GitStats>")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.SendMessage(System.Boolean)")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiGetStations~System.Collections.Generic.List{PoliceApp.WPFClient.StationVM}")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiGetStations~System.Collections.Generic.List{PoliceApp.WPFClient.StationVM}")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiDelStations(PoliceApp.WPFClient.StationVM)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiDelStations(PoliceApp.WPFClient.StationVM)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiEditStation(PoliceApp.WPFClient.StationVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiEditStation(PoliceApp.WPFClient.StationVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainLogic.ApiEditStation(PoliceApp.WPFClient.StationVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "<GitStats>", Scope = "type", Target = "~T:PoliceApp.WPFClient.MainLogic")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<GitStats>", Scope = "member", Target = "~P:PoliceApp.WPFClient.MainVM.AllStations")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<GitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainVM.#ctor")]
[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<NikGitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.IMainLogic.ApiGetStations~System.Collections.Generic.List{PoliceApp.WPFClient.StationVM}")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<NikGitStats>", Scope = "member", Target = "~M:PoliceApp.WPFClient.MainVM.#ctor(PoliceApp.WPFClient.IMainLogic)")]
