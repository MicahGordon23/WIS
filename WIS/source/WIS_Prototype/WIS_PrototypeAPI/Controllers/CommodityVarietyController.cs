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
    *   commodity varieties.
    * It would be better have this behavior and disable it thourgh a config 
    *   like appsettings.json. Because this is NOT a business rule it is a
    *   policy. Makes the code more flexable. This is only a prototype.
    *********************************************************************/
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
        [HttpGet]
        public async Task<ActionResult<List<CommodityVariety>>> GetAll()
        {
            return Ok(await _context.CommodityVarieties.ToListAsync());
        }
    }
}
