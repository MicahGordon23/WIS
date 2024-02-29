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

		public CommodityType CommodityType { get; set; }

		public CommodityVariety? CommodityVariety { get; set; } = null;

		public int LoadsOnSheet { get; set; }

		public long NetWeight { get; set; }
		
	}
}
