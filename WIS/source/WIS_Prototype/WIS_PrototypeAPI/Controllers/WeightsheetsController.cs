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

        // GET: api/Weightsheet
        [HttpGet("Overview/{warehouseId}")]
        public async Task<ActionResult<WeightSheetDto>> GetAllOpenWeightSheets(int warehouseId)
        {
			var today = DateTime.Now.Date;
            var query = from weightsheets in _context.Weightsheets
                        // Left Join 
                        //join source in _context.Sources.DefaultIfEmpty() on weightsheets.SourceIdLink equals source.SourceId
                        // Left Join
                        join lot in _context.Lots.DefaultIfEmpty() on weightsheets.LotIdLink equals lot.LotId
                        // Left Join
                        join producer in _context.Producers.DefaultIfEmpty() on lot.ProducerIdLink equals producer.ProducerId
                        join commodity in _context.CommodityTypes on weightsheets.CommodityTypeIdLink equals commodity.CommodityTypeId
                        // Left Join
                        join variety in _context.CommodityVarieties on weightsheets.CommodityVarietyIdLink equals variety.CommodityVarietyId
                        into commodityPair
                        from variety in commodityPair.DefaultIfEmpty()
                        join load in _context.Loads on weightsheets.WeightSheetId equals load.WeightsheetIdLink
                        where weightsheets.DateOpened == today && weightsheets.DateClosed == null && weightsheets.WarehouseIdLink == warehouseId
                        group new { weightsheets, commodity, variety, load, producer /*, source */}
                        by new
                        {
                            weightsheets.WeightSheetId,
                            weightsheets.CommodityTypeIdLink,
                            commodity.CommodityTypeName,
                            weightsheets.CommodityVarietyIdLink,
                            comVarName = variety != null ? variety.CommodityVarietyName : null,
                            lotId = weightsheets.LotIdLink != null ? weightsheets.LotIdLink : null,
							producerName = producer.ProducerName != null ? producer.ProducerName: null,
                            //sourceName = source.SourceName != null ? source.SourceName : null,

						} into grouped
						select new WeightSheetDto
						{
						    WeightsheetId = (long)grouped.Key.WeightSheetId,
							CommodityTypeId = (int)grouped.Key.CommodityTypeIdLink,
							CommodityTypeName = (string)grouped.Key.CommodityTypeName,
							CommodityVarietyId = (long)grouped.Key.CommodityVarietyIdLink,
							CommodityVarietyName = grouped.Key.comVarName,
							SumNumLoads = (int)grouped.Count(),
                            InYard = grouped.Count(item => item.load.TimeOut == null),
                            ProducerName = grouped.Key.producerName,
                            LotId = grouped.Key.lotId,
                            //SourceName = grouped.Key.sourceName

						};
			var result = await query.ToListAsync();
			return Ok(result);
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
