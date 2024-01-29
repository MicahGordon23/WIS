using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class CommodityType
	{
		/**********************************************
		* PROPERTIES
		**********************************************/

		// Primary Key numeric identifier for Commodity Type.
		[Key]
		[Required]
		public int CommodityTypeId { get; set; }

		// Human understandable identifier for Commodity Type
		[Column(TypeName = "nvarchar(50)")]
		public string? CommodityTypeName { get; set; } = null;

		// one to many
		public ICollection<CommodityVariety>? CommodityVarieties { get; set; } = null;
	}
}
