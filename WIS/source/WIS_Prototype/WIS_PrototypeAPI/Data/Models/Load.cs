using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Load
	{
		[Key]
		[Required]
		public long LoadId { get; set; }

		public int? GrossWeight {  get; set; }
		public int? TareWeight { get; set; }
		public int? NetWeight { get; set; }
		[Column(TypeName = "nvarchar(20)")]
		public string? TruckId { get; set; } = null;
		public DateTime? TimeIn { get; set; } = null;
		public DateTime? TimeOut { get; set;} = null;
		[Column(TypeName = "nvarchar(20)")]
		public string? BillOfLading { get; set; } = null;
		public double? MoistureLevel { get; set; }
		public double? TestWeight { get; set; }
		public double? ProtienLevel { get; set; }
		[Column(TypeName = "nvarchar(200)")]
		public string? Notes { get; set; } = null;

		// many to one
		[ForeignKey(nameof(Weightsheet))]
		public long? WeightsheetIdLink { get; set; }
		public Weightsheet? Weightsheet { get; set; } = null;
	}
}
