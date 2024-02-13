//************************************************
// Filename: IntakeReport.cs
// Purpose: Defines an object which is used to transport Report data from the database.

using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data.DTOs
{
	public class IntakeReport
	{
		// Commodity Type
		public int commodityTypeId { get; set; }
		public string? commodityTypeName { get; set; } = null;

		// Commodity Variety
		public long commodityVarietyId { get; set; }
		public string? commodityVarietyName { get; set; } = null;

		// Producer number
		public int producerId { get; set; }
		// Producer name
		public string? producerName { get; set;} = null;

		// Lot number
		public long lotNumber { get; set; }

		// Weight Sheet number
		public long WeightsheetNumber { get; set; }

		// lot is open or closed
		public bool isClosed { get; set; }

		// Landlord
		public string? landlord { get; set; } = null;

		// FSA farm number
		public string? farmNumber { get; set; } = null;

		// Net (lbs)
		public long netWeightLbs { get; set; }

		// Net UoM (bu or CWT)
		public long netUnitsOfMeasure { get; set; }

		// Sum of Net
		public long sumNet { get; set; }

		// Sum of UoM
		public long sumUnitsOfMeasure { get; set; }
	}
}
