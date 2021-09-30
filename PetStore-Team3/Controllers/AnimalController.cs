using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore_Team3.Query;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public PetStoreContext Db { get; }

        public AnimalController(PetStoreContext db)
        {
            Db = db;
        }
        // GET: api/<MerchandiseController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.GetAllAnimals();
            return new OkObjectResult(result);

        }

        //GET api/<AnimalController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ReadAnimal(decimal id)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.GetAnimal(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByName/{name}")]
        public async Task<IActionResult> ListAnimalByName(string name)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByName(name);
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByCategory/{category}")]
        public async Task<IActionResult> ListAnimalByCategory(string category)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByCategory(category);
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByBreed/{breed}")]
        public async Task<IActionResult> ListAnimalByBreed(string breed)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByBreed(breed);
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByGender/{gender}")]
        public async Task<IActionResult> ListAnimalByGender(string gender)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByGender(gender);
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByRegistation/{registration}")]
        public async Task<IActionResult> ListAnimalByRegistry(string registration)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByRegistration(registration);
            return new OkObjectResult(result);
        }

        [HttpGet("FilterByColor/{color}")]
        public async Task<IActionResult> ListAnimalByColor(string color)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new AnimalQuery(Db);
            var result = await query.FilterAnimalByColor(color);
            return new OkObjectResult(result);
        }

    }
}
