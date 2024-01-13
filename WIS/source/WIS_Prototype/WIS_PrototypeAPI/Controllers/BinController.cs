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
    *   bins.
    * It would be better have this behavior and disable it thourgh a config 
    *   like appsettings.json. Because this is NOT a business rule it is a
    *   policy. Makes the code more flexable. This is only a prototype.
    *********************************************************************/
    public class BinController : ControllerBase
    {
        //****************************************
        // Reference to data base context.
        private readonly MasterContext _context;

        //****************************************
        // Controller ctor with Dependency Injection of the database context.
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
