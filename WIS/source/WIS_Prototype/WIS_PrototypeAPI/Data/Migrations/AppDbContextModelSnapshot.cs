﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WIS_PrototypeAPI.Data;

#nullable disable

namespace WIS_PrototypeAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Bin", b =>
                {
                    b.Property<int>("BinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BinId"));

                    b.Property<string>("BinName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CommodityTypeIdLink")
                        .HasColumnType("int");

                    b.Property<long?>("CommodityVarietyIdLink")
                        .HasColumnType("bigint");

                    b.Property<int?>("NetIntake")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseIdLink")
                        .HasColumnType("int");

                    b.HasKey("BinId");

                    b.HasIndex("CommodityTypeIdLink");

                    b.HasIndex("CommodityVarietyIdLink");

                    b.HasIndex("WarehouseIdLink");

                    b.ToTable("Bins");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.CommodityType", b =>
                {
                    b.Property<int>("CommodityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommodityTypeId"));

                    b.Property<string>("CommodityTypeName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CommodityTypeId");

                    b.ToTable("CommodityTypes");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.CommodityVariety", b =>
                {
                    b.Property<long>("CommodityVarietyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CommodityVarietyId"));

                    b.Property<int?>("CommodityTypeIdLink")
                        .HasColumnType("int");

                    b.Property<string>("CommodityVarietyName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CommodityVarietyId");

                    b.HasIndex("CommodityTypeIdLink");

                    b.ToTable("CommodityVarieties");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictId"));

                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("DistrictId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Load", b =>
                {
                    b.Property<long>("LoadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LoadId"));

                    b.Property<string>("BillOfLading")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("BinIdLink")
                        .HasColumnType("int");

                    b.Property<int?>("GrossWeight")
                        .HasColumnType("int");

                    b.Property<double?>("MoistureLevel")
                        .HasColumnType("float");

                    b.Property<int?>("NetWeight")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("ProtienLevel")
                        .HasColumnType("float");

                    b.Property<int?>("TareWeight")
                        .HasColumnType("int");

                    b.Property<double?>("TestWeight")
                        .HasColumnType("float");

                    b.Property<DateTime?>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("TruckId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("WeightsheetIdLink")
                        .HasColumnType("bigint");

                    b.HasKey("LoadId");

                    b.HasIndex("BinIdLink");

                    b.HasIndex("WeightsheetIdLink");

                    b.ToTable("Loads");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Lot", b =>
                {
                    b.Property<long>("LotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LotId"));

                    b.Property<int?>("CommodityTypeIdLink")
                        .HasColumnType("int");

                    b.Property<long?>("CommodityVarietyIdLink")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("FarmNumber")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Landlord")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ProducerIdLink")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("StateId")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("WarehouseIdLink")
                        .HasColumnType("int");

                    b.HasKey("LotId");

                    b.HasIndex("CommodityTypeIdLink");

                    b.HasIndex("CommodityVarietyIdLink");

                    b.HasIndex("ProducerIdLink");

                    b.HasIndex("WarehouseIdLink");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Producer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducerId"));

                    b.Property<string>("ProducerName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProducerId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Source", b =>
                {
                    b.Property<int>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SourceId"));

                    b.Property<string>("SourceName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SourceId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<int?>("DistrictIdLink")
                        .HasColumnType("int");

                    b.Property<string>("WarehouseName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WarehouseId");

                    b.HasIndex("DistrictIdLink");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Weightsheet", b =>
                {
                    b.Property<long>("WeightSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("WeightSheetId"));

                    b.Property<string>("BillOfLading")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CommodityTypeIdLink")
                        .HasColumnType("int");

                    b.Property<long?>("CommodityVarietyIdLink")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("date");

                    b.Property<string>("Hauler")
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("LotIdLink")
                        .HasColumnType("bigint");

                    b.Property<int?>("Miles")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SourceIdLink")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseIdLink")
                        .HasColumnType("int");

                    b.Property<string>("Weigher")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WeightSheetId");

                    b.HasIndex("CommodityTypeIdLink");

                    b.HasIndex("CommodityVarietyIdLink");

                    b.HasIndex("LotIdLink");

                    b.HasIndex("SourceIdLink");

                    b.HasIndex("WarehouseIdLink");

                    b.ToTable("Weightsheets");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Bin", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityType", "CommodityType")
                        .WithMany()
                        .HasForeignKey("CommodityTypeIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityVariety", "CommodityVariety")
                        .WithMany()
                        .HasForeignKey("CommodityVarietyIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Warehouse", "Warehouse")
                        .WithMany("Bins")
                        .HasForeignKey("WarehouseIdLink");

                    b.Navigation("CommodityType");

                    b.Navigation("CommodityVariety");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.CommodityVariety", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityType", "CommodityType")
                        .WithMany("CommodityVarieties")
                        .HasForeignKey("CommodityTypeIdLink");

                    b.Navigation("CommodityType");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Load", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.Bin", "Bin")
                        .WithMany()
                        .HasForeignKey("BinIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Weightsheet", "Weightsheet")
                        .WithMany("Loads")
                        .HasForeignKey("WeightsheetIdLink");

                    b.Navigation("Bin");

                    b.Navigation("Weightsheet");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Lot", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityType", "CommodityType")
                        .WithMany()
                        .HasForeignKey("CommodityTypeIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityVariety", "CommodityVariety")
                        .WithMany()
                        .HasForeignKey("CommodityVarietyIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Producer", "Producer")
                        .WithMany("Lots")
                        .HasForeignKey("ProducerIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseIdLink");

                    b.Navigation("CommodityType");

                    b.Navigation("CommodityVariety");

                    b.Navigation("Producer");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Warehouse", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.District", "District")
                        .WithMany("Warehouses")
                        .HasForeignKey("DistrictIdLink");

                    b.Navigation("District");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Weightsheet", b =>
                {
                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityType", "CommodityType")
                        .WithMany()
                        .HasForeignKey("CommodityTypeIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.CommodityVariety", "CommodityVariety")
                        .WithMany()
                        .HasForeignKey("CommodityVarietyIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Source", "Source")
                        .WithMany("SourceWeightsheets")
                        .HasForeignKey("SourceIdLink");

                    b.HasOne("WIS_PrototypeAPI.Data.Models.Warehouse", "Warehouse")
                        .WithMany("DestWeightsheets")
                        .HasForeignKey("WarehouseIdLink");

                    b.Navigation("CommodityType");

                    b.Navigation("CommodityVariety");

                    b.Navigation("Lot");

                    b.Navigation("Source");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.CommodityType", b =>
                {
                    b.Navigation("CommodityVarieties");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.District", b =>
                {
                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Producer", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Source", b =>
                {
                    b.Navigation("SourceWeightsheets");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Warehouse", b =>
                {
                    b.Navigation("Bins");

                    b.Navigation("DestWeightsheets");
                });

            modelBuilder.Entity("WIS_PrototypeAPI.Data.Models.Weightsheet", b =>
                {
                    b.Navigation("Loads");
                });
#pragma warning restore 612, 618
        }
    }
}
