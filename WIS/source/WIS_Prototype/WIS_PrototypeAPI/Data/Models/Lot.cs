// Filename: Lot.cs
// Purpose: To define the Lot Entity. The Lot entity links Producers to their weightsheets and there for lots.
// Author: Micah Gordon
// Date: 

// Updates: <date>:<change>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Lot
	{
		[Key]
		[Required]
		public long LotId { get; set; }

		[Column(TypeName = "nvarchar(5)")]
		public string? StateId { get; set; } = null;

		[Column(TypeName = "date")]
		public DateTime? StartDate { get; set; } = null;

		[Column(TypeName = "date")]
		public DateTime? EndDate { get; set; } = null;

		[Column(TypeName = "nvarchar(30)")]
		public string? Landlord { get; set; } = null;
		[Column(TypeName = "nvarchar(30)")]
		public string? FarmNumber { get; set; } = null;
		[Column(TypeName = "nvarchar(200)")]
		public string? Notes { get; set; } = null;

		// Commodity Type
		[ForeignKey(nameof(CommodityType))]
		public int? CommodityTypeIdLink { get; set; }
		public CommodityType? CommodityType { get; set; } = null;

		// Commodity Veriety
		[ForeignKey(nameof(CommodityVariety))]
		public long? CommodityVarietyIdLink { get; set; }
		public CommodityVariety? CommodityVariety { get; set; } = null;

		// Producer
		[ForeignKey(nameof(Producer))]
		public int? ProducerIdLink { get; set; } = null;
		public Producer? Producer { get; set;} = null;

		// Warehouse
		[ForeignKey(nameof(Warehouse))]
		public int? WarehouseIdLink { get; set; } = null;
		public Warehouse? Warehouse { get; set; } = null;
	}
}
