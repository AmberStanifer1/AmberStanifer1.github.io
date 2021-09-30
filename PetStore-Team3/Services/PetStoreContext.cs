using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PetStore_Team3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Services 
{
    public class PetStoreContext : IDisposable
    {
        public MySqlConnection ConnectionString { get; }
        public PetStoreContext(string connectionString)
        {
            this.ConnectionString = new MySqlConnection(connectionString);
        }

        public void Dispose() => ConnectionString.Dispose();

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Catagories { get; set; }

        public DbSet<Merchandise> Merchandises { get; set; }
    }
}
