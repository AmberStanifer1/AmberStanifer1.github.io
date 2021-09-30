using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using PetStore_Team3.Models;
using PetStore_Team3.Query;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Controllers
{
    [Authorize]
    [Route ("api/[controller]")]
    [ApiController]
    public class MerchandiseController : ControllerBase
    {
        public PetStoreContext Db { get; }

        public Merchandise Merchandise { get; set; }

        public MerchandiseController (PetStoreContext db)
        {
            Db = db;
        }

        // GET: api/<MerchandiseController>
        [HttpGet]
        public async Task<IActionResult> GetAll ( )
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync ( );
            }

            var query = new MerchandiseQuery (Db);
            var result = await query.GetAllMerchandise ( );
            return new OkObjectResult (result);
        }

        // GET api/<MerchandiseController>/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> ReadItem (decimal id)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync ( );
            }
            var query = new MerchandiseQuery (Db);
            var result = await query.FindMerchandise (id);
            if (result is null)
                return new NotFoundResult ( );
            return new OkObjectResult (result);
        }

        // DELETE api/<MerchandiseController>/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync ( );
            }
            var query = new MerchandiseQuery (Db);
            var result = await query.DeleteItem (id);
            return new OkResult ( );
        }

        // CREATE api/<MerchadiseController>
        [HttpPost]
        public async Task<IActionResult> Create (decimal id, string description, decimal quantityOnHand, decimal listPrice, string category)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync ( );

            }
            var query = new MerchandiseQuery (Db);
            await query.CreateItem (id, description, quantityOnHand, listPrice, category);

            return new OkObjectResult (await query.FindMerchandise (id));


        }

        [HttpPut]
        public async Task<IActionResult> Put (decimal id, string description, decimal quantityOnHand, decimal listPrice, string category)
        {
            
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync ( );
            }

            var query = new MerchandiseQuery (Db);
            var result = await query.FindMerchandise (id);
            if (result == null)
			{
                return new NotFoundResult ( );
			}

            await query.UpdateItem (id, description, quantityOnHand, listPrice, category);
            return new OkObjectResult (await query.FindMerchandise (id));
        }

    }
}

