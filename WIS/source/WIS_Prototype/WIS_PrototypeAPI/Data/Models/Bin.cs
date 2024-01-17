using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Bin
	{
		/**********************************************
		* PROPERTIES
		**********************************************/

		// Primary Key numeric identifier for Bin.
		[Key]
		[Required]
		public int BinId { get; set; }

		// Human understandable identfier for the Bin
		[Column(TypeName = "nvarchar(50)")]
		public string? BinName { get; set; } = null;

		public int? NetIntake { get; set; }

		// many to one (child)
		[ForeignKey(nameof(Warehouse))]
		public int? WarehouseIdLink { get; set; }

		// many to one (child)
		public Warehouse? Warehouse { get; set; } = null;

		// one to one
		[ForeignKey(nameof(CommodityType))]

		public int? CommodityTypeIdLink { get; set; }

		public CommodityType? CommodityType { get; set; } = null;

		// one to one 
		[ForeignKey(nameof(CommodityVeriety))]
		public long? CommodityVerietyIdLink { get; set; }

		public CommodityVeriety? CommodityVeriety { get; set; } = null;	
	}
}
