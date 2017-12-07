﻿namespace ETicketSystem.Services.Company.Contracts
{
	using ETicketSystem.Data.Enums;
	using ETicketSystem.Services.Company.Models;
	using System;
	using System.Collections.Generic;

	public interface ICompanyRouteService
    {
		bool Add(int startStation, int endStation, TimeSpan departureTime, TimeSpan duration, BusType busType, decimal price, string companyId);

		CompanyRoutesServiceModel All(string companyId);
    }
}
