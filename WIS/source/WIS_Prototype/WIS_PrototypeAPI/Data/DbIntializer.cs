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
			District south = new District();
			south.DistrictName = "South";

			// Warehouse
			Warehouse spofford = new Warehouse();
			spofford.WarehouseName = "Spofford";

			south.Warehouses = new List<Warehouse>();
			south.Warehouses.Add(spofford);

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
			l1.Landlord = "Dennis Rea";
			l1.FarmNumber = "12AB3-123C";
			l1.Notes = "Lot #42";
			l1.CommodityType = softWhiteWheat;
			l1.Producer = ht;

			Lot l2 = new Lot();
			l2.StateId = "OR";
			l2.StartDate = new DateTime(2023, 08, 13);
			l2.Landlord = "Richard F.";
			l2.CommodityType = softWhiteWheat;
			l2.Notes = "Old Pivot";
			l2.Producer = dodge;

			Lot l3 = new Lot();
			l3.StateId = "WA";
			l3.StartDate = new DateTime(2023, 08, 13);
			l3.EndDate = new DateTime(2023, 08, 20);
			l3.CommodityType = greenPeas;
			l3.CommodityVariety = argonPeas;
			l3.Producer = diamondX;

			Lot l4 = new Lot();
			l4.StateId = "WA";
			l4.StartDate = new DateTime(2023, 08, 14);
			l4.EndDate = new DateTime(2023, 08, 16);
			l4.CommodityType = greenPeas;
			l4.CommodityVariety = ginneyPeas;
			l4.Producer = dodge;

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

			w4.Loads = new List<Load>();
			w4.Loads.Add(load5);

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

			Console.Write("Saving...");
			_context.SaveChanges();
		}
	}
}
