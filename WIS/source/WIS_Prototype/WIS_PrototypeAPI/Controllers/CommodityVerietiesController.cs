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
    public class CommodityVerietiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommodityVerietiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommodityVerieties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityVeriety>>> GetCommodityVerieties()
        {
          if (_context.CommodityVerieties == null)
          {
              return NotFound();
          }
            return await _context.CommodityVerieties.ToListAsync();
        }

        // GET: api/CommodityVerieties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityVeriety>> GetCommodityVeriety(long id)
        {
          if (_context.CommodityVerieties == null)
          {
              return NotFound();
          }
            var commodityVeriety = await _context.CommodityVerieties.FindAsync(id);

            if (commodityVeriety == null)
            {
                return NotFound();
            }

            return commodityVeriety;
        }

        // PUT: api/CommodityVerieties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommodityVeriety(long id, CommodityVeriety commodityVeriety)
        {
            if (id != commodityVeriety.CommodityVerietyId)
            {
                return BadRequest();
            }

            _context.Entry(commodityVeriety).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityVerietyExists(id))
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

        // POST: api/CommodityVerieties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommodityVeriety>> PostCommodityVeriety(CommodityVeriety commodityVeriety)
        {
          if (_context.CommodityVerieties == null)
          {
              return Problem("Entity set 'AppDbContext.CommodityVerieties'  is null.");
          }
            _context.CommodityVerieties.Add(commodityVeriety);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommodityVeriety", new { id = commodityVeriety.CommodityVerietyId }, commodityVeriety);
        }

        // DELETE: api/CommodityVerieties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodityVeriety(long id)
        {
            if (_context.CommodityVerieties == null)
            {
                return NotFound();
            }
            var commodityVeriety = await _context.CommodityVerieties.FindAsync(id);
            if (commodityVeriety == null)
            {
                return NotFound();
            }

            _context.CommodityVerieties.Remove(commodityVeriety);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommodityVerietyExists(long id)
        {
            return (_context.CommodityVerieties?.Any(e => e.CommodityVerietyId == id)).GetValueOrDefault();
        }
    }
}
