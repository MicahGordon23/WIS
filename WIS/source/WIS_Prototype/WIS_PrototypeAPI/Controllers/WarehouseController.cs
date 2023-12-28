using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIS_PrototypeAPI.DbContexts;
using WIS_PrototypeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private MasterContext _context;

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
        //****************************************
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
