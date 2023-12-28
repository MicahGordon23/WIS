using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIS_PrototypeAPI.DbContexts;
using WIS_PrototypeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController : ControllerBase
    {
        // database context for DI
        private readonly MasterContext _context;

        // Ctor with DI for data context
        public LoadController(MasterContext context)
        {
            _context = context;
        }

        //****************************************
        // Checks for existing load in database
        private bool LoadExists(long id)
        {
            return _context.Loads.Any(e => e.LoadId == id);
        }

        //****************************************
        // Gets ALL Loads in the data base
        [HttpGet]
        public async Task<ActionResult<List<Load>>> GetAll()
        {
            return Ok(await _context.Loads.ToListAsync());
        }

        //****************************************
        // Create new Load
        [HttpPost]
        public async Task<ActionResult<Load>> Post(Load load)
        {
            _context.Loads.Add(load);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = load.LoadId }, load);
        }

        //****************************************
        // Update existing Load
        [HttpPut]
        public async Task<IActionResult> Put(long id, Load load)
        {
            if (id !=load.LoadId)
            {
                return BadRequest();
            }
            _context.Entry(load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!LoadExists(id))
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
