using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.Data.DTOs;
using Humanizer;
using NuGet.Packaging.Signing;
using System.Data.Common;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Text.RegularExpressions;

namespace WIS_PrototypeAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ReportsController (AppDbContext context)
		{
			_context = context;
		}

		// GET: api/Reports/Intake/5
		[HttpGet("Intake/{warehouseId}")]
		public async Task<ActionResult<IntakeReport>> GetIntakeReport(int warehouseId)
		{
			// Error checking for missing tables. "should not happen"
			if (_context.Warehouses == null)
			{
				return NotFound();
			}
			if (_context.Lots == null)
			{
				return NotFound();
			}
			if (_context.Weightsheets == null)
			{
				return NotFound();
			}
			if (_context.Loads == null)
			{
				return NotFound();
			}

			// ***************** RAW SQL QUERY *******************************
			// SELECT Weightsheets.WeightSheetId, SUM(Loads.NetWeight) AS TotalWeight, Weightsheets.DateOpened, 
			// Weightsheets.CommodityTypeIdLink, Weightsheets.CommodityVarietyIdLink, Lots.ProducerIdLink, Weightsheets.LotIdLink
			// FROM Weightsheets
			// INNER JOIN Lots
			// ON Lots.LotId = Weightsheets.LotIdLink AND Lots.WarehouseIdLink = warehouseId
			// INNER JOIN Loads
			// ON Loads.WeightsheetIdLink = Weightsheets.WeightSheetId
			// AND Weightsheets.DateOpened = CONVERT(DATE, GETDATE())
			// GROUP BY WeightSheetId, Weightsheets.DateOpened, Weightsheets.CommodityTypeIdLink, Weightsheets.CommodityVarietyIdLink, Weightsheets.LotIdLink, Lots.ProducerIdLink;

			var today = DateTime.Now.Date;
			Console.WriteLine(today);
			var query = from weightsheet in _context.Weightsheets
						join lot in _context.Lots on weightsheet.LotIdLink equals lot.LotId //&& weightsheet.DateOpened == today
						join load in _context.Loads on weightsheet.WeightSheetId equals load.WeightsheetIdLink 
						// Left Join semantics
						into report
						from load in report.DefaultIfEmpty()
						where weightsheet.WarehouseIdLink == warehouseId && weightsheet.DateOpened == today
						group new { weightsheet, load, lot } 
						by new 
						{
							lot.ProducerIdLink,
							weightsheet.LotIdLink,
							//weightsheet.DateOpened, //Assuming weighsheet is closed 
							weightsheet.WeightSheetId,
							weightsheet.CommodityTypeIdLink,
							weightsheet.CommodityVarietyIdLink,
							lot.Landlord,
							lot.FarmNumber,
							lot.EndDate // TO check if lot is closed
						} into grouped
						select new IntakeReport
						{
							ProducerIdLink = (int)grouped.Key.ProducerIdLink,
							LotIdLink = (long)grouped.Key.LotIdLink,
							WeightsheetId = grouped.Key.WeightSheetId,
							EndDate = (DateTime)grouped.Key.EndDate,
							CommodityTypeIdLink = (int)grouped.Key.CommodityTypeIdLink,
							CommodityVarietyIdLink = (int)grouped.Key.CommodityVarietyIdLink,
							Landlord = grouped.Key.Landlord,
							FarmNumber = grouped.Key.FarmNumber,
							NetWeightLbs = (long)grouped.Sum(x => x.load.NetWeight)
						};
			var result = await query.ToListAsync();
			return Ok(result);
		}

		// GET api/Reports/DailyWeightSheet/5
		[HttpGet("Daily/Weightsheet/{warehouseId}")]
		public async Task<ActionResult<WeightSheetReport>> GetDailyWeightSheetReport(int warehouseId)
		{
			var today = DateTime.Now.Date;
			var query = from weightsheets in _context.Weightsheets
						join commodity in _context.CommodityTypes on weightsheets.CommodityTypeIdLink equals commodity.CommodityTypeId
						join variety in _context.CommodityVarieties on weightsheets.CommodityVarietyIdLink equals variety.CommodityVarietyId
						into commodityPair
						from variety in commodityPair.DefaultIfEmpty()
						join load in _context.Loads on weightsheets.WeightSheetId equals load.WeightsheetIdLink
						where weightsheets.WarehouseIdLink == warehouseId && weightsheets.DateOpened == today
						group new { weightsheets, commodity, variety, load }
						by new
						{
							weightsheets.WeightSheetId,
							weightsheets.CommodityTypeIdLink,
							commodity.CommodityTypeName,
							weightsheets.CommodityVarietyIdLink,
							comVarName = variety != null ? variety.CommodityVarietyName : null,

						} into grouped
						select new WeightSheetReport
						{
							WeightsheetId = (long)grouped.Key.WeightSheetId,
							CommodityTypeId = (int)grouped.Key.CommodityTypeIdLink, 
							CommodityTypeName = (string)grouped.Key.CommodityTypeName,
							CommodityVarietyId = (long)grouped.Key.CommodityVarietyIdLink,
							CommodityVarietyName = grouped.Key.comVarName,
							LoadsOnSheet = (int)grouped.Count(),
							NetWeight = (int)grouped.Sum(l => l.load.NetWeight)
						};
			var result = await query.ToListAsync();
			return Ok(result);
		}

		// GET api/Reports/DailyCommodity/5
		[HttpGet("DailyCommodity/{warehouseId}")]
		public async Task<ActionResult<CommodityReport>> GetDailyCommodityReport(int warehouseId)
		{

			// ***************** RAW SQL QUERY *******************************
			// SELECT CommodityTypeName, CommodityVarietyName, Count(Loads.LoadId) As NumLoads
			// FROM Weightsheets
			// INNER JOIN CommodityTypes
			// on CommodityTypes.CommodityTypeId = Weightsheets.CommodityTypeIdLink
			// LEFT JOIN CommodityVarieties
			// on CommodityVarieties.CommodityVarietyId = Weightsheets.CommodityVarietyIdLink
			// LEFT JOIN Loads
			// on Loads.WeightsheetIdLink = WeightSheetId
			// WHERE Weightsheets.WarehouseIdLink = 1 AND Weightsheets.DateOpened = CONVERT(DATE, GETDATE())
			// GROUP BY CommodityTypeName, CommodityVarietyName
			var today = DateTime.Now.Date;
			Console.WriteLine(today);

			var query = from weightSheet in _context.Weightsheets
						join commodityType in _context.CommodityTypes on weightSheet.CommodityTypeIdLink equals commodityType.CommodityTypeId
						join commodityVariety in _context.CommodityVarieties on weightSheet.CommodityVarietyIdLink equals commodityVariety.CommodityVarietyId into varietyGroup
						from variety in varietyGroup.DefaultIfEmpty()
						join load in _context.Loads on weightSheet.WeightSheetId equals load.WeightsheetIdLink into loadGroup
						where weightSheet.WarehouseIdLink == 1 && weightSheet.DateOpened == today
						group new { weightSheet, variety, loadGroup } by new
						{
							commodityType.CommodityTypeName,
							commodityType.CommodityTypeId,
							CommodityVarietyName = variety != null ? variety.CommodityVarietyName : null,
							CommodityVarietyId = variety != null ? (long?)variety.CommodityVarietyId : null
						} into grouped
						select new CommodityReport
						{
							CommodityTypeName = grouped.Key.CommodityTypeName,
							CommodityTypeId = grouped.Key.CommodityTypeId,
							CommodityVarietyName = grouped.Key.CommodityVarietyName,
							CommodityVarietyId = grouped.Key.CommodityVarietyId,
							NumLoads = grouped.SelectMany(g => g.loadGroup).Count()
						};

			var result = await query.ToListAsync();

			return Ok(result);
		}
	}
}
