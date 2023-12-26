using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Security.Cryptography.Pkcs;
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
        public async Task<ActionResult<List<Producer>>> GetPrducer()
        {
            return Ok(await _context.Producers.ToListAsync());
        }
    }
}
