using MySqlConnector;
using PetStore_Team3.Models;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Query
{
    public class BreedQuery
    {
        public PetStoreContext Db { get; }

        public BreedQuery(PetStoreContext db)
        {
            Db = db;
        }

        public async Task<List<Breed>> GetAllBreeds()
        {
            List<Breed> list = new List<Breed>();
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM BREED;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Breed()
                        {
                            CATEGORY = reader["CATEGORY"].ToString(),
                            BREED = reader["BREED"].ToString()
                        });
                    }
                }

            return list;
        }

        public async Task<List<Breed>> GetAllBreedsByCategory (string category)
        {
            List<Breed> list = new List<Breed> ( );
            using var cmd = Db.ConnectionString.CreateCommand ( );
            cmd.CommandText = @"SELECT * FROM BREED WHERE CATEGORY = @category;";
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@category",
                DbType = DbType.String,
                Value = category
            });

            using (var reader = cmd.ExecuteReader ( ))
            {
                while (reader.Read ( ))
                {
                    list.Add (new Breed ( )
                    {
                        CATEGORY = reader["CATEGORY"].ToString ( ),
                        BREED = reader["BREED"].ToString ( )
                    });
                }
            }

            return list;
        }
    }
}
