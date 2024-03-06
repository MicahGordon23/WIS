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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Security.Cryptography;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LotsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Lots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lot>>> GetLots()
        {
          if (_context.Lots == null)
          {
              return NotFound();
          }
            return await _context.Lots.ToListAsync();
        }

        // GET: api/Lots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lot>> GetLot(long id)
        {
          if (_context.Lots == null)
          {
              return NotFound();
          }
            var lot = await _context.Lots.FindAsync(id);

            if (lot == null)
            {
                return NotFound();
            }

            return lot;
        }

        // GET: api/Lots/Open/Dto/5
        [HttpGet("Open/Dto/{warehouseId}")]
        public async Task<ActionResult<LotDto[]>> GetOpenLotsByWarehouse(int warehouseId)
        {
            if (_context.Lots == null)
            {
                return NotFound();
            }

			//var lots = await _context.Lots
			//            .Where(lot => lot.WarehouseIdLink == warehouseId && lot.EndDate == null)
			//            .Include(lot => lot.Producer)
			//            .Include(lot => lot.CommodityType)
			//            .Include( type => type.CommodityVariety) // Was causeing loop back on
			//                                                           // CommodityType in the
			//                                                           // CommodityVariety used JSON Ignore to fix
			//            .ToListAsync();
			//return Ok(lots);
			var query = from lot in _context.Lots
							// Inner Join                
						join commodity in _context.CommodityTypes on lot.CommodityTypeIdLink equals commodity.CommodityTypeId
						// Inner Join
						join producer in _context.Producers on lot.ProducerIdLink equals producer.ProducerId
						// Left Join
						join variety in _context.CommodityVarieties on lot.CommodityVarietyIdLink equals variety.CommodityVarietyId
						into sub
						from variety in sub.DefaultIfEmpty()
						where lot.WarehouseIdLink == warehouseId && lot.EndDate == null
						group new { lot, commodity, producer, variety }
						by new
						{
							lot.LotId,
							lot.StateId,
							lot.ProducerIdLink,
							producer.ProducerName,
							lot.CommodityTypeIdLink,
							commodity.CommodityTypeName,
							lot.CommodityVarietyIdLink,
							variety.CommodityVarietyName,
							lot.Landlord,
							lot.FarmNumber,
							lot.Notes,
							lot.StartDate,
							lot.EndDate,
						} into grouped
						select new LotDto
						{
							LotId = (long)grouped.Key.LotId,
							StateId = grouped.Key.StateId,
							StartDate = (DateTime)grouped.Key.StartDate,
							EndDate = (DateTime)grouped.Key.EndDate,
							Landlord = grouped.Key.Landlord,
							FarmNumber = grouped.Key.FarmNumber,
							Notes = grouped.Key.Notes,
							CommodityTypeId = (int)grouped.Key.CommodityTypeIdLink,
							CommodityTypeName = grouped.Key.CommodityTypeName,
							CommodityVarietyId = (long)grouped.Key.CommodityVarietyIdLink,
							CommodityVarietyName = grouped.Key.CommodityVarietyName,
							ProducerId = (int)grouped.Key.ProducerIdLink,
							ProducerName = grouped.Key.ProducerName
						};
			var result = await query.ToListAsync();
			return Ok(result);
		}

        // GET: api/Lots/Dto/5
        [HttpGet("Dto/{lotId}")]
        public async Task<ActionResult<LotDto>> GetLotDto(long lotId)
        {
            if (_context.Lots == null)
            {
                return NotFound();
            }
            //******************** RAW SQL QUERY *********************
            // SELECT
            // LotId, StateId, ProducerIdLink, ProducerName, CommodityTypeName,
            // CommodityTypeId, CommodityVarietyName, CommodityVarietyId,
            // Landlord, FarmNumber, Notes, StartDate, EndDate
            // FROM Lots
            // INNER JOIN CommodityTypes
            // ON CommodityTypes.CommodityTypeId = Lots.CommodityTypeIdLink
            // LEFT JOIN CommodityVarieties
            // ON CommodityVarieties.CommodityVarietyId = Lots.CommodityVarietyIdLink
            // INNER JOIN Producers
            // ON Producers.ProducerId = Lots.ProducerIdLink
            // WHERE Lots.LotId = 1

            var query = from lot in _context.Lots
                        // Inner Join                
                        join commodity in _context.CommodityTypes on lot.CommodityTypeIdLink equals commodity.CommodityTypeId
                        // Inner Join
                        join producer in _context.Producers on lot.ProducerIdLink equals producer.ProducerId
                        // Left Join
                        join variety in _context.CommodityVarieties on lot.CommodityVarietyIdLink equals variety.CommodityVarietyId
                        into sub
                        from variety in sub.DefaultIfEmpty()
                        where lot.LotId == lotId
                        group new { lot, commodity, producer, variety }
                        by new 
                        { 
                            lot.LotId,
                            lot.StateId,
                            lot.ProducerIdLink,
                            producer.ProducerName,
                            lot.CommodityTypeIdLink,
                            commodity.CommodityTypeName,
                            lot.CommodityVarietyIdLink,
                            variety.CommodityVarietyName,
                            lot.Landlord,
                            lot.FarmNumber,
                            lot.Notes,
                            lot.StartDate,
                            lot.EndDate,
                        } into grouped
                        select new LotDto
                        {
                            LotId = (long)grouped.Key.LotId,
                            StateId = grouped.Key.StateId,
                            StartDate = (DateTime)grouped.Key.StartDate,
                            EndDate = (DateTime)grouped.Key.EndDate,
                            Landlord = grouped.Key.Landlord,
                            FarmNumber = grouped.Key.FarmNumber,
                            Notes = grouped.Key.Notes,
                            CommodityTypeId = (int)grouped.Key.CommodityTypeIdLink,
                            CommodityTypeName = grouped.Key.CommodityTypeName,
                            CommodityVarietyId = (long)grouped.Key.CommodityVarietyIdLink,
                            CommodityVarietyName = grouped.Key.CommodityVarietyName,
                            ProducerId = (int)grouped.Key.ProducerIdLink,
                            ProducerName = grouped.Key.ProducerName
                        };
            var result = await query.FirstAsync();
            return Ok(result);
        }

        // PUT: api/Lots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLot(long id, Lot lot)
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

        // POST: api/Lots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lot>> PostLot(Lot lot)
        {
          if (_context.Lots == null)
          {
              return Problem("Entity set 'AppDbContext.Lots'  is null.");
          }
            _context.Lots.Add(lot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLot", new { id = lot.LotId }, lot);
        }

        // DELETE: api/Lots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLot(long id)
        {
            if (_context.Lots == null)
            {
                return NotFound();
            }
            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }

            _context.Lots.Remove(lot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LotExists(long id)
        {
            return (_context.Lots?.Any(e => e.LotId == id)).GetValueOrDefault();
        }
    }
}
