using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.Data.DTOs;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightsheetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WeightsheetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Weightsheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weightsheet>>> GetWeightsheets()
        {
            if (_context.Weightsheets == null)
            {
                return NotFound();
            }
            return await _context.Weightsheets.ToListAsync();
        }

		/****************** RAW QUERY ****************
        SELECT 
        WeightSheetId, CommodityTypes.CommodityTypeName, CommodityVarieties.CommodityVarietyName,
        Producers.ProducerName, Weightsheets.Notes, Lots.LotId
        ,Count(Loads.LoadId) AS SumLoads,COUNT(CASE WHEN Loads.TimeIn IS NOT Null AND Loads.TimeOut IS NULL Then 1 END) As InLot
        FROM Weightsheets
        INNER JOIN CommodityTypes
        ON CommodityTypeId = Weightsheets.CommodityTypeIdLink
        LEFT JOIN CommodityVarieties
        ON CommodityVarietyId = Weightsheets.CommodityVarietyIdLink
        LEFT JOIN Loads
        ON Loads.WeightsheetIdLink = WeightSheetId
        LEFT JOIN Lots
        ON LotId = Weightsheets.LotIdLink
        LEFT JOIN Producers
        ON ProducerId = Lots.ProducerIdLink
        WHERE Weightsheets.WarehouseIdLink = 1 AND Weightsheets.DateClosed IS NULL AND Weightsheets.DateOpened = CONVERT(DATE, GETDATE())
        GROUP BY
        WeightSheetId, CommodityTypes.CommodityTypeName, CommodityVarieties.CommodityVarietyName,
        Producers.ProducerName, Weightsheets.Notes, Lots.LotId
        */
		// GET: api/Weightsheet
		[HttpGet("Overview/{warehouseId}")]
        public async Task<ActionResult<WeightSheetDto>> GetAllOpenWeightSheets(int warehouseId)
        {
			//var today = DateTime.Now.Date;
			var result = from weightSheet in _context.Weightsheets
						 join commodityType in _context.CommodityTypes on weightSheet.CommodityTypeIdLink equals commodityType.CommodityTypeId
						 join commodityVariety in _context.CommodityVarieties on weightSheet.CommodityVarietyIdLink equals commodityVariety.CommodityVarietyId into cvGroup
						 from cv in cvGroup.DefaultIfEmpty()
						 join load in _context.Loads on weightSheet.WeightSheetId equals load.WeightsheetIdLink into loadGroup
						 join lot in _context.Lots on weightSheet.LotIdLink equals lot.LotId into lotGroup
						 from l in lotGroup.DefaultIfEmpty()
						 join producer in _context.Producers on l.ProducerIdLink equals producer.ProducerId into producerGroup
						 from p in producerGroup.DefaultIfEmpty()
						 where weightSheet.WarehouseIdLink == 1 && weightSheet.DateClosed == null && weightSheet.DateOpened == DateTime.Today
						 group new { weightSheet, cv, loadGroup, l, p } by new
						 {
							 weightSheet.WeightSheetId,
							 commodityType.CommodityTypeName,
							 CommodityVarietyName = cv.CommodityVarietyName,
							 ProducerName = p.ProducerName,
							 weightSheet.Notes,
							 LotId = l.LotId
						 } into grouped
						 select new WeightSheetDto
						 {
							 WeightsheetId = grouped.Key.WeightSheetId,
							 CommodityTypeName = grouped.Key.CommodityTypeName,
							 CommodityVarietyName = grouped.Key.CommodityVarietyName,
							 ProducerName = grouped.Key.ProducerName,
							 Notes = grouped.Key.Notes,
							 LotId = grouped.Key.LotId,
							 SumNumLoads = grouped.SelectMany(w => w.loadGroup).Count(),
							 InYard = grouped.SelectMany(w => w.loadGroup).Count(l => l.TimeIn != null && l.TimeOut == null)
						 };

			var finalResult = await result.ToListAsync();


			return Ok(finalResult);
		}

        // GET: api/Weightsheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weightsheet>> GetWeightsheet(long id)
        {
            if (_context.Weightsheets == null)
            {
                return NotFound();
            }
            var weightsheet = await _context.Weightsheets.FindAsync(id);

            if (weightsheet == null)
            {
                return NotFound();
            }

            return weightsheet;
        }

        // GET: api/Weightsheets/Open/4
        [HttpGet("Open/{id}")]
        public async Task<ActionResult<IEnumerable<Weightsheet>>> GetWarehouseOpenWeightsheets(int id)
        {
            if (_context.Weightsheets == null)
            {
                return NotFound();
            }

            var weightsheets = await _context.Weightsheets
                .Where(w => w.WarehouseIdLink == id && w.DateClosed == null)
                .ToListAsync();
            if (weightsheets == null)
            {
                return NotFound();
            }

            return weightsheets;
        }

        // PUT: api/Weightsheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightsheet(long id, Weightsheet weightsheet)
        {
            if (id != weightsheet.WeightSheetId)
            {
                return BadRequest();
            }

            _context.Entry(weightsheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeightsheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weightsheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weightsheet>> PostWeightsheet(Weightsheet weightsheet)
        {
          if (_context.Weightsheets == null)
          {
              return Problem("Entity set 'AppDbContext.Weightsheets'  is null.");
          }
            _context.Weightsheets.Add(weightsheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeightsheet", new { id = weightsheet.WeightSheetId }, weightsheet);
        }

        // DELETE: api/Weightsheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightsheet(long id)
        {
            if (_context.Weightsheets == null)
            {
                return NotFound();
            }
            var weightsheet = await _context.Weightsheets.FindAsync(id);
            if (weightsheet == null)
            {
                return NotFound();
            }

            _context.Weightsheets.Remove(weightsheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeightsheetExists(long id)
        {
            return (_context.Weightsheets?.Any(e => e.WeightSheetId == id)).GetValueOrDefault();
        }
    }
}
