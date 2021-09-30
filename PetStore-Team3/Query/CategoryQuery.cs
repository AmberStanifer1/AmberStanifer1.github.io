using MySqlConnector;
using PetStore_Team3.Models;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Query
{
    public class CategoryQuery
    {
        public PetStoreContext Db { get; }
        
        public CategoryQuery(PetStoreContext db)
        {
            Db = db;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM CATEGORY;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category()
                        {
                            CATEGORY = reader["CATEGORY"].ToString(),
                            REGISTRATION = reader["REGISTRATION"].ToString()
                        });
                    }
                }
 
            return list;
        }
    }
}
