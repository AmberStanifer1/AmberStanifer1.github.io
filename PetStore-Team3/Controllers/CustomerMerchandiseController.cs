using Microsoft.AspNetCore.Mvc;
using PetStore_Team3.Models;
using PetStore_Team3.Query;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore_Team3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMerchandiseController : ControllerBase
    {
        public PetStoreContext Db { get; }

        public Merchandise Merchandise { get; set; }

        public CustomerMerchandiseController(PetStoreContext db)
        {
            Db = db;
        }

        // GET: api/<CustomerMerchandiseController>
        [HttpGet]
        public async Task<IActionResult> CustomerGetAll()
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new MerchandiseQuery(Db);
            var result = await query.GetAllMerchandise();
            return new OkObjectResult(result);
        }

        // GET api/<CustomerMerchandiseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> CustomerReadItem(decimal id)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new MerchandiseQuery(Db);
            var result = await query.FindMerchandise(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
