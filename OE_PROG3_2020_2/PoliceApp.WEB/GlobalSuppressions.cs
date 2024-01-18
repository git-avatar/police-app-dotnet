// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<GITStats>", Scope = "member", Target = "~P:PoliceApp.WEB.Models.StationListViewModel.ListOfStations")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<GITStats>", Scope = "member", Target = "~P:PoliceApp.WEB.Models.StationListViewModel.ListOfStations")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<GITStats>", Scope = "type", Target = "~T:PoliceApp.WEB.Models.MapperFactory")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<GITStats>", Scope = "member", Target = "~M:PoliceApp.WEB.Controllers.StationsController.#ctor(PoliceApp.Logic.ILogics.IPoliceChiefLogic,AutoMapper.IMapper)")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "<GITStats>", Scope = "member", Target = "~M:PoliceApp.WEB.Controllers.StationsController.Index~Microsoft.AspNetCore.Mvc.IActionResult")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<GITStats>", Scope = "type", Target = "~T:PoliceApp.WEB.Prog")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "<GITStats>", Scope = "member", Target = "~F:PoliceApp.WEB.Controllers.HomeController._logger")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<GITStats>", Scope = "member", Target = "~M:PoliceApp.WEB.Controllers.StationsApiController.AddOneStation(PoliceApp.WEB.Models.Station)~PoliceApp.WEB.Controllers.ApiResult")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<GITStats>", Scope = "member", Target = "~M:PoliceApp.WEB.Controllers.StationsApiController.ModifyOneStation(PoliceApp.WEB.Models.Station)~PoliceApp.WEB.Controllers.ApiResult")]
