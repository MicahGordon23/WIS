using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.DbContexts;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bin> Bins { get; set; }

    public virtual DbSet<CommodityType> CommodityTypes { get; set; }

    public virtual DbSet<CommodityVariety> CommodityVarieties { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Load> Loads { get; set; }

    public virtual DbSet<Lot> Lots { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Weightsheet> Weightsheets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bin>(entity =>
        {
            entity.HasKey(e => e.BinId).HasName("PK__bin__824CC17DCE1ED524");

            entity.Property(e => e.BinId).ValueGeneratedNever();

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.Bins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bin__commodity_t__30242045");

            entity.HasOne(d => d.WarehouseIdLinkNavigation).WithMany(p => p.Bins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bin__warehouse_i__2F2FFC0C");
        });

        modelBuilder.Entity<CommodityType>(entity =>
        {
            entity.HasKey(e => e.CommodityTypeId).HasName("PK__commodit__356293BFD84C873F");

            entity.Property(e => e.CommodityTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CommodityVariety>(entity =>
        {
            entity.HasKey(e => e.CommodityVarietyId).HasName("PK__commodit__7CAD6A0796856F72");

            entity.Property(e => e.CommodityVarietyId).ValueGeneratedNever();

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.CommodityVarieties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__commodity__commo__2C538F61");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__district__2521322B1F6C9F98");

            entity.Property(e => e.DistrictId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Load>(entity =>
        {
            entity.HasKey(e => e.LoadId).HasName("PK__load__08CE0C5A495510FE");

            entity.Property(e => e.LoadId).ValueGeneratedNever();

            entity.HasOne(d => d.WeightsheetIdLinkNavigation).WithMany(p => p.Loads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__load__weightshee__3E723F9C");
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => e.LotId).HasName("PK__lot__38CAA92BE907A3FA");

            entity.Property(e => e.LotId).ValueGeneratedNever();

            entity.HasOne(d => d.ProducerIdLinkNavigation).WithMany(p => p.Lots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lot__producer_id__34E8D562");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.ProducerId).HasName("PK__producer__EA7F30C826157EDC");

            entity.Property(e => e.ProducerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__warehous__734FE6BFE3FAE019");

            entity.Property(e => e.WarehouseId).ValueGeneratedNever();

            entity.HasOne(d => d.DistrictIdLinkNavigation).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__warehouse__distr__278EDA44");
        });

        modelBuilder.Entity<Weightsheet>(entity =>
        {
            entity.HasKey(e => e.WeightsheetId).HasName("PK__weightsh__ED8FC6C55ECFFF1F");

            entity.Property(e => e.WeightsheetId).ValueGeneratedNever();

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.Weightsheets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__weightshe__commo__3AA1AEB8");

            entity.HasOne(d => d.CommodityVerityIdLinkNavigation).WithMany(p => p.Weightsheets).HasConstraintName("FK__weightshe__commo__3B95D2F1");

            entity.HasOne(d => d.ProducerIdLinkNavigation).WithMany(p => p.Weightsheets).HasConstraintName("FK__weightshe__produ__38B96646");

            entity.HasOne(d => d.SourceIdLinkNavigation).WithMany(p => p.WeightsheetSourceIdLinkNavigations).HasConstraintName("FK__weightshe__sourc__39AD8A7F");

            entity.HasOne(d => d.WarehouseIdLinkNavigation).WithMany(p => p.WeightsheetWarehouseIdLinkNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__weightshe__wareh__37C5420D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
