using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        // Refernces for database context DI
        private readonly MasterContext _context;

        // Ctor with DI for database context.
        public DistrictController(MasterContext context)
        {
            _context = context;
        }

        //****************************************
        // Get ALL districts
        public async Task<ActionResult<List<District>>> GetAll()
        {
            return Ok(await _context.Districts.ToListAsync());
        }
    }
}
