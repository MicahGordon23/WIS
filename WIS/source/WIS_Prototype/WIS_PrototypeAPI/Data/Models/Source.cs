// Filename: Source.cs
// Purpose: To define the Source Entity for Transfer Weight Sheets
// Author: Micah Gordon
// Date: 02/13/2024

// Updates: <date>:<change>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Source
	{
		// Primary Key numeric identifier for Warehouse.
		[Key]
		[Required]
		public int SourceId { get; set; }

		// Human understandable identifier for a Warehouse
		[Column(TypeName = "nvarchar(50)")]
		public string? SourceName { get; set; } = null;

		// one to many
		// (Weightsheets where the source is the source in transfer weightsheet)
		public ICollection<Weightsheet>? SourceWeightsheets { get; set; } = null;
	}
}
