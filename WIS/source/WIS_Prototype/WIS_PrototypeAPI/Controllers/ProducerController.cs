using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        // references to context for Dependency injection
        private readonly MasterContext _context;
        public ProducerController(MasterContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producer>>> GetPrducers()
        {
            return Ok(await _context.Producers.ToListAsync());
        }

        //********************************
        // Get a Producer by id number.
        // Feeling cute might deleted later.
        // Not likely useful for this application
        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetProducer(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return producer;
        }
    }
}
