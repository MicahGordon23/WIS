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

            entity.ToTable("bin");

            entity.Property(e => e.BinId)
                .ValueGeneratedNever()
                .HasColumnName("bin_id");
            entity.Property(e => e.BinName)
                .HasMaxLength(20)
                .HasColumnName("bin_name");
            entity.Property(e => e.CommodityTypeIdLink).HasColumnName("commodity_type_id_link");
            entity.Property(e => e.CommodityVerityIdLink).HasColumnName("commodity_verity_id_link");
            entity.Property(e => e.NetIntake).HasColumnName("net_intake");
            entity.Property(e => e.WarehouseIdLink).HasColumnName("warehouse_id_link");

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.Bins)
                .HasForeignKey(d => d.CommodityTypeIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bin__commodity_t__30242045");

            entity.HasOne(d => d.WarehouseIdLinkNavigation).WithMany(p => p.Bins)
                .HasForeignKey(d => d.WarehouseIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bin__warehouse_i__2F2FFC0C");
        });

        modelBuilder.Entity<CommodityType>(entity =>
        {
            entity.HasKey(e => e.CommodityTypeId).HasName("PK__commodit__356293BFD84C873F");

            entity.ToTable("commodity_type");

            entity.Property(e => e.CommodityTypeId)
                .ValueGeneratedNever()
                .HasColumnName("commodity_type_id");
            entity.Property(e => e.CommodityTypeName)
                .HasMaxLength(75)
                .HasColumnName("commodity_type_name");
        });

        modelBuilder.Entity<CommodityVariety>(entity =>
        {
            entity.HasKey(e => e.CommodityVarietyId).HasName("PK__commodit__7CAD6A0796856F72");

            entity.ToTable("commodity_variety");

            entity.Property(e => e.CommodityVarietyId)
                .ValueGeneratedNever()
                .HasColumnName("commodity_variety_id");
            entity.Property(e => e.CommodityTypeIdLink).HasColumnName("commodity_type_id_link");
            entity.Property(e => e.CommodityVarietyName)
                .HasMaxLength(75)
                .HasColumnName("commodity_variety_name");

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.CommodityVarieties)
                .HasForeignKey(d => d.CommodityTypeIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__commodity__commo__2C538F61");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__district__2521322B1F6C9F98");

            entity.ToTable("district");

            entity.Property(e => e.DistrictId)
                .ValueGeneratedNever()
                .HasColumnName("district_id");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .HasColumnName("district_name");
        });

        modelBuilder.Entity<Load>(entity =>
        {
            entity.HasKey(e => e.LoadId).HasName("PK__load__08CE0C5A495510FE");

            entity.ToTable("load");

            entity.Property(e => e.LoadId)
                .ValueGeneratedNever()
                .HasColumnName("load_id");
            entity.Property(e => e.BolNumber).HasColumnName("bol_number");
            entity.Property(e => e.DestBin)
                .HasMaxLength(20)
                .HasColumnName("dest_bin");
            entity.Property(e => e.GrossWeight).HasColumnName("gross_weight");
            entity.Property(e => e.MoisturePercent).HasColumnName("moisture_percent");
            entity.Property(e => e.NetWeight).HasColumnName("net_weight");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .HasColumnName("notes");
            entity.Property(e => e.ProteinPercent).HasColumnName("protein_percent");
            entity.Property(e => e.TareWeight).HasColumnName("tare_weight");
            entity.Property(e => e.TestWeight).HasColumnName("test_weight");
            entity.Property(e => e.TimeIn)
                .HasColumnType("datetime")
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .HasColumnType("datetime")
                .HasColumnName("time_out");
            entity.Property(e => e.TruckId)
                .HasMaxLength(25)
                .HasColumnName("truck_id");
            entity.Property(e => e.WeightsheetIdLink).HasColumnName("weightsheet_id_link");

            entity.HasOne(d => d.WeightsheetIdLinkNavigation).WithMany(p => p.Loads)
                .HasForeignKey(d => d.WeightsheetIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__load__weightshee__3E723F9C");
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => e.LotId).HasName("PK__lot__38CAA92BE907A3FA");

            entity.ToTable("lot");

            entity.Property(e => e.LotId)
                .ValueGeneratedNever()
                .HasColumnName("lot_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.FarmNumber)
                .HasMaxLength(20)
                .HasColumnName("farm_number");
            entity.Property(e => e.Landlord)
                .HasMaxLength(25)
                .HasColumnName("landlord");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .HasColumnName("notes");
            entity.Property(e => e.ProducerIdLink).HasColumnName("producer_id_link");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.StateId)
                .HasMaxLength(3)
                .HasColumnName("state_id");
            entity.Property(e => e.TruckId)
                .HasMaxLength(25)
                .HasColumnName("truck_id");

            entity.HasOne(d => d.ProducerIdLinkNavigation).WithMany(p => p.Lots)
                .HasForeignKey(d => d.ProducerIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lot__producer_id__34E8D562");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.ProducerId).HasName("PK__producer__EA7F30C826157EDC");

            entity.ToTable("producer");

            entity.Property(e => e.ProducerId)
                .ValueGeneratedNever()
                .HasColumnName("producer_id");
            entity.Property(e => e.ProducerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("producer_name");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__warehous__734FE6BFE3FAE019");

            entity.ToTable("warehouse");

            entity.Property(e => e.WarehouseId)
                .ValueGeneratedNever()
                .HasColumnName("warehouse_id");
            entity.Property(e => e.DistrictIdLink).HasColumnName("district_id_link");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("warehouse_name");

            entity.HasOne(d => d.DistrictIdLinkNavigation).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.DistrictIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__warehouse__distr__278EDA44");
        });

        modelBuilder.Entity<Weightsheet>(entity =>
        {
            entity.HasKey(e => e.WeightsheetId).HasName("PK__weightsh__ED8FC6C55ECFFF1F");

            entity.ToTable("weightsheet");

            entity.Property(e => e.WeightsheetId)
                .ValueGeneratedNever()
                .HasColumnName("weightsheet_id");
            entity.Property(e => e.Bill).HasColumnName("bill");
            entity.Property(e => e.CommodityTypeIdLink).HasColumnName("commodity_type_id_link");
            entity.Property(e => e.CommodityVerityIdLink).HasColumnName("commodity_verity_id_link");
            entity.Property(e => e.HaulerName)
                .HasMaxLength(50)
                .HasColumnName("hauler_name");
            entity.Property(e => e.LotIdLink).HasColumnName("lot_id_link");
            entity.Property(e => e.Miles).HasColumnName("miles");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .HasColumnName("notes");
            entity.Property(e => e.OpenDate)
                .HasColumnType("date")
                .HasColumnName("open_date");
            entity.Property(e => e.ProducerIdLink).HasColumnName("producer_id_link");
            entity.Property(e => e.SourceIdLink).HasColumnName("source_id_link");
            entity.Property(e => e.WarehouseIdLink).HasColumnName("warehouse_id_link");
            entity.Property(e => e.WeighterName)
                .HasMaxLength(50)
                .HasColumnName("weighter_name");

            entity.HasOne(d => d.CommodityTypeIdLinkNavigation).WithMany(p => p.Weightsheets)
                .HasForeignKey(d => d.CommodityTypeIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__weightshe__commo__3AA1AEB8");

            entity.HasOne(d => d.CommodityVerityIdLinkNavigation).WithMany(p => p.Weightsheets)
                .HasForeignKey(d => d.CommodityVerityIdLink)
                .HasConstraintName("FK__weightshe__commo__3B95D2F1");

            entity.HasOne(d => d.LotIdLinkNavigation).WithMany(p => p.Weightsheets)
                .HasForeignKey(d => d.LotIdLink)
                .HasConstraintName("FK__weightshe__lot_i__49E3F248");

            entity.HasOne(d => d.ProducerIdLinkNavigation).WithMany(p => p.Weightsheets)
                .HasForeignKey(d => d.ProducerIdLink)
                .HasConstraintName("FK__weightshe__produ__38B96646");

            entity.HasOne(d => d.SourceIdLinkNavigation).WithMany(p => p.WeightsheetSourceIdLinkNavigations)
                .HasForeignKey(d => d.SourceIdLink)
                .HasConstraintName("FK__weightshe__sourc__39AD8A7F");

            entity.HasOne(d => d.WarehouseIdLinkNavigation).WithMany(p => p.WeightsheetWarehouseIdLinkNavigations)
                .HasForeignKey(d => d.WarehouseIdLink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__weightshe__wareh__37C5420D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
