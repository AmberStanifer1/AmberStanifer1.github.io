using Microsoft.AspNetCore.Mvc;
using PetStore_Team3.Query;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore_Team3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public PetStoreContext Db { get; }

        public CategoryController(PetStoreContext db)
        {
            Db = db;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new CategoryQuery(Db);
            var result = await query.GetAllCategories();
            return new OkObjectResult(result);
        }
    }
}
