// Filename: Weightsheet.cs
// Purpose: To define the Weightsheet Entity. Links Warehouses To Loads and loads to Commodity Types
//		and Varieties. Can link lot, and therefore producers, to loads and the warehouse to which
//		the loads were delivered.
// Author: Micah Gordon
// Date: 

// Updates: <date>:<change>
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
		[ForeignKey(nameof(CommodityVariety))]
		public long? CommodityVarietyIdLink { get; set; }

		public CommodityVariety? CommodityVariety { get; set; } = null;

		// Links to the Warehouse where the loads on the weight sheets are deposited.
		// used for all weight sheets
		[ForeignKey(nameof(Warehouse))]
		public int? WarehouseIdLink { get; set; }
		public Warehouse? Warehouse { get; set; } = null;

		// Links to a lot.
		// For Inbound Weight Sheets
		[ForeignKey(nameof(Lot))]
		public long? LotIdLink { get; set; }
		public Lot? Lot { get; set; }

		// Links to Source
		[ForeignKey(nameof(Source))]
		// For Transfer Weight Sheets
		public int? SourceIdLink { get; set; }
		public Source? Source { get; set; }
	}
}
