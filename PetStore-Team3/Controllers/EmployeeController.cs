using Microsoft.AspNetCore.Mvc;
using PetStore_Team3.Models;
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
    public class EmployeeController
    {
        public PetStoreContext Db { get; }

        public Employee Employees { get; set; }

        public EmployeeController(PetStoreContext db)
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
            var query = new EmployeeQuery(Db);
            var result = await query.GetAllEmployees();
            return new OkObjectResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutOne(decimal employeeID, string lastName, string firstName, string phone, string address,
                                                    string zipcode, decimal cityID, string taxPayerID, DateTime? dateHired, DateTime? dateReleased,
                                                    decimal managerID, decimal employeeLevel, string title)
        {
            if (Db.ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                await Db.ConnectionString.OpenAsync();
            }
            var query = new EmployeeQuery(Db);
            var result = await query.FindEmployee(employeeID);

            if(result == null)
            {
                return new NotFoundResult();
            }


            await query.UpdateEmployee(employeeID, lastName, firstName, phone, address, zipcode, cityID,
                                        taxPayerID, dateHired, dateReleased, managerID, employeeLevel, title);

            return new OkObjectResult(await query.FindEmployee(employeeID));
        }

    }
}