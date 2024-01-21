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
    public class CommodityTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommodityTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommodityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityType>>> GetCommodityTypes()
        {
          if (_context.CommodityTypes == null)
          {
              return NotFound();
          }
            return await _context.CommodityTypes.ToListAsync();
        }

        // GET: api/CommodityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityType>> GetCommodityType(int id)
        {
          if (_context.CommodityTypes == null)
          {
              return NotFound();
          }
            var commodityType = await _context.CommodityTypes.FindAsync(id);

            if (commodityType == null)
            {
                return NotFound();
            }

            return commodityType;
        }

        // PUT: api/CommodityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommodityType(int id, CommodityType commodityType)
        {
            if (id != commodityType.CommodityTypeId)
            {
                return BadRequest();
            }

            _context.Entry(commodityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityTypeExists(id))
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

        // POST: api/CommodityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommodityType>> PostCommodityType(CommodityType commodityType)
        {
          if (_context.CommodityTypes == null)
          {
              return Problem("Entity set 'AppDbContext.CommodityTypes'  is null.");
          }
            _context.CommodityTypes.Add(commodityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommodityType", new { id = commodityType.CommodityTypeId }, commodityType);
        }

        // DELETE: api/CommodityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodityType(int id)
        {
            if (_context.CommodityTypes == null)
            {
                return NotFound();
            }
            var commodityType = await _context.CommodityTypes.FindAsync(id);
            if (commodityType == null)
            {
                return NotFound();
            }

            _context.CommodityTypes.Remove(commodityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommodityTypeExists(int id)
        {
            return (_context.CommodityTypes?.Any(e => e.CommodityTypeId == id)).GetValueOrDefault();
        }
    }
}
