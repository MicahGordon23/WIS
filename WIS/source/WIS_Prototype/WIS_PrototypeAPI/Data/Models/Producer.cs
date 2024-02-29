using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WIS_PrototypeAPI.Data.Models
{
	public class Producer
	{
		[Key]
		[Required]
		public int ProducerId { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? ProducerName { get; set; }

		// One to Many
		[JsonIgnore]
		public ICollection<Lot>? Lots { get; set; } = null;
	}
}
