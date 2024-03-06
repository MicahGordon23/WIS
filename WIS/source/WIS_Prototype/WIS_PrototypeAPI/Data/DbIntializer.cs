using System;
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
			//_context.Database.EnsureDeleted();
			//_context.Database.EnsureCreated();
			Console.WriteLine("Starting Seeding of Database");
			// District
			District south = new District();
			south.DistrictName = "South";

			// Warehouse
			Warehouse spofford = new Warehouse();
			spofford.WarehouseName = "Spofford";
			

			south.Warehouses = new List<Warehouse>();
			south.Warehouses.Add(spofford);

			Source wallulla = new Source();
			wallulla.SourceName = "Wallulla";
			Source reser = new Source();
			reser.SourceName = "Reser";
			Source wwSeedPlant = new Source();
			wwSeedPlant.SourceName = "Walla Walla Seed Plant";


			// Commodity Types
			CommodityType softWhiteWheat = new CommodityType();
			softWhiteWheat.CommodityTypeName = "Soft White Wheat";

			CommodityType greenPeas = new CommodityType();
			greenPeas.CommodityTypeName = "Green Pea";

			// Commodity Variety
			CommodityVariety argonPeas = new CommodityVariety();
			argonPeas.CommodityVarietyName = "Argon";
			argonPeas.CommodityType = greenPeas;

			CommodityVariety ginneyPeas = new CommodityVariety();
			ginneyPeas.CommodityVarietyName = "Ginney";
			ginneyPeas.CommodityType = greenPeas;

			greenPeas.CommodityVarieties = new List<CommodityVariety>();
			greenPeas.CommodityVarieties.Add(argonPeas);
			greenPeas.CommodityVarieties.Add(ginneyPeas);

			// Bins
			Bin binOne = new Bin();
			binOne.BinName = "1";
			binOne.CommodityType = softWhiteWheat;
			binOne.Warehouse = spofford;

			Bin binTwo = new Bin();
			binTwo.BinName = "2";
			binTwo.CommodityType = softWhiteWheat;
			binTwo.Warehouse = spofford;

			Bin binThree = new Bin();
			binThree.BinName = "3";
			binThree.CommodityType = greenPeas;
			binThree.CommodityVariety = argonPeas;
			binThree.Warehouse = spofford;

			Bin binFour = new Bin();
			binFour.BinName = "4";
			binFour.CommodityType = greenPeas;
			binFour.CommodityVariety = ginneyPeas;
			binFour.Warehouse = spofford;

			Bin bin20 = new Bin();
			bin20.BinName = "20";
			bin20.CommodityType = softWhiteWheat;
			bin20.Warehouse = spofford;

			Bin groundPile = new Bin();
			groundPile.BinName = "Ground Pile";
			groundPile.CommodityType = softWhiteWheat;
			groundPile.Warehouse = spofford;

			// Adding bins to warehouse
			spofford.Bins = new List<Bin>();
			spofford.Bins.Add(binOne);
			spofford.Bins.Add(binTwo);
			spofford.Bins.Add(binThree);
			spofford.Bins.Add(binFour);
			spofford.Bins.Add(groundPile);

			// Producer
			Producer ht = new Producer();
			ht.ProducerName = "H.T. Rea Farming Corp";

			Producer dodge = new Producer();
			dodge.ProducerName = "Dodge Cattle Co.";

			Producer diamondX = new Producer();
			diamondX.ProducerName = "Diamond X L.L.C.";

			// Lot
			Lot l1 = new Lot();
			l1.StateId = "WA";
			l1.StartDate = new DateTime(2023, 08, 12);
			l1.EndDate = new DateTime(2023, 08, 12);
			l1.Landlord = "Dennis Rea";
			l1.FarmNumber = "12AB3-123C";
			l1.Notes = "Lot #42";
			l1.CommodityType = softWhiteWheat;
			l1.Producer = ht;
			l1.Warehouse = spofford;

			Lot l2 = new Lot();
			l2.StateId = "OR";
			l2.StartDate = new DateTime(2023, 08, 13);
			l2.EndDate = new DateTime(2023, 08, 25);
			l2.Landlord = "Richard F.";
			l2.CommodityType = softWhiteWheat;
			l2.Notes = "Old Pivot";
			l2.Producer = dodge;
			l2.Warehouse = spofford;

			Lot l3 = new Lot();
			l3.StateId = "WA";
			l3.StartDate = new DateTime(2023, 08, 13);
			l3.EndDate = new DateTime(2023, 08, 20);
			l3.CommodityType = greenPeas;
			l3.CommodityVariety = argonPeas;
			l3.Producer = diamondX;
			l3.Warehouse = spofford;

			Lot l4 = new Lot();
			l4.StateId = "WA";
			l4.StartDate = new DateTime(2023, 08, 14);
			l4.EndDate = new DateTime(2023, 08, 16);
			l4.CommodityType = greenPeas;
			l4.CommodityVariety = ginneyPeas;
			l4.Producer = dodge;
			l4.Warehouse = spofford;

			// Adding Lots to Producers.
			ht.Lots = new List<Lot>();
			ht.Lots.Add(l1);

			dodge.Lots = new List<Lot>();
			dodge.Lots.Add(l2);
			dodge.Lots.Add(l4);

			diamondX.Lots = new List<Lot>();
			diamondX.Lots.Add(l3);

			// Weightsheets
			Weightsheet w1 = new Weightsheet();
			w1.Weigher = "Micah Gordon";
			w1.DateOpened = new DateTime(2023, 08, 12);
			w1.CommodityType = softWhiteWheat;
			w1.Lot = l1;
			w1.Warehouse = spofford;

			Weightsheet w2 = new Weightsheet();
			w2.Weigher = "Joshua Walling";
			w2.DateOpened = new DateTime(2023, 08, 13);
			w2.CommodityType = softWhiteWheat;
			w2.Lot = l2;
			w2.Warehouse = spofford;

			Weightsheet w3 = new Weightsheet();
			w3.Weigher = "Joshua Walling";
			w3.DateOpened = new DateTime(2023, 08, 13);
			w3.CommodityType = greenPeas;
			w3.CommodityVariety = argonPeas;
			w3.Lot = l3;
			w3.Warehouse = spofford;

			Weightsheet w4 = new Weightsheet();
			w4.Weigher = "Micah Gordon";
			w4.DateOpened = new DateTime(2023, 08, 14);
			w4.CommodityType = greenPeas;
			w4.CommodityVariety = ginneyPeas;
			w4.Lot = l4;
			w4.Warehouse = spofford;

			spofford.DestWeightsheets = new List<Weightsheet>();
			spofford.DestWeightsheets.Add(w1);
			spofford.DestWeightsheets.Add(w2);
			spofford.DestWeightsheets.Add(w3);
			spofford.DestWeightsheets.Add(w4);

			// Loads
			Load load1 = new Load();
			load1.GrossWeight = 105820;
			load1.TareWeight = 34560;
			load1.NetWeight = load1.GrossWeight - load1.TareWeight;
			load1.TruckId = "120";
			load1.TimeIn = new DateTime(2023, 08, 12, 14, 30, 00);
			load1.TimeOut = new DateTime(2023, 08, 12, 14, 36, 00);
			load1.MoistureLevel = 10.4;
			load1.TestWeight = 59.5;
			load1.ProtienLevel = 9.58;
			load1.Weightsheet = w1;
			load1.Bin = binTwo;

			Load load2 = new Load();
			load2.GrossWeight = 101280;
			load2.TareWeight = 34560;
			load2.NetWeight = load2.GrossWeight - load2.TareWeight;
			load2.TruckId = "120";
			load2.TimeIn = new DateTime(2023, 08, 12, 15, 3, 00);
			load2.TimeOut = new DateTime(2023, 08, 12, 15, 26, 00);
			load2.MoistureLevel = 7.4;
			load2.TestWeight = 58.9;
			load2.ProtienLevel = 10.25;
			load2.Weightsheet = w1;
			load2.Bin = binOne;

			w1.Loads = new List<Load>();
			w1.Loads.Add(load1);
			w1.Loads.Add(load2);

			Load load3 = new Load();
			load3.GrossWeight = 36880;
			load3.TareWeight = 26020;
			load3.NetWeight = load3.GrossWeight - load3.TareWeight;
			load3.TruckId = "13";
			load3.TimeIn = new DateTime(2023, 08, 13, 15, 3, 00);
			load3.TimeOut = new DateTime(2023, 08, 13, 15, 26, 00);
			load3.MoistureLevel = 7.4;
			load3.TestWeight = 58.9;
			load3.ProtienLevel = 10.25;
			load3.Weightsheet = w2;
			load3.Bin = binThree;

			w2.Loads = new List<Load>();
			w2.Loads.Add(load3);

			Load load4 = new Load();
			load4.GrossWeight = 36880;
			load4.TareWeight = 26020;
			load4.NetWeight = load4.GrossWeight - load4.TareWeight;
			load4.TruckId = "13";
			load4.TimeIn = new DateTime(2023, 08, 13, 18, 48, 00);
			load4.TimeOut = new DateTime(2023, 08, 13, 18, 53, 00);
			load4.MoistureLevel = 9.12;
			load4.TestWeight = 64.1;
			load4.Weightsheet = w3;
			load4.Bin = bin20;

			w3.Loads = new List<Load>();
			w3.Loads.Add(load4);

			Load load5 = new Load();
			load5.GrossWeight = 108240;
			load5.TareWeight = 38220;
			load5.NetWeight = load4.GrossWeight - load4.TareWeight;
			load5.TruckId = "73D";
			load5.TimeIn = new DateTime(2023, 08, 14, 15, 3, 00);
			load5.TimeOut = new DateTime(2023, 08, 14, 15, 26, 00);
			load5.MoistureLevel = 9.12;
			load5.TestWeight = 63.32;
			load5.Weightsheet = w4;
			load5.Bin = groundPile;

			w4.Loads = new List<Load>();
			w4.Loads.Add(load5);

			//***********************************
			// Lots, Weightsheets, and Loads which are all set for DateTime Now.
			// Purpose: Allow for test ability of report generation.

			// Lot 1 Most complex all data entered.
			Lot reportLot1 = new Lot();
			reportLot1.StateId = "WA";
			// Start date of now
			reportLot1.StartDate = System.DateTime.Now;
			// End date of now + 3 hours
			reportLot1.EndDate = System.DateTime.Now.AddHours(4.0);
			reportLot1.Landlord = "Bobby";
			reportLot1.FarmNumber = "1A2C";
			reportLot1.Notes = "Lot #67";
			reportLot1.CommodityType = softWhiteWheat;
			reportLot1.Producer = ht;
			reportLot1.Warehouse = spofford;
			// Weightsheet
			Weightsheet wsRL1 = new Weightsheet();
			wsRL1.Weigher = "John Doe";
			wsRL1.Hauler = "Bechinor";
			wsRL1.Miles = 3;
			wsRL1.BillOfLading = "12423s";
			wsRL1.Notes = "In till late";
			wsRL1.DateOpened = System.DateTime.Now;
			wsRL1.DateClosed = System.DateTime.Now.AddHours(2.0);
			wsRL1.CommodityType = softWhiteWheat;
			wsRL1.Warehouse = spofford;
			wsRL1.Lot = reportLot1;
			// Load
			Load loadWsRL1 = new Load();
			loadWsRL1.GrossWeight = 240000;
			loadWsRL1.TareWeight = 20400;
			loadWsRL1.NetWeight = loadWsRL1.GrossWeight - loadWsRL1.TareWeight;
			loadWsRL1.TruckId = "47B";
			loadWsRL1.TimeIn = System.DateTime.Now;
			loadWsRL1.TimeOut = System.DateTime.Now.AddMinutes(15.0);
			loadWsRL1.BillOfLading = "A123-482";
			loadWsRL1.MoistureLevel = 7.9;
			loadWsRL1.TestWeight = 57.2;
			loadWsRL1.ProtienLevel = 11.3;
			loadWsRL1.Notes = "A load has come in";
			loadWsRL1.Bin = binOne;
			// Load
			Load loadWsRL2 = new Load();
			loadWsRL2.GrossWeight = 246080;
			loadWsRL2.TareWeight = 20400;
			loadWsRL2.NetWeight = loadWsRL2.GrossWeight - loadWsRL2.TareWeight;
			loadWsRL2.TruckId = "47";
			loadWsRL2.TimeIn = System.DateTime.Now.AddMinutes(20.0);
			loadWsRL2.TimeOut = System.DateTime.Now.AddMinutes(25.0);
			loadWsRL2.BillOfLading = "A123-483";
			loadWsRL2.MoistureLevel = 7.5;
			loadWsRL2.TestWeight = 57.8;
			loadWsRL2.ProtienLevel = 10.4;
			loadWsRL2.Notes = "A load has come in";
			loadWsRL2.Bin = binOne;
			// Add loads to weightsheet.
			wsRL1.Loads = new List<Load>();
			wsRL1.Loads.Add(loadWsRL1);
			wsRL1.Loads.Add(loadWsRL2);

			// Weightsheet
			Weightsheet wsRL2 = new Weightsheet();
			wsRL2.Weigher = "John Doe";
			wsRL2.Hauler = "Bechinor";
			wsRL2.Miles = 3;
			wsRL2.BillOfLading = "12423s";
			wsRL2.Notes = "In till late";
			wsRL2.DateOpened = System.DateTime.Now.AddHours(2.0);
			wsRL2.DateClosed = System.DateTime.Now.AddHours(2.0);
			wsRL2.CommodityType = softWhiteWheat;
			wsRL2.Warehouse = spofford;
			wsRL2.Lot = reportLot1;
			// Load
			Load loadWsRL3 = new Load();
			loadWsRL3.GrossWeight = 240500;
			loadWsRL3.TareWeight = 20400;
			loadWsRL3.NetWeight = loadWsRL3.GrossWeight - loadWsRL3.TareWeight;
			loadWsRL3.TruckId = "103";
			loadWsRL3.TimeIn = System.DateTime.Now;
			loadWsRL3.TimeOut = System.DateTime.Now.AddMinutes(15.0);
			loadWsRL3.BillOfLading = "A123-482";
			loadWsRL3.MoistureLevel = 7.9;
			loadWsRL3.TestWeight = 57.2;
			loadWsRL3.ProtienLevel = 11.3;
			loadWsRL3.Notes = "A load has come in";
			loadWsRL3.Bin = binOne;
			loadWsRL3.Weightsheet = wsRL2;
			// Load
			Load loadWsRL4 = new Load();
			loadWsRL4.GrossWeight = 240500;
			loadWsRL4.TareWeight = 20400;
			loadWsRL4.NetWeight = loadWsRL4.GrossWeight - loadWsRL4.TareWeight;
			loadWsRL4.TruckId = "142B";
			loadWsRL4.TimeIn = System.DateTime.Now;
			loadWsRL4.TimeOut = System.DateTime.Now.AddMinutes(15.0);
			loadWsRL4.BillOfLading = "A123-482";
			loadWsRL4.MoistureLevel = 7.9;
			loadWsRL4.TestWeight = 57.2;
			loadWsRL4.ProtienLevel = 11.3;
			loadWsRL4.Notes = "A load has come in";
			loadWsRL4.Bin = binOne;
			loadWsRL4.Weightsheet = wsRL2;

			// Lot 2 Basic
			Lot reportLot2 = new Lot();
			reportLot2.StateId = "WA";
			// Start date of now
			reportLot2.StartDate = System.DateTime.Now;
			// End date of now + 3 hours
			//reportLot2.EndDate = System.DateTime.Now.AddHours(4.0);
			reportLot2.CommodityType = greenPeas;
			reportLot2.CommodityVariety = argonPeas;
			reportLot2.Producer = ht;
			reportLot2.Warehouse = spofford;
			// Weightsheet
			Weightsheet wsRL3 = new Weightsheet();
			wsRL3.DateOpened = System.DateTime.Now.AddHours(4.0);
			wsRL3.DateClosed = System.DateTime.Now.AddHours(6.0);
			wsRL3.Weigher = "Jill Doe";
			wsRL3.CommodityType = greenPeas;
			wsRL3.CommodityVariety = argonPeas;
			wsRL3.Warehouse = spofford;
			wsRL3.Lot = reportLot2;
			// Load
			Load loadWsRL5 = new Load();
			loadWsRL5.GrossWeight = 80500;
			loadWsRL5.TareWeight = 36000;
			loadWsRL5.NetWeight = loadWsRL5.GrossWeight - loadWsRL5.TareWeight;
			loadWsRL5.TruckId = "14";
			loadWsRL5.TimeIn = System.DateTime.Now.AddHours(4.0);
			loadWsRL5.TimeOut = System.DateTime.Now.AddMinutes(255.0);
			loadWsRL5.MoistureLevel = 7.9;
			loadWsRL5.TestWeight = 57.2;
			loadWsRL5.Bin = binThree;
			loadWsRL5.Weightsheet = wsRL3;
			// Load
			Load loadWsRL6 = new Load();
			loadWsRL6.GrossWeight = 81500;
			loadWsRL6.TareWeight = 36070;
			loadWsRL6.NetWeight = loadWsRL5.GrossWeight - loadWsRL5.TareWeight;
			loadWsRL6.TruckId = "14";
			loadWsRL6.TimeIn = System.DateTime.Now.AddHours(4.5);
			loadWsRL6.TimeOut = System.DateTime.Now.AddMinutes(285.0);
			loadWsRL6.MoistureLevel = 7.9;
			loadWsRL6.TestWeight = 57.2;
			loadWsRL6.Bin = binThree;
			loadWsRL6.Weightsheet = wsRL3;
			// Load
			Load loadWsRL7 = new Load();
			loadWsRL7.GrossWeight = 81500;
			loadWsRL7.TareWeight = 36070;
			loadWsRL7.NetWeight = loadWsRL5.GrossWeight - loadWsRL5.TareWeight;
			loadWsRL7.TruckId = "14";
			loadWsRL7.TimeIn = System.DateTime.Now.AddHours(4.5);
			loadWsRL7.TimeOut = System.DateTime.Now.AddMinutes(285.0);
			loadWsRL7.MoistureLevel = 7.9;
			loadWsRL7.TestWeight = 57.2;
			loadWsRL7.ProtienLevel = 11.3;
			loadWsRL7.Bin = binThree;
			loadWsRL6.Weightsheet = wsRL3;

			wsRL3.Loads = new List<Load>();
			wsRL3.Loads.Add(loadWsRL5);
			wsRL3.Loads.Add(loadWsRL6);
			wsRL3.Loads.Add(loadWsRL7);


			// Lot 3 Basic
			Lot reportLot3 = new Lot();
			reportLot3.StateId = "WA";
			// Start date of now
			reportLot3.StartDate = System.DateTime.Now;
			// End date of now + 3 hours
			reportLot3.EndDate = System.DateTime.Now.AddHours(4.0);
			reportLot3.CommodityType = greenPeas;
			reportLot3.CommodityVariety = ginneyPeas;
			reportLot3.Producer = ht;
			reportLot3.Warehouse = spofford;
			// Weightsheet
			// Load
			// Load

			// Add to all contexts
			_context.Districts.Add(south);
			_context.Warehouses.Add(spofford);
			_context.CommodityTypes.Add(softWhiteWheat);
			_context.CommodityTypes.Add(greenPeas);
			_context.CommodityVarieties.Add(ginneyPeas);
			_context.CommodityVarieties.Add(argonPeas);
			_context.Bins.Add(binOne);
			_context.Bins.Add(binTwo);
			_context.Bins.Add(binThree);
			_context.Bins.Add(binFour);
			_context.Bins.Add(groundPile);
			_context.Producers.Add(ht);
			_context.Producers.Add(dodge);
			_context.Producers.Add(diamondX);
			_context.Lots.Add(l1);
			_context.Lots.Add(l2);
			_context.Lots.Add(l3);
			_context.Lots.Add(l4);
			_context.Weightsheets.Add(w1);
			_context.Weightsheets.Add(w2);
			_context.Weightsheets.Add(w3);
			_context.Weightsheets.Add(w4);
			_context.Loads.Add(load1);
			_context.Loads.Add(load2);
			_context.Loads.Add(load3);
			_context.Loads.Add(load4);

			_context.Lots.Add(reportLot1);
			_context.Weightsheets.Add(wsRL1);
			_context.Loads.Add(loadWsRL1);
			_context.Loads.Add(loadWsRL2);
			_context.Weightsheets.Add(wsRL2);
			_context.Loads.Add(loadWsRL3);
			_context.Loads.Add(loadWsRL4);

			_context.Lots.Add(reportLot2);
			_context.Weightsheets.Add(wsRL3);
			_context.Loads.Add(loadWsRL5);
			_context.Loads.Add(loadWsRL6);
			_context.Loads.Add(loadWsRL7);

			_context.SaveChanges();
		}
	}
}
