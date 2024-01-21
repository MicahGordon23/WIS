using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Warehouse
	{
		// Primary Key numeric identifier for Warehouse.
		[Key]
		[Required]
		public int WarehouseId { get; set; }
		
		// Human understandable identifier for a Warehouse
		[Column(TypeName = "nvarchar(50)")]
		public string? WarehouseName { get; set; } = null;

		// many to one
		[ForeignKey(nameof(District))]
		public int? DistrictIdLink { get; set; }

		public District? District { get; set; } = null;

		// one to many
		public ICollection<Bin>? Bins { get; set; } = null;

		// one to many
		public ICollection<Weightsheet>? Weightsheets { get; set; } = null;
	}
}
