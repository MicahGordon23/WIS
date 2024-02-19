﻿using Microsoft.AspNetCore.Http;
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

			// ***************** RAW SQL QUERY *******************************
			// SELECT Weightsheets.WeightSheetId, SUM(Loads.NetWeight) AS TotalWeight, Weightsheets.DateOpened, 
			// Weightsheets.CommodityTypeIdLink, Weightsheets.CommodityVarietyIdLink, Lots.ProducerIdLink, Weightsheets.LotIdLink
			// FROM Weightsheets
			// INNER JOIN Lots
			// ON Lots.LotId = Weightsheets.LotIdLink AND Lots.WarehouseIdLink = 1
			// INNER JOIN Loads
			// ON Loads.WeightsheetIdLink = Weightsheets.WeightSheetId AND Weightsheets.DateOpened = CONVERT(DATE, GETDATE())
			// GROUP BY WeightSheetId, Weightsheets.DateOpened, Weightsheets.CommodityTypeIdLink, Weightsheets.CommodityVarietyIdLink, Weightsheets.LotIdLink, Lots.ProducerIdLink;

			var today = DateTime.Now.Date;

			var query = from weightsheet in _context.Weightsheets
						join lot in _context.Lots on weightsheet.LotIdLink equals lot.LotId
						join load in _context.Loads on weightsheet.WeightSheetId equals load.WeightsheetIdLink
						where lot.WarehouseIdLink == warehouseId && weightsheet.DateClosed == today
						group new { weightsheet, load } 
						by new 
						{
							lot.ProducerIdLink,
							weightsheet.LotIdLink,
							lot.StartDate,
							weightsheet.WeightSheetId,
							weightsheet.CommodityTypeIdLink,
							weightsheet.CommodityVarietyIdLink,
							lot.Landlord,
							lot.FarmNumber
						} into grouped
						select new IntakeReport
						{
							ProducerId = (int)grouped.Key.ProducerIdLink,
							LotNumber = (long)grouped.Key.LotIdLink,
							WeightsheetId = grouped.Key.WeightSheetId,
							DateLotOpened = (DateTime)grouped.Key.StartDate,
							CommodityTypeId = (int)grouped.Key.CommodityTypeIdLink,
							CommodityVarietyId = (int)grouped.Key.CommodityVarietyIdLink,
							Landlord = grouped.Key.Landlord,
							FarmNumber = grouped.Key.FarmNumber,
							NetWeightLbs = (long)grouped.Sum(x => x.load.NetWeight)
						};
			var result = await query.ToListAsync();
			return Ok(result);
		}
	}
}
