using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIS_PrototypeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommodityTypes",
                columns: table => new
                {
                    CommodityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityTypeName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityTypes", x => x.CommodityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerId);
                });

            migrationBuilder.CreateTable(
                name: "CommodityVerieties",
                columns: table => new
                {
                    CommodityVerietyeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityVerietyName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CommodityTypeIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityVerieties", x => x.CommodityVerietyeId);
                    table.ForeignKey(
                        name: "FK_CommodityVerieties_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DistrictIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_District_DistrictIdLink",
                        column: x => x.DistrictIdLink,
                        principalTable: "District",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    LotId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Landlord = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    FarmNumber = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CommodityTypeIdLink = table.Column<int>(type: "int", nullable: true),
                    CommodityVerietyIdLink = table.Column<long>(type: "bigint", nullable: true),
                    ProducerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_Lot_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                    table.ForeignKey(
                        name: "FK_Lot_CommodityVerieties_CommodityVerietyIdLink",
                        column: x => x.CommodityVerietyIdLink,
                        principalTable: "CommodityVerieties",
                        principalColumn: "CommodityVerietyeId");
                    table.ForeignKey(
                        name: "FK_Lot_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "ProducerId");
                });

            migrationBuilder.CreateTable(
                name: "Bins",
                columns: table => new
                {
                    BinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NetIntake = table.Column<int>(type: "int", nullable: true),
                    WarehouseIdLink = table.Column<int>(type: "int", nullable: true),
                    CommodityTypeIdLink = table.Column<int>(type: "int", nullable: true),
                    CommodityVerietyIdLink = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bins", x => x.BinId);
                    table.ForeignKey(
                        name: "FK_Bins_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                    table.ForeignKey(
                        name: "FK_Bins_CommodityVerieties_CommodityVerietyIdLink",
                        column: x => x.CommodityVerietyIdLink,
                        principalTable: "CommodityVerieties",
                        principalColumn: "CommodityVerietyeId");
                    table.ForeignKey(
                        name: "FK_Bins_Warehouse_WarehouseIdLink",
                        column: x => x.WarehouseIdLink,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "Weightsheet",
                columns: table => new
                {
                    WeightSheetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weigher = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Hauler = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Miles = table.Column<int>(type: "int", nullable: true),
                    BillOfLading = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommodityTypeIdLink = table.Column<int>(type: "int", nullable: true),
                    CommodityVerietyIdLink = table.Column<long>(type: "bigint", nullable: true),
                    ProducerIdLink = table.Column<int>(type: "int", nullable: true),
                    SourceIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weightsheet", x => x.WeightSheetId);
                    table.ForeignKey(
                        name: "FK_Weightsheet_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                    table.ForeignKey(
                        name: "FK_Weightsheet_CommodityVerieties_CommodityVerietyIdLink",
                        column: x => x.CommodityVerietyIdLink,
                        principalTable: "CommodityVerieties",
                        principalColumn: "CommodityVerietyeId");
                    table.ForeignKey(
                        name: "FK_Weightsheet_Producer_ProducerIdLink",
                        column: x => x.ProducerIdLink,
                        principalTable: "Producer",
                        principalColumn: "ProducerId");
                    table.ForeignKey(
                        name: "FK_Weightsheet_Warehouse_SourceIdLink",
                        column: x => x.SourceIdLink,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "Load",
                columns: table => new
                {
                    LoadId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrossWeight = table.Column<int>(type: "int", nullable: true),
                    TareWeight = table.Column<int>(type: "int", nullable: true),
                    NetWeight = table.Column<int>(type: "int", nullable: true),
                    TruckId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillOfLading = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MoistureLevel = table.Column<double>(type: "float", nullable: true),
                    TestWeight = table.Column<double>(type: "float", nullable: true),
                    ProtienLevel = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    WeightSheetId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Load", x => x.LoadId);
                    table.ForeignKey(
                        name: "FK_Load_Weightsheet_WeightSheetId",
                        column: x => x.WeightSheetId,
                        principalTable: "Weightsheet",
                        principalColumn: "WeightSheetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bins_CommodityTypeIdLink",
                table: "Bins",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_CommodityVerietyIdLink",
                table: "Bins",
                column: "CommodityVerietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_WarehouseIdLink",
                table: "Bins",
                column: "WarehouseIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityVerieties_CommodityTypeIdLink",
                table: "CommodityVerieties",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Load_WeightSheetId",
                table: "Load",
                column: "WeightSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_CommodityTypeIdLink",
                table: "Lot",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_CommodityVerietyIdLink",
                table: "Lot",
                column: "CommodityVerietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_ProducerId",
                table: "Lot",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_DistrictIdLink",
                table: "Warehouse",
                column: "DistrictIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheet_CommodityTypeIdLink",
                table: "Weightsheet",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheet_CommodityVerietyIdLink",
                table: "Weightsheet",
                column: "CommodityVerietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheet_ProducerIdLink",
                table: "Weightsheet",
                column: "ProducerIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheet_SourceIdLink",
                table: "Weightsheet",
                column: "SourceIdLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bins");

            migrationBuilder.DropTable(
                name: "Load");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Weightsheet");

            migrationBuilder.DropTable(
                name: "CommodityVerieties");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "CommodityTypes");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}
