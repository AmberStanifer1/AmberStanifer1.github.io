using Microsoft.AspNetCore.Mvc;
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
    public class MerchandiseQuery
    {
       //decimal id;
       // string description, category;
        public PetStoreContext Db { get; }

        public MerchandiseQuery(PetStoreContext db)
        {
            Db = db;
        }

        public Merchandise Merchandise { get; set; }

        public async Task<Merchandise> FindMerchandise(decimal ItemID)
        {
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM MERCHANDISE WHERE ItemID = @ITEMID";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@ItemID",
                DbType = DbType.Decimal,
                Value = ItemID,
            });

            List<Merchandise> list = new List<Merchandise>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Merchandise()
                    {
                        ItemID = Convert.ToDecimal(reader["ITEMID"]),
                        Description = reader["DESCRIPTION"].ToString(),
                        QuantityOnHand = Convert.ToDecimal(reader["QUANTITYONHAND"]),
                        ListPrice = Convert.ToDecimal(reader["LISTPRICE"]),
                        Category = reader["CATEGORY"].ToString()

                    }); ;
                }
            }

            return list.Count > 0 ? list[0] : null;
        }

        public async Task<List<Merchandise>> GetAllMerchandise()
        {
            List<Merchandise> list = new List<Merchandise>();
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM MERCHANDISE;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Merchandise()
                    {
                        ItemID = Convert.ToDecimal(reader["ITEMID"]),
                        Description = reader["DESCRIPTION"].ToString(),
                        QuantityOnHand = Convert.ToDecimal(reader["QUANTITYONHAND"]),
                        ListPrice = Convert.ToDecimal(reader["LISTPRICE"]),
                        Category = reader["CATEGORY"].ToString()

                    }); ;
                }
            }

            return list;
        }

        public async Task<Merchandise> DeleteItem(decimal Itemid)
        {
            await FindMerchandise(Itemid);
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"DELETE FROM MERCHANDISE WHERE ITEMID = @Itemid;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Itemid",
                DbType = DbType.Decimal,
                Value = Itemid
            });
            await cmd.ExecuteNonQueryAsync();
            return null;
        }

        public async Task<Merchandise> CreateItem(decimal id, string description, decimal quantityOnHand, decimal listPrice, string category)
        {
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"INSERT INTO MERCHANDISE (ITEMID, DESCRIPTION, QUANTITYONHAND, LISTPRICE, CATEGORY) VALUES 
                                    (@id, @description, @quantityOnHand, @listPrice, @category);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Decimal,
                Value = id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@description",
                DbType = DbType.String,
                Value = description,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@quantityOnHand",
                DbType = DbType.Decimal,
                Value = quantityOnHand,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@listPrice",
                DbType = DbType.Decimal,
                Value = listPrice,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@category",
                DbType = DbType.String,
                Value = category,
            });
            await cmd.ExecuteNonQueryAsync();
            return null;
        }

        public async Task<Merchandise> UpdateItem (decimal id, string description, decimal quantityOnHand, decimal listPrice, string category)
        {
            using var cmd = Db.ConnectionString.CreateCommand ( );
            cmd.CommandText = @"UPDATE MERCHANDISE SET DESCRIPTION = @Description, QUANTITYONHAND = @QuantityOnHand, LISTPRICE = @ListPrice, CATEGORY = @Category WHERE ITEMID = @ItemID;";
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@ItemID",
                DbType = DbType.Decimal,
                Value = id,
            });
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@Description",
                DbType = DbType.String,
                Value = description,
            });
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@QuantityOnHand",
                DbType = DbType.Decimal,
                Value = quantityOnHand,
            });
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@ListPrice",
                DbType = DbType.Decimal,
                Value = listPrice,
            });
            cmd.Parameters.Add (new MySqlParameter
            {
                ParameterName = "@Category",
                DbType = DbType.String,
                Value = category,
            });
            await cmd.ExecuteNonQueryAsync ( );
            return null;
        }

    }
}
