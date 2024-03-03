using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class CommodityVariety
	{
		public CommodityVariety() { }
		public CommodityVariety(long commodityVarietyId, string commodityVarietyName)
		{
			CommodityVarietyId = commodityVarietyId;
			CommodityVarietyName = commodityVarietyName;
		}

		// Primary Key numeric identifier for Commodity Veriety.
		[Key]
		[Required]
		public long CommodityVarietyId { get; set; }

		// Human understandable identifier for Commodity Type
		[Column(TypeName = "nvarchar(50)")]
		public string? CommodityVarietyName { get; set; } = null;

		// Many to one (child)
		[ForeignKey(nameof(CommodityType))]
		public int? CommodityTypeIdLink { get; set; }

		// many to one (child)
		public CommodityType? CommodityType { get; set; } = null;
	}
}
