﻿using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.DTOs;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base()
		{

		}

		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Bin> Bins => Set<Bin>();

		public DbSet<CommodityType> CommodityTypes => Set<CommodityType>();

		public DbSet<CommodityVariety> CommodityVarieties => Set<CommodityVariety>();

		public DbSet<District> Districts => Set<District>();

		public DbSet<Load> Loads => Set<Load>();

		public DbSet<Lot> Lots => Set<Lot>();

		public DbSet<Producer> Producers => Set<Producer>();

		public DbSet<Warehouse> Warehouses => Set<Warehouse>();

		public DbSet<Weightsheet> Weightsheets => Set<Weightsheet>();

		public DbSet<Source> Sources => Set<Source>();

		public DbSet<IntakeReport> IntakeReports { get; set; }
	}
}
