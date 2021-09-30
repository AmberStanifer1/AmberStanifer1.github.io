using PetStore_Team3.Services;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;

namespace PetStore_Team3.Models
{
    public class Merchandise
    {
        public decimal ItemID { get; set; }

        public string Description { get; set; }

        public decimal QuantityOnHand { get; set; }

        public decimal ListPrice { get; set; }

        public string Category { get; set; }

    }
}

