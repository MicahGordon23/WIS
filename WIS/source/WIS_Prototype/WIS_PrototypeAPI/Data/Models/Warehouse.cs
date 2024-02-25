// Filename: Warehouse.cs
// Purpose: To define the Warehouse Entity. Warehouse is second highest in data hierarchy.
// Author: Micah Gordon
// Date: 

// Updates: <date>:<change>
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
		// (Weightsheets where the warehouse is the destination)
		public ICollection<Weightsheet>? DestWeightsheets { get; set; } = null;

	}
}
