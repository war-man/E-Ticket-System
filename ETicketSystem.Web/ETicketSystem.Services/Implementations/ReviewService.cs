﻿namespace ETicketSystem.Services.Implementations
{
	using AutoMapper.QueryableExtensions;
	using Contracts;
	using Data;
	using Data.Models;
	using Models.Review;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class ReviewService : IReviewService
	{
		private readonly ETicketSystemDbContext db;

		public ReviewService(ETicketSystemDbContext db)
		{
			this.db = db;
		}

		public IEnumerable<ReviewInfoServiceModel> All(string companyId, int page = 1, int pageSize = 10) =>
			this.db
				.Reviews
				.Where(r => r.CompanyId == companyId)
				.Skip((page-1)*pageSize)
				.Take(pageSize)
				.ProjectTo<ReviewInfoServiceModel>()
				.ToList();

		public bool Add(string companyId, string userId, string description)
		{
			if (!this.db.Tickets.Any(t=>t.UserId == userId && t.Route.CompanyId == companyId))
			{
				return false;
			}

			var review = new Review()
			{
				CompanyId = companyId,
				Description = description,
				UserId = userId,
				PublishDate = DateTime.UtcNow.ToLocalTime()
			};

			this.db.Reviews.Add(review);
			this.db.SaveChanges();

			return true;
		}

		public int TotalReviews(string companyId) => this.db.Reviews.Count(r => r.CompanyId == companyId);
	}
}