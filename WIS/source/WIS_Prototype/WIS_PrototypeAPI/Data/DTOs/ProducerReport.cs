using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data.DTOs
{
	public class ProducerReport
	{

		public string ProducerName {get; set;}
		public string DistrictName { get; set; }

		public string WarehouseName { get; set; }

		public string CommodityTypeName { get; set; }

		public string CommodityVarietyName { get; set; }

		public int NetWeightLbs { get; set; }

		public int SumLoads { get; set; }
	}
}
