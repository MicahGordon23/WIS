using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        // database context for DI
        private readonly MasterContext _context;

        // Ctor with DI for data context
        public LotController(MasterContext context)
        {
            _context = context;
        }

        //****************************************
        // Checks for existing Lot in database
        private bool LotExists(long id)
        {
            return _context.Lots.Any(e => e.LotId == id);
        }

        //****************************************
        // Gets ALL Lots in the data base
        [HttpGet]
        public async Task<ActionResult<List<Lot>>> GetAll()
        {
            return Ok(await _context.Lots.ToListAsync());
        }


        //****************************************
        // Gets top Id number from the database.
        // GET: /api/Lot/top
        [HttpGet("top")]
        public async Task<ActionResult<Lot>> GetTop()
        {
            //db.Users.OrderByDescending(u => u.UserId).FirstOrDefault();
            return await _context.Lots.OrderByDescending(lot => lot.LotId).FirstOrDefaultAsync();
		}
		//****************************************
		// Create new Lot
		[HttpPost]
        public async Task<ActionResult<Lot>> Post(Lot lot)
        {
            _context.Lots.Add(lot);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = lot.LotId }, lot);
        }

        //****************************************
        // Update existing Lot
        [HttpPut]
        public async Task<IActionResult> Put(long id, Lot lot)
        {
            if (id != lot.LotId)
            {
                return BadRequest();
            }
            _context.Entry(lot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LotExists(id))
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
