namespace WIS_PrototypeAPI.Data.DTOs
{
	public class TransferReport
	{
		public long WeightsheetId { get; set; }
		public string SourceName { get; set; }
		public string CommodityTypeName { get; set; }
		public string CommodityVarietyName { get; set; }
		public int NetWeight { get; set; }
		public int NumLoads { get; set; }
	}
}
