//************************************************
// Filename: IntakeReport.cs
// Purpose: Defines an object which is used to transport Report data from the database.

using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;

namespace WIS_PrototypeAPI.Data.DTOs
{
	public class IntakeReport
	{
		//// Commodity Type
		//public int CommodityTypeId { get; set; }
		//public string? CommodityTypeName { get; set; } = null;

		//// Commodity Variety
		//public long CommodityVarietyId { get; set; }
		//public string? CommodityVarietyName { get; set; } = null;

		//// Producer number
		//public int ProducerId { get; set; }
		//// Producer name
		//public string? ProducerName { get; set;} = null;

		public Producer? producer { get; set; }

		// Lot number
		public long LotNumber { get; set; }

		// Weight Sheet number
		public long WeightsheetId { get; set; }

		// lot is open or closed
		public DateTime DateLotOpened{ get; set; }

		// Commodity Type
		public CommodityType? CommodityType { get; set; }

		// Commodity Variety
		public CommodityVariety? CommodityVariety { get; set; }

		// Landlord
		public string? Landlord { get; set; } = null;

		// FSA farm number
		public string? FarmNumber { get; set; } = null;

		// Net (lbs)
		public long NetWeightLbs { get; set; }
	}
}
