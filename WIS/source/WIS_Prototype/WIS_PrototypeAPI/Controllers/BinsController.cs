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
    public class BinsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BinsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bin>>> GetBins()
        {
          if (_context.Bins == null)
          {
              return NotFound();
          }
          return await _context.Bins.ToListAsync();
        }

        // GET: api/Bins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bin>> GetBin(int id)
        {
          if (_context.Bins == null)
          {
              return NotFound();
          }
          
          var bin = await _context.Bins.FindAsync(id);

          if (bin == null)
          {
              return NotFound();
		  }

			return bin;
        }

        // GET: api/Bins/Warehouse/5
        [HttpGet("Warehouse/{id}")]
        public async Task<ActionResult<IEnumerable<Bin>>> GetWarehouesBins(int id)
        {
            if (_context.Bins == null)
            {
                return NotFound();
            }

            var bins = await _context.Bins
                .Where(b => b.WarehouseIdLink == id)
                .ToListAsync();

            if (bins == null)
            {
                return NotFound();
            }

            return bins;
        }
        // PUT: api/Bins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBin(int id, Bin bin)
        {
            if (id != bin.BinId)
            {
                return BadRequest();
            }

            _context.Entry(bin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinExists(id))
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

        // POST: api/Bins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bin>> PostBin(Bin bin)
        {
          if (_context.Bins == null)
          {
              return Problem("Entity set 'AppDbContext.Bins'  is null.");
          }
            _context.Bins.Add(bin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBin", new { id = bin.BinId }, bin);
        }

        // DELETE: api/Bins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBin(int id)
        {
            if (_context.Bins == null)
            {
                return NotFound();
            }
            var bin = await _context.Bins.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }

            _context.Bins.Remove(bin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BinExists(int id)
        {
            return (_context.Bins?.Any(e => e.BinId == id)).GetValueOrDefault();
        }
    }
}
