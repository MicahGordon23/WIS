// Filename: LotDto.cs
// Purpose: Allow for usability of edit functionality.
// Author: Micah Gordon
// Date: 02/27/2024

// Updates: <date>:<change>
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data.DTOs
{
	[Keyless]
	public class LotDto
	{
		public long LotId { get; set; }

		public string? StateId { get; set; } = null;

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; } = null;

		public string? Landlord { get; set; } = null;

		public string? FarmNumber { get; set; } = null;

		public string? Notes { get; set; } = null;

		public int CommodityTypeId { get; set; }
		public string? CommodityTypeName { get; set; } = null;
		

		public long? CommodityVarietyId { get; set; }
		public string? CommodityVarietyName { get; set; } = null;

		public int ProducerId { get; set; }
		public string? ProducerName { get; set; } = null;	
	}
}
