using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class District
	{
		// Primary Key numeric identifier for District.
		[Key]
		[Required]
		public int DistrictId { get; set; }

		// Human understandable identifier for District
		[Column(TypeName = "nvarchar(30)")]
		public string? DistrictName { get; set; } = null;

		// List of warehouses in the District. One to many
		public ICollection<Warehouse>? Warehouses { get; set; } = null!;
	}
}
