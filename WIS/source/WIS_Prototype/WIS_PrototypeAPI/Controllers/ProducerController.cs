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
    }
}
