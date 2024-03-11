namespace WIS_PrototypeAPI.Data.DTOs
{
	public class WeightSheetDto
	{
		public WeightSheetDto() { }

		public long WeightsheetId { get; set; }

		// Weight Sheet Type

		public int SumNumLoads { get; set; }

		public int InYard { get; set; }

		public string? ProducerName { get; set; } = null;

		public string? SourceName { get; set; } = null;

		public string CommodityTypeName { get; set; }

		//public int CommodityTypeId { get; set; }

		public string? CommodityVarietyName { get; set; } = null;

		//public long? CommodityVarietyId { get; set; }

		public long? LotId { get; set; }

		public string? Notes { get; set; } = null;
	}
}
