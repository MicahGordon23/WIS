using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityVarietyController : ControllerBase
    {
        // references to context for Dependency injection
        private readonly MasterContext _context;

        // Ctor with DI of database context.
        public CommodityVarietyController(MasterContext context)
        {
            _context = context;
        }

        //****************************************
        // Gets ALL commodity varieties.
        public async Task<ActionResult<List<CommodityVariety>>> GetAll()
        {
            return Ok(await _context.CommodityVarieties.ToListAsync());
        }
    }
}
