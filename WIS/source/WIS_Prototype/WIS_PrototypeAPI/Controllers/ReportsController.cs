using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.Data.DTOs;

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

		//// GET: api/Reports/Intake
		//[HttpGet("/Intake/{warehouseId}")]
		//public async Task<ActionResult<IntakeReport>> GetIntakeReport(int warehouseId)
		//{
		//	if (_context.Warehouses == null)
		//	{
		//		return NotFound();
		//	}
		//	// Weightsheet where WarehouseIdLink == warehouseId && weightsheet.DateClosed is == DateNow
		//	// Lots Where
		//	IntakeReport intakeReport = new IntakeReport();
		//	var report = await _context.Weightsheets
		//		.Where(Weightsheets => Weightsheets.WarehouseIdLInk == warehouseId && Weightsheets.DateClosed == null)
		//		.ToListAsync();
		//	// Weightsheet had the
		//	// Commodity Type and Variety Id and Name
		//	// Producer Id and Name
		//	// Weightsheet Id
		//	// Lot Id
		//	// Landlord
		//	// FSA 
		//	// Net
		//	// Net UoM


		//}
	}
}
