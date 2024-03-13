namespace WIS_PrototypeAPI.Data.DTOs
{
	public class WeightSheetDtoLite
	{
		public long WeightsheetId { get; set; }

		public string? ProducerName { get; set; } = null;

		public string? SourceName { get; set; } = null;

		public string CommodityTypeName { get; set; }

		public string? CommodityVarietyName { get; set; } = null;

		public long? LotId { get; set; }

		public string? Notes { get; set; } = null;

		public int SumLoads { get; set; }

		public long NetWeight { get; set; }
	}
}
