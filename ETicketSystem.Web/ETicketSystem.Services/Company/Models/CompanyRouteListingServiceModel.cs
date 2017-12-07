﻿namespace ETicketSystem.Services.Company.Models
{
	using AutoMapper;
	using Data.Models;
	using ETicketSystem.Common.Automapper;
	using ETicketSystem.Data.Enums;
	using System;

	public class CompanyRouteListingServiceModel : IMapFrom<Route>, IHaveCustomMapping
    {
		public int Id { get; set; }

		public string StartStation { get; set; }

		public string EndStation { get; set; }

		public TimeSpan DepartureTime { get; set; }

		public TimeSpan Duration { get; set; }

		public string BusType { get; set; }

		public decimal Price { get; set; }

		public bool IsActive { get; set; }

		public void ConfigureMapping(Profile mapper)
		{
			mapper.CreateMap<Route, CompanyRouteListingServiceModel>()
				.ForMember(dest => dest.StartStation, cfg => cfg.MapFrom(src => $"{src.StartStation.Town.Name}, {src.StartStation.Name}"))
				.ForMember(dest => dest.EndStation, cfg => cfg.MapFrom(src => $"{src.EndStation.Town.Name}, {src.EndStation.Name}"))
				.ForMember(dest => dest.BusType, cfg => cfg.MapFrom(src => $"{src.BusType.ToString()} - {(int)Enum.Parse(typeof(BusType), src.BusType.ToString())} seats"));
		}
	}
}
