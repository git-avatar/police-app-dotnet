// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WEB.Models
{
    using AutoMapper;

    /// <summary>
    /// MapperFactory class.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// CreateMapper method that is responsible for converting the Data.data into Model.data.
        /// </summary>
        /// <returns>IMapper instance to do the conversion.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PoliceApp.Data.Station, PoliceApp.WEB.Models.Station>().
                ForMember(dest => dest.StationId, map => map.MapFrom(src => src.StationId)).
                ForMember(dest => dest.StationName, map => map.MapFrom(src => src.StationName)).
                ForMember(dest => dest.StationCity, map => map.MapFrom(src => src.StationCity)).
                ForMember(dest => dest.StationPhone, map => map.MapFrom(src => src.StationPhone)).
                ForMember(dest => dest.StationAddress, map => map.MapFrom(src => src.StationAddress)).
                ForMember(dest => dest.StationPostCode, map => map.MapFrom(src => src.StationPostCode));
            });
            return config.CreateMapper();
        }
    }
}
