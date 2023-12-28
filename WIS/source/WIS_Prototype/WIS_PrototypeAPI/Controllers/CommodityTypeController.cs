using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIS_PrototypeAPI.DbContexts;

namespace WIS_PrototypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityTypeController : ControllerBase
    {
        // Reference for Data Base Context
        private readonly MasterContext _context;

    }
}
