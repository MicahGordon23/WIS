//************************************************
// Filename: WeightSheetReport.cs
// Purpose: Defines an object which is used to transport Weight Sheet Report data from the database.
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.Data.DTOs;

namespace WIS_PrototypeAPI.Data.DTOs
{
	public class WeightSheetReport
	{
		public WeightSheetReport() { }

		public long WeightsheetId { get; set; }

		public int CommodityTypeId {get; set;}

		public string CommodityTypeName { get; set; }

		public long? CommodityVarietyId { get; set; }

		public string? CommodityVarietyName { get; set; } = null;

		public int LoadsOnSheet { get; set; }

		public long NetWeight { get; set; }
		
	}
}
