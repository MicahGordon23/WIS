using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data;
using WIS_PrototypeAPI.Data.Models;

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
                .Where(w => w.WarehouseIdLInk == id && w.DateClosed == null)
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
