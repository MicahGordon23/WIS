using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /**********************************************************************
    * It is NOT intended for the operator to be able to add and/or modify 
    *   producers.
    * It would be better have this behavior and disable it thourgh a config 
    *   like appsettings.json. Because this is NOT a business rule it is a
    *   policy. Makes the code more flexable. This is only a prototype.
    *********************************************************************/
    public class ProducerController : ControllerBase
    {
        // references to context for Dependency injection
        private readonly MasterContext _context;
        public ProducerController(MasterContext context) 
        {
            _context = context;
        }

		private bool ProducerExists(int id)
		{
			return _context.Producers.Any(e => e.ProducerId == id);
		}

		//GET: /api/Producer
		[HttpGet]
        public async Task<ActionResult<List<Producer>>> GetAll()
        {
            return Ok(await _context.Producers.ToListAsync());
        }

        //********************************
        // Get a Producer by id number.
        // Feeling cute might deleted later.
        // Not likely useful for this application
        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetById(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return producer;
        }

        // POST: /api/Producer
        // Create new Producer
        [HttpPost]
        public async Task<ActionResult<Producer>> Post(Producer producer)
        {
            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = producer.ProducerId }, producer);
        }

        // PUT: /api/Producer
        [HttpPut]
        public async Task<IActionResult> Put(int id, Producer producer)
        {
            if (id != producer.ProducerId) 
            {
                return BadRequest();
            }
            _context.Entry(producer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerExists(id))
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
