using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIS_PrototypeAPI.Data.Models;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinController : ControllerBase
    {
        //****************************************
        // Reference to data base context.
        //****************************************
        private readonly MasterContext _context;

        //****************************************
        // Controller ctor with Dependency Injection of the database context.
        //****************************************
        public BinController(MasterContext context)
        {
            _context = context;
        }

        //***************************************
        // Gets all bins in the database
        //***************************************
        [HttpGet]
        public async Task<ActionResult<List<Bin>>> GetBins()
        {
            return Ok(await _context.Bins.ToListAsync());
        }
    }
}
