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
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerId);
                });

            migrationBuilder.CreateTable(
                name: "CommodityVarieties",
                columns: table => new
                {
                    CommodityVarietyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityVarietyName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CommodityTypeIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityVarieties", x => x.CommodityVarietyId);
                    table.ForeignKey(
                        name: "FK_CommodityVarieties_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DistrictIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouses_Districts_DistrictIdLink",
                        column: x => x.DistrictIdLink,
                        principalTable: "Districts",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "Lots",
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
                    CommodityVarietyIdLink = table.Column<long>(type: "bigint", nullable: true),
                    ProducerIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_Lots_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                    table.ForeignKey(
                        name: "FK_Lots_CommodityVarieties_CommodityVarietyIdLink",
                        column: x => x.CommodityVarietyIdLink,
                        principalTable: "CommodityVarieties",
                        principalColumn: "CommodityVarietyId");
                    table.ForeignKey(
                        name: "FK_Lots_Producers_ProducerIdLink",
                        column: x => x.ProducerIdLink,
                        principalTable: "Producers",
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
                    CommodityVarietyIdLink = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_Bins_CommodityVarieties_CommodityVarietyIdLink",
                        column: x => x.CommodityVarietyIdLink,
                        principalTable: "CommodityVarieties",
                        principalColumn: "CommodityVarietyId");
                    table.ForeignKey(
                        name: "FK_Bins_Warehouses_WarehouseIdLink",
                        column: x => x.WarehouseIdLink,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "Weightsheets",
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
                    CommodityVarietyIdLink = table.Column<long>(type: "bigint", nullable: true),
                    LotIdLink = table.Column<long>(type: "bigint", nullable: true),
                    SourceIdLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weightsheets", x => x.WeightSheetId);
                    table.ForeignKey(
                        name: "FK_Weightsheets_CommodityTypes_CommodityTypeIdLink",
                        column: x => x.CommodityTypeIdLink,
                        principalTable: "CommodityTypes",
                        principalColumn: "CommodityTypeId");
                    table.ForeignKey(
                        name: "FK_Weightsheets_CommodityVarieties_CommodityVarietyIdLink",
                        column: x => x.CommodityVarietyIdLink,
                        principalTable: "CommodityVarieties",
                        principalColumn: "CommodityVarietyId");
                    table.ForeignKey(
                        name: "FK_Weightsheets_Lots_LotIdLink",
                        column: x => x.LotIdLink,
                        principalTable: "Lots",
                        principalColumn: "LotId");
                    table.ForeignKey(
                        name: "FK_Weightsheets_Warehouses_SourceIdLink",
                        column: x => x.SourceIdLink,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "Loads",
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
                    WeightsheetIdLink = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.LoadId);
                    table.ForeignKey(
                        name: "FK_Loads_Weightsheets_WeightsheetIdLink",
                        column: x => x.WeightsheetIdLink,
                        principalTable: "Weightsheets",
                        principalColumn: "WeightSheetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bins_CommodityTypeIdLink",
                table: "Bins",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_CommodityVarietyIdLink",
                table: "Bins",
                column: "CommodityVarietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_WarehouseIdLink",
                table: "Bins",
                column: "WarehouseIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityVarieties_CommodityTypeIdLink",
                table: "CommodityVarieties",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_WeightsheetIdLink",
                table: "Loads",
                column: "WeightsheetIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_CommodityTypeIdLink",
                table: "Lots",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_CommodityVarietyIdLink",
                table: "Lots",
                column: "CommodityVarietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ProducerIdLink",
                table: "Lots",
                column: "ProducerIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DistrictIdLink",
                table: "Warehouses",
                column: "DistrictIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheets_CommodityTypeIdLink",
                table: "Weightsheets",
                column: "CommodityTypeIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheets_CommodityVarietyIdLink",
                table: "Weightsheets",
                column: "CommodityVarietyIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheets_LotIdLink",
                table: "Weightsheets",
                column: "LotIdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Weightsheets_SourceIdLink",
                table: "Weightsheets",
                column: "SourceIdLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bins");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "Weightsheets");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "CommodityVarieties");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "CommodityTypes");
        }
    }
}
