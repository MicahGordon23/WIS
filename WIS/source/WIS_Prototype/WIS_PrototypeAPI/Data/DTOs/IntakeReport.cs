//************************************************
// Filename: IntakeReport.cs
// Purpose: Defines an object which is used to transport Report data from the database.

using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data.DTOs
{
	[Keyless]
	public class IntakeReport
	{
		// Commodity Type
		public int CommodityTypeIdLink { get; set; }
		//public string? CommodityTypeName { get; set; } = null;

		// Commodity Variety
		public long? CommodityVarietyIdLink { get; set; }
		//public string? CommodityVarietyName { get; set; } = null;

		// Producer number
		public int? ProducerIdLink { get; set; }
		// Producer name
		public string? ProducerName { get; set; } = null;

		// Lot number
		public long LotIdLink { get; set; }

		// Weight Sheet number
		public long WeightsheetId { get; set; }

		// lot is open or closed
		public DateTime? EndDate { get; set; } = null;

		// Landlord
		public string? Landlord { get; set; } = null;

		// FSA farm number
		public string? FarmNumber { get; set; } = null;

		// Net (lbs)
		public long NetWeightLbs { get; set; }
	}
}
