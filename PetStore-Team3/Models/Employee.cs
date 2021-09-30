using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Models
{
    public class Employee
    {
        public decimal EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public City CityName{ get; set; }

        public decimal CityID { get; set; }

        public string TaxPayerID { get; set; }

        public DateTime? DateHired { get; set; }
        public DateTime? DateReleased { get; set; }

        public decimal ManagerID { get; set; }

        public decimal EmployeeLevel { get; set; }

        public string Title { get; set; }
    }
}