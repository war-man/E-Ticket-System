﻿namespace ETicketSystem.Services.Contracts
{
	using Models.Route;
	using System;
	using System.Collections.Generic;

	public interface IRouteService
    {
		IEnumerable<RouteSearchListingServiceModel> GetSearchedRoutes(int startTown, int endTown, DateTime date, string companyId);

		RouteBookTicketInfoServiceModel GetRouteTicketBookingInfo(int id, DateTime date);

		bool RouteExists(int id, TimeSpan departureTime);

		int GetSearchedRoutesCount(int startTown, int endTown, DateTime date, string companyId);
	}
}
