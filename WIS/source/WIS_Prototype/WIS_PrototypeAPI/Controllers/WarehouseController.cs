using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIS_PrototypeAPI.DbContexts;
using WIS_PrototypeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /**********************************************************************
    * It is NOT intended for the operator to be able to add and/or modify 
    *   warehoues.
    * It would be better have this behavior and disable it thourgh a config 
    *   like appsettings.json. Because this is NOT a business rule it is a
    *   policy. Makes the code more flexable. This is only a prototype.
    *********************************************************************/
    public class WarehouseController : ControllerBase
    {
        // 
        private readonly MasterContext _context;

        public WarehouseController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Warehouse>>> GetWarehouses()
        {
            return Ok(await _context.Producers.ToListAsync());
        }

        //****************************************
        // Get all bins for a desired warehouse
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Bin>>> GetWarehouseBins(int id)
        {
            /******************************************
            *              SQL Query:
            * SELECT * FROM warehouse 
            * INNER JOIN bin ON warehouse.warehouse_id = bin.warehouse_id_link 
            * WHERE warehouse.warehouse_id = id;
            *****************************************/
            var query = await _context.Warehouses
                .Where(w => w.WarehouseId == id)
                .Include(w => w.WeightsheetWarehouseIdLinkNavigations)
                .ToListAsync();
            if (query == null)
            {
                return NotFound();
            }
            return Ok(query);
        }

    }
}
