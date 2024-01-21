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

		public DateTime? StartDate { get; set; } = null;

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
	}
}
