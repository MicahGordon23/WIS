namespace WIS_PrototypeAPI.Data.DTOs
{
	public class CommodityReport
	{
		public CommodityReport() { }

		public string CommodityTypeName { get; set; }

		public int CommodityTypeId { get; set; }

		public string? CommodityVarietyName { get; set; }

		public long? CommodityVarietyId { get; set; }

		public int NumLoads { get; set; }
	}
}
