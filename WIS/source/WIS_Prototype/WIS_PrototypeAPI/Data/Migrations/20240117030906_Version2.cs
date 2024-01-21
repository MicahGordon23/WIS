using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIS_PrototypeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Warehouse_WarehouseIdLink",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_Load_Weightsheet_WeightSheetId",
                table: "Load");

            migrationBuilder.DropForeignKey(
                name: "FK_Lot_CommodityTypes_CommodityTypeIdLink",
                table: "Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_Lot_CommodityVerieties_CommodityVerietyIdLink",
                table: "Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_Lot_Producer_ProducerId",
                table: "Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_District_DistrictIdLink",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightsheet_CommodityTypes_CommodityTypeIdLink",
                table: "Weightsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightsheet_CommodityVerieties_CommodityVerietyIdLink",
                table: "Weightsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightsheet_Producer_ProducerIdLink",
                table: "Weightsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightsheet_Warehouse_SourceIdLink",
                table: "Weightsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weightsheet",
                table: "Weightsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producer",
                table: "Producer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lot",
                table: "Lot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Load",
                table: "Load");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "Weightsheet",
                newName: "Weightssheets");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Producer",
                newName: "Producers");

            migrationBuilder.RenameTable(
                name: "Lot",
                newName: "Lots");

            migrationBuilder.RenameTable(
                name: "Load",
                newName: "Loads");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameColumn(
                name: "ProducerIdLink",
                table: "Weightssheets",
                newName: "ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Weightsheet_SourceIdLink",
                table: "Weightssheets",
                newName: "IX_Weightssheets_SourceIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightsheet_ProducerIdLink",
                table: "Weightssheets",
                newName: "IX_Weightssheets_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Weightsheet_CommodityVerietyIdLink",
                table: "Weightssheets",
                newName: "IX_Weightssheets_CommodityVerietyIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightsheet_CommodityTypeIdLink",
                table: "Weightssheets",
                newName: "IX_Weightssheets_CommodityTypeIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_DistrictIdLink",
                table: "Warehouses",
                newName: "IX_Warehouses_DistrictIdLink");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Lots",
                newName: "ProducerIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Lot_ProducerId",
                table: "Lots",
                newName: "IX_Lots_ProducerIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Lot_CommodityVerietyIdLink",
                table: "Lots",
                newName: "IX_Lots_CommodityVerietyIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Lot_CommodityTypeIdLink",
                table: "Lots",
                newName: "IX_Lots_CommodityTypeIdLink");

            migrationBuilder.RenameColumn(
                name: "WeightSheetId",
                table: "Loads",
                newName: "WeightsheetIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Load_WeightSheetId",
                table: "Loads",
                newName: "IX_Loads_WeightsheetIdLink");

            migrationBuilder.AddColumn<int>(
                name: "LotIdLink",
                table: "Weightssheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weightssheets",
                table: "Weightssheets",
                column: "WeightSheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producers",
                table: "Producers",
                column: "ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lots",
                table: "Lots",
                column: "LotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loads",
                table: "Loads",
                column: "LoadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Warehouses_WarehouseIdLink",
                table: "Bins",
                column: "WarehouseIdLink",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Weightssheets_WeightsheetIdLink",
                table: "Loads",
                column: "WeightsheetIdLink",
                principalTable: "Weightssheets",
                principalColumn: "WeightSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_CommodityTypes_CommodityTypeIdLink",
                table: "Lots",
                column: "CommodityTypeIdLink",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_CommodityVerieties_CommodityVerietyIdLink",
                table: "Lots",
                column: "CommodityVerietyIdLink",
                principalTable: "CommodityVerieties",
                principalColumn: "CommodityVerietyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Producers_ProducerIdLink",
                table: "Lots",
                column: "ProducerIdLink",
                principalTable: "Producers",
                principalColumn: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Districts_DistrictIdLink",
                table: "Warehouses",
                column: "DistrictIdLink",
                principalTable: "Districts",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightssheets_CommodityTypes_CommodityTypeIdLink",
                table: "Weightssheets",
                column: "CommodityTypeIdLink",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightssheets_CommodityVerieties_CommodityVerietyIdLink",
                table: "Weightssheets",
                column: "CommodityVerietyIdLink",
                principalTable: "CommodityVerieties",
                principalColumn: "CommodityVerietyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightssheets_Producers_ProducerId",
                table: "Weightssheets",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightssheets_Warehouses_SourceIdLink",
                table: "Weightssheets",
                column: "SourceIdLink",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Warehouses_WarehouseIdLink",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Weightssheets_WeightsheetIdLink",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_CommodityTypes_CommodityTypeIdLink",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_CommodityVerieties_CommodityVerietyIdLink",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Producers_ProducerIdLink",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Districts_DistrictIdLink",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightssheets_CommodityTypes_CommodityTypeIdLink",
                table: "Weightssheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightssheets_CommodityVerieties_CommodityVerietyIdLink",
                table: "Weightssheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightssheets_Producers_ProducerId",
                table: "Weightssheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Weightssheets_Warehouses_SourceIdLink",
                table: "Weightssheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weightssheets",
                table: "Weightssheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producers",
                table: "Producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lots",
                table: "Lots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loads",
                table: "Loads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "LotIdLink",
                table: "Weightssheets");

            migrationBuilder.RenameTable(
                name: "Weightssheets",
                newName: "Weightsheet");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Producers",
                newName: "Producer");

            migrationBuilder.RenameTable(
                name: "Lots",
                newName: "Lot");

            migrationBuilder.RenameTable(
                name: "Loads",
                newName: "Load");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Weightsheet",
                newName: "ProducerIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightssheets_SourceIdLink",
                table: "Weightsheet",
                newName: "IX_Weightsheet_SourceIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightssheets_ProducerId",
                table: "Weightsheet",
                newName: "IX_Weightsheet_ProducerIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightssheets_CommodityVerietyIdLink",
                table: "Weightsheet",
                newName: "IX_Weightsheet_CommodityVerietyIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Weightssheets_CommodityTypeIdLink",
                table: "Weightsheet",
                newName: "IX_Weightsheet_CommodityTypeIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_DistrictIdLink",
                table: "Warehouse",
                newName: "IX_Warehouse_DistrictIdLink");

            migrationBuilder.RenameColumn(
                name: "ProducerIdLink",
                table: "Lot",
                newName: "ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Lots_ProducerIdLink",
                table: "Lot",
                newName: "IX_Lot_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Lots_CommodityVerietyIdLink",
                table: "Lot",
                newName: "IX_Lot_CommodityVerietyIdLink");

            migrationBuilder.RenameIndex(
                name: "IX_Lots_CommodityTypeIdLink",
                table: "Lot",
                newName: "IX_Lot_CommodityTypeIdLink");

            migrationBuilder.RenameColumn(
                name: "WeightsheetIdLink",
                table: "Load",
                newName: "WeightSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_WeightsheetIdLink",
                table: "Load",
                newName: "IX_Load_WeightSheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weightsheet",
                table: "Weightsheet",
                column: "WeightSheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producer",
                table: "Producer",
                column: "ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lot",
                table: "Lot",
                column: "LotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Load",
                table: "Load",
                column: "LoadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Warehouse_WarehouseIdLink",
                table: "Bins",
                column: "WarehouseIdLink",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Load_Weightsheet_WeightSheetId",
                table: "Load",
                column: "WeightSheetId",
                principalTable: "Weightsheet",
                principalColumn: "WeightSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lot_CommodityTypes_CommodityTypeIdLink",
                table: "Lot",
                column: "CommodityTypeIdLink",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lot_CommodityVerieties_CommodityVerietyIdLink",
                table: "Lot",
                column: "CommodityVerietyIdLink",
                principalTable: "CommodityVerieties",
                principalColumn: "CommodityVerietyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lot_Producer_ProducerId",
                table: "Lot",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_District_DistrictIdLink",
                table: "Warehouse",
                column: "DistrictIdLink",
                principalTable: "District",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightsheet_CommodityTypes_CommodityTypeIdLink",
                table: "Weightsheet",
                column: "CommodityTypeIdLink",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightsheet_CommodityVerieties_CommodityVerietyIdLink",
                table: "Weightsheet",
                column: "CommodityVerietyIdLink",
                principalTable: "CommodityVerieties",
                principalColumn: "CommodityVerietyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightsheet_Producer_ProducerIdLink",
                table: "Weightsheet",
                column: "ProducerIdLink",
                principalTable: "Producer",
                principalColumn: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weightsheet_Warehouse_SourceIdLink",
                table: "Weightsheet",
                column: "SourceIdLink",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");
        }
    }
}
