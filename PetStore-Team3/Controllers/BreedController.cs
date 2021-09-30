using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PetStore_Team3.Query;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PetStore_Team3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        public PetStoreContext Db { get; }

        public BreedController(PetStoreContext db)
        {
            Db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new BreedQuery(Db);
            var result = await query.GetAllBreeds();
            return new OkObjectResult(result);
        }

        [HttpGet ("{category}")]
        public async Task<IActionResult> GetBreedsByCategory (string category)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new BreedQuery (Db);
            var result = await query.GetAllBreedsByCategory (category);
            return new OkObjectResult (result);
        }

    }
}
