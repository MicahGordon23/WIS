using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Weightsheet
	{
		[Key]
		[Required]
		public long WeightSheetId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string? Weigher { get; set; } = null;

		[Column(TypeName = "nvarchar(50)")]
		public string? Hauler { get; set; } = null;

		public int? Miles { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string? BillOfLading { get; set; } = null;

		[Column(TypeName = "nvarchar(200)")]
		public string? Notes { get; set; } = null;

		public DateTime? DateOpened { get; set; } = null;

		public DateTime? DateClosed { get; set; } = null; 

		public ICollection<Load>? Loads { get; set; } = null;

		// Commodity Type
		[ForeignKey(nameof(CommodityType))]
		public int? CommodityTypeIdLink { get; set; }

		public CommodityType? CommodityType { get; set; } = null;

		// Commodity Veriety
		[ForeignKey(nameof(CommodityVeriety))]
		public long? CommodityVerietyIdLink { get; set; }

		public CommodityVeriety? CommodityVeriety { get; set; } = null;

		// For Inbound Weightsheet THIS SHOULD BE LOT YOU NERD.
		[ForeignKey(nameof(Lot))]
		public int? LotIdLink { get; set; }

		public Producer? Producer { get; set; }

		// For Transfer Weightsheet
		[ForeignKey(nameof(Warehouse))]
		public int? SourceIdLink { get; set; }

		public Warehouse? Warehouse { get; set; } = null;
	}
}
