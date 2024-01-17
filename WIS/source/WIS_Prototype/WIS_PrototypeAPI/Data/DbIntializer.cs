using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data
{
	public class DbIntializer
	{
		private readonly AppDbContext _context;

		public DbIntializer(AppDbContext context) 
		{ 
			_context = context;
		}

		public void Run()
		{
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			Console.WriteLine("Starting Seeding of Database");
			// District
			var testDistrict = _context.Districts.FirstOrDefault(d => d.DistrictId == 1);
			if (testDistrict == null)
			{
				_context.Districts.Add(new District {/* DistrictId = 1,*/ DistrictName = "South" });
			}

			// Warehouse
			var testWarehouse = _context.Warehouses.FirstOrDefault(w => w.WarehouseId == 1);
			if (testWarehouse == null)
			{
				_context.Warehouses.Add(new Warehouse { /*WarehouseId = 1,*/ WarehouseName = "Spofford" });
			}

			// Bin
			var testBin = _context.Bins.FirstOrDefault(b => b.BinId == 1);
			if (testBin == null)
			{
				_context.Bins.Add(new Bin { /*BinId = 1,*/ BinName = "1",/* CommodityTypeIdLink = 1,*/ /*WarehouseIdLink = 1 */});
				_context.Bins.Add(new Bin { /*BinId = 2,*/ BinName = "2", /*CommodityTypeIdLink = 2,*/ /*WarehouseIdLink = 1,*/ /*CommodityVerietyIdLink = 1*/ });
				_context.Bins.Add(new Bin { /*BinId = 3,*/ BinName = "3", /*CommodityTypeIdLink = 2,*/ /*WarehouseIdLink = 1,*/ /*CommodityVerietyIdLink = 2*/ });
				_context.Bins.Add(new Bin { /*BinId = 4,*/ BinName = "Groud Pile", /*CommodityTypeIdLink = 1,*/ /*WarehouseIdLink = 1*/ });
			}

			// Producer
			var testProducer = _context.Producers.FirstOrDefault(p => p.ProducerId == 1);
			if (testProducer == null)
			{
				_context.Producers.Add(new Producer { /*ProducerId = 1,*/ ProducerName = "H.T. Rea Farming Corp" });
				_context.Producers.Add(new Producer { /*ProducerId = 2,*/ ProducerName = "Fogerty" });
				_context.Producers.Add(new Producer { /*ProducerId = 3,*/ ProducerName = "Ferguson Cattle Company" });
			}

			// Commodity Type
			var testCommodityType = _context.CommodityTypes.FirstOrDefault(c => c.CommodityTypeId == 1);
			if (testCommodityType == null)
			{
				_context.CommodityTypes.Add(new CommodityType { /*CommodityTypeId = 1,*/ CommodityTypeName = "Soft White Wheat" });
				_context.CommodityTypes.Add(new CommodityType { /*CommodityTypeId = 2,*/ CommodityTypeName = "Green Peas" });
			}

			// Commodity Veriety
			var testCommodityVeriety = _context.CommodityVerieties.FirstOrDefault(c => c.CommodityVerietyeId == 1);
			if (testCommodityVeriety == null)
			{
				_context.CommodityVerieties.Add(new CommodityVeriety { /*CommodityVerietyeId = 1,*/ CommodityVerietyName = "Ginney", /*CommodityTypeIdLink = 2*/ });
				_context.CommodityVerieties.Add(new CommodityVeriety { /*CommodityVerietyeId = 2,*/ CommodityVerietyName = "Argon", /*CommodityTypeIdLink = 2*/ });
			}

			//// Weightsheet
			//var testWeightsheet = _context.Weightssheets.FirstOrDefault(w => w.WeightSheetId == 1);
			//if (testWeightsheet == null)
			//{
			//	_context.Weightssheets.Add(new Weightsheet
			//	{
			//		//WeightSheetId = 1,
			//		Weigher = "Micah Gordon",
			//		DateOpened = new DateTime(2023, 1, 1),
			//		CommodityTypeIdLink = 1,
			//		LotIdLink = 1
			//	});

			//	_context.Weightssheets.Add(new Weightsheet
			//	{
			//		//WeightSheetId = 2,
			//		Weigher = "Micah Gordon",
			//		DateOpened = new DateTime(2023, 1, 2),
			//		CommodityTypeIdLink = 2,
			//		CommodityVerietyIdLink = 1,
			//		LotIdLink = 2
			//	});

			//	_context.Weightssheets.Add(new Weightsheet
			//	{
			//		//WeightSheetId = 3,
			//		Weigher = "Micah Gordon",
			//		DateOpened = new DateTime(2023, 1, 3),
			//		CommodityTypeIdLink = 2,
			//		CommodityVerietyIdLink = 2,
			//		LotIdLink = 3
			//	});
			//}

			//// Lot
			//var testLot = _context.Lots.FirstOrDefault(l => l.LotId == 1);
			//if (testLot == null)
			//{
			//	_context.Lots.Add(new Lot
			//	{
			//		//LotId = 1,
			//		StateId = "WA",
			//		StartDate = new DateTime(2023, 1, 1),
			//		CommodityTypeIdLink = 1,
			//		ProducerIdLink = 1,
			//	});

			//	_context.Lots.Add(new Lot
			//	{
			//		//LotId = 2,
			//		StateId = "OR",
			//		StartDate = new DateTime(2023, 1, 2),
			//		CommodityTypeIdLink = 2,
			//		CommodityVerietyIdLink = 1,
			//		ProducerIdLink = 2,
			//	});

			//	_context.Lots.Add(new Lot
			//	{
			//		//LotId = 3,
			//		StateId = "OR",
			//		StartDate = new DateTime(2023, 1, 2),
			//		CommodityTypeIdLink = 2,
			//		CommodityVerietyIdLink = 2,
			//		ProducerIdLink = 2,
			//	});
			//}

			//// Load
			//var testLoad = _context.Loads.FirstOrDefault(l => l.LoadId == 1);
			//if (testLoad == null)
			//{
			//	_context.Loads.Add(new Load
			//	{
			//		//LoadId = 1,
			//		GrossWeight = 105000,
			//		TareWeight = 40480,
			//		NetWeight = 64520,
			//		TruckId = "105",
			//		TimeIn = new DateTime(2023, 1, 1, 14, 30, 00),
			//		TimeOut = new DateTime(2023, 1, 1, 14, 38, 00),
			//		MoistureLevel = 9.89,
			//		TestWeight = 59.2,
			//		ProtienLevel = 9.39,
			//		WeightsheetIdLink = 1
			//	});

			//	_context.Loads.Add(new Load
			//	{
			//		//LoadId = 2,
			//		GrossWeight = 101220,
			//		TareWeight = 40480,
			//		NetWeight = 60740,
			//		TruckId = "105",
			//		TimeIn = new DateTime(2023, 1, 1, 15, 30, 00),
			//		TimeOut = new DateTime(2023, 1, 1, 15, 38, 00),
			//		MoistureLevel = 9.89,
			//		TestWeight = 58.2,
			//		ProtienLevel = 9.79,
			//		WeightsheetIdLink = 1
			//	});

			//	_context.Loads.Add(new Load
			//	{
			//		//LoadId = 3,
			//		GrossWeight = 6100,
			//		TareWeight = 2500,
			//		NetWeight = 3600,
			//		TruckId = "117",
			//		TimeIn = new DateTime(2023, 1, 2, 15, 30, 00),
			//		TimeOut = new DateTime(2023, 1, 2, 15, 38, 00),
			//		MoistureLevel = 9.59,
			//		TestWeight = 58.2,
			//		ProtienLevel = 9.19,
			//		WeightsheetIdLink = 2
			//	});

			//	_context.Loads.Add(new Load
			//	{
			//		//LoadId = 4,
			//		GrossWeight = 6100,
			//		TareWeight = 2500,
			//		NetWeight = 3600,
			//		TruckId = "117",
			//		TimeIn = new DateTime(2023, 1, 3, 15, 30, 00),
			//		TimeOut = new DateTime(2023, 1, 3, 15, 38, 00),
			//		MoistureLevel = 8.5,
			//		TestWeight = 64.2,
			//		WeightsheetIdLink = 3
			//	});
			//}

			Console.Write("Saving...");
			_context.SaveChanges();
		}
	}
}
