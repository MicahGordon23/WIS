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
    public class CommodityVarietiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommodityVarietiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommodityVarieties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityVariety>>> GetCommodityVarieties()
        {
            if (_context.CommodityVarieties == null)
            {
                return NotFound();
            }
            return await _context.CommodityVarieties.ToListAsync();
        }

        // GET: api/CommodityVarieties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityVariety>> GetCommodityVariety(long id)
        {
            if (_context.CommodityVarieties == null)
            {
                return NotFound();
            }
            var commodityVariety = await _context.CommodityVarieties.FindAsync(id);

            if (commodityVariety == null)
            {
                return NotFound();
            }

            return commodityVariety;
        }

        [HttpGet("Type/{id}")]
        public async Task<ActionResult<IEnumerable<CommodityVariety>>> GetCommodityVarietyByType(int id)
        {
            if (_context.CommodityVarieties == null)
            {
                return NotFound();
            }
            var commodityVariety = await _context.CommodityVarieties
            .Where(v => v.CommodityTypeIdLink == id)
            .ToListAsync();

            if (commodityVariety == null)
            {
                return NotFound();
            }

            return commodityVariety;
		}

        // PUT: api/CommodityVarieties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommodityVariety(long id, CommodityVariety commodityVariety)
        {
            if (id != commodityVariety.CommodityVarietyId)
            {
                return BadRequest();
            }

            _context.Entry(commodityVariety).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityVarietyExists(id))
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

        // POST: api/CommodityVarieties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommodityVariety>> PostCommodityVariety(CommodityVariety commodityVariety)
        {
          if (_context.CommodityVarieties == null)
          {
              return Problem("Entity set 'AppDbContext.CommodityVarieties'  is null.");
          }
            _context.CommodityVarieties.Add(commodityVariety);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommodityVariety", new { id = commodityVariety.CommodityVarietyId }, commodityVariety);
        }

        // DELETE: api/CommodityVarieties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodityVariety(long id)
        {
            if (_context.CommodityVarieties == null)
            {
                return NotFound();
            }
            var commodityVariety = await _context.CommodityVarieties.FindAsync(id);
            if (commodityVariety == null)
            {
                return NotFound();
            }

            _context.CommodityVarieties.Remove(commodityVariety);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommodityVarietyExists(long id)
        {
            return (_context.CommodityVarieties?.Any(e => e.CommodityVarietyId == id)).GetValueOrDefault();
        }
    }
}
