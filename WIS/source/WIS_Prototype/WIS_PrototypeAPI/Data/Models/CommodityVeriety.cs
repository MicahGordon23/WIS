using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class CommodityVeriety
	{
		// Primary Key numeric identifier for Commodity Veriety.
		[Key]
		[Required]
		public long CommodityVerietyeId { get; set; }

		// Human understandable identifier for Commodity Type
		[Column(TypeName = "nvarchar(50)")]
		public string? CommodityVerietyName { get; set; } = null;

		// Many to one (child)
		[ForeignKey(nameof(CommodityType))]
		public int? CommodityTypeIdLink { get; set; }

		// many to one (child)
		public CommodityType? CommodityType { get; set; } = null;
	}
}
