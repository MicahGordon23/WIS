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
    public class LoadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoadsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Loads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Load>>> GetLoads()
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            return await _context.Loads.ToListAsync();
        }

        // GET: api/Loads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Load>> GetLoad(long id)
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            var load = await _context.Loads.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            return load;
        }

        // PUT: api/Loads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoad(long id, Load load)
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

        // POST: api/Loads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Load>> PostLoad(Load load)
        {
          if (_context.Loads == null)
          {
              return Problem("Entity set 'AppDbContext.Loads'  is null.");
          }
            _context.Loads.Add(load);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoad", new { id = load.LoadId }, load);
        }

        // DELETE: api/Loads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoad(long id)
        {
            if (_context.Loads == null)
            {
                return NotFound();
            }
            var load = await _context.Loads.FindAsync(id);
            if (load == null)
            {
                return NotFound();
            }

            _context.Loads.Remove(load);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoadExists(long id)
        {
            return (_context.Loads?.Any(e => e.LoadId == id)).GetValueOrDefault();
        }
    }
}
