using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.Data.DTOs;
using Humanizer;
using NuGet.Packaging.Signing;
using System.Data.Common;

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

		// GET: api/Reports/Intake
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
			// Triple join from Lots (where WarehouseIdLink == wearhouseID) on Weightsheets (Where Date == todays Date) on Loads
			/*	Key Information:
			 *	Purpose of Intake report is to track intake from producers into the warehouse.
			 *	For each Weightsheet:
			 *		Commodity Type, Commodity Variety,
			 *		From Lot: Producer Name, Producer Number, Lot Number, Landlord, FSA Number
			 *		For each Load on weightsheet
			 *			From Load: Net weight per load
			 *	
			 * SELECT Weightsheets.WeightSheetId, SUM(Loads.NetWeight) AS TotalWeight, Weightsheets.DateOpened
			 *	FROM Weightsheets
			 *	INNER JOIN Lots
			 *	ON Lots.LotId = Weightsheets.WeightSheetId
			 *	INNER JOIN Loads
			 *	ON Loads.WeightsheetIdLink = Weightsheets.WeightSheetId
			 *	GROUP BY WeightSheetId, Weightsheets.DateOpened;
			 */

			// I have chosen to ignore the UoM for the moment and abstracted it to just bu for the moment.
			//var intakeReport = from Lots in _context.Set<Lot>()
			//				   join Weightsheets in _context.Set<Weightsheet>()
			//					   on new { Lots.LotId, Weightsheets.LotIdLink } equals new { Lots.WarehouseIdLink,  warehouseIdLink = 1 }

			var today = DateTime.Now.Date;

			var query = from weightsheet in _context.Weightsheets
						join lot in _context.Lots on weightsheet.WeightSheetId equals lot.LotId
						join load in _context.Loads on weightsheet.WeightSheetId equals load.WeightsheetIdLink
						where lot.WarehouseIdLink == warehouseId && weightsheet.DateClosed == today
						group new { weightsheet, load } 
						by new 
						{
							//lot.Producer,
							weightsheet.LotIdLink,
							weightsheet.DateOpened,
							weightsheet.WeightSheetId,
							//weightsheet.CommodityType,
							//weightsheet.CommodityVariety,
							lot.Landlord,
							lot.FarmNumber
						} into grouped
						select new IntakeReport
						{
							//producer = grouped.Key.Producer,
							LotNumber = (long)grouped.Key.LotIdLink,
							WeightsheetId = grouped.Key.WeightSheetId,
							DateLotOpened = (DateTime)grouped.Key.DateOpened,
							//CommodityType = grouped.Key.CommodityType,
							//CommodityVariety = grouped.Key.CommodityVariety,
							Landlord = grouped.Key.Landlord,
							FarmNumber = grouped.Key.FarmNumber,
							NetWeightLbs = (long)grouped.Sum(x => x.load.NetWeight)
						};
			var result = await query.ToListAsync();
			return Ok(result);
		}
	}
}
