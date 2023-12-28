using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightsheetController : ControllerBase
    {
        // Database context reference for DI
        private readonly MasterContext _context;

        // Ctor with DI of database context
        public WeightsheetController(MasterContext context)
        {
            _context = context;
        }

        //****************************************
        // Checks for existing load in database
        private bool WeightsheetExists(long id)
        {
            return _context.Weightsheets.Any(w => w.WeightsheetId == id);
        }

        //****************************************
        // Gets ALL weightsheets
        [HttpGet]
        public async Task<ActionResult<List<Weightsheet>>> GetAllWeightsheets()
        {
            return Ok(await _context.Weightsheets.ToListAsync());
        }

        //****************************************
        // Create new WeightSheet
        [HttpPost]
        public async Task<ActionResult<Weightsheet>> PostWeightsheet(Weightsheet weightsheet)
        {
            _context.Weightsheets.Add(weightsheet);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWeightsheet", new { id = weightsheet.WeightsheetId }, weightsheet);
        }

        //****************************************
        // Update existing Load
        [HttpPut]
        public async Task<IActionResult> PutWeightsheet(long id, Load load)
        {
            if (id != load.LoadId)
            {
                return BadRequest();
            }
            _context.Entry(load).State = EntityState.Modified;

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
    }
}
