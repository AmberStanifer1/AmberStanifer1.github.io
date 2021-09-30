using MySqlConnector;
using PetStore_Team3.Models;
using PetStore_Team3.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Query
{
    public class AnimalQuery
    {
		public PetStoreContext Db { get; }

		public AnimalQuery(PetStoreContext db)
		{
			Db = db;
		}

		public async Task<List<Animal>> FilterAnimalByName(string name)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Name = @NAME ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@NAME",
				DbType = DbType.String,
				Value = name,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}

		public async Task<List<Animal>> FilterAnimalByCategory(string category)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Category = @CATEGORY ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@CATEGORY",
				DbType = DbType.String,
				Value = category,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}

		public async Task<List<Animal>> FilterAnimalByBreed(string breed)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Breed = @BREED ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@BREED",
				DbType = DbType.String,
				Value = breed,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}

		public async Task<List<Animal>> FilterAnimalByGender(string gender)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Gender = @GENDER ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@GENDER",
				DbType = DbType.String,
				Value = gender,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}
		public async Task<List<Animal>> FilterAnimalByRegistration(string registry)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Registered = @REGISTERED ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@REGISTERED",
				DbType = DbType.String,
				Value = registry,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}
		public async Task<List<Animal>> FilterAnimalByColor(string color)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE Color = @COLOR ORDER BY ANIMALID ASC";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@COLOR",
				DbType = DbType.String,
				Value = color,
			});
			return await GetList(await cmd.ExecuteReaderAsync());
		}
		public async Task<Animal> GetAnimal(decimal animalId)
		{
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL WHERE AnimalId = @ANIMALID";
			cmd.Parameters.Add(new MySqlParameter
			{
				ParameterName = "@ANIMALID",
				DbType = DbType.Decimal,
				Value = animalId,
			});
			var list = await GetList(await cmd.ExecuteReaderAsync());
			return list.Count > 0 ? list[0] : null;
		}
		public async Task<List<Animal>> GetAllAnimals()
		{
			List<Animal> list = new List<Animal>();
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL;";
			return await GetList(await cmd.ExecuteReaderAsync());

		}

		public async Task<List<Animal>> GetList(DbDataReader reader)
		{
			List<Animal> list = new List<Animal>();
			using var cmd = Db.ConnectionString.CreateCommand();
			cmd.CommandText = @"SELECT * FROM ANIMAL;";
			using (reader)
			{
				while (await reader.ReadAsync())
				{
					list.Add(new Animal()
					{
						AnimalId = Convert.IsDBNull(reader["ANIMALID"]) ? new decimal() : (decimal)reader["ANIMALID"],
						Name = Convert.IsDBNull(reader["NAME"]) ? null : (string)reader["NAME"],
						Category = Convert.IsDBNull(reader["CATEGORY"]) ? null : (string)reader["CATEGORY"],
						Breed = Convert.IsDBNull(reader["BREED"]) ? null : (string)reader["BREED"],
						Dateborn = Convert.ToDateTime(reader["DATEBORN"]),
						Gender = reader["GENDER"].ToString(),
						Registered = Convert.IsDBNull(reader["REGISTERED"]) ? null : (string)reader["REGISTERED"],
						Color = reader["COLOR"].ToString(),
						Listprice = Convert.ToInt32(reader["LISTPRICE"]),
						Photo = Convert.IsDBNull(reader["PHOTO"]) ? new byte[0] : (byte[])reader["PHOTO"],
						Imagefile = Convert.IsDBNull(reader["IMAGEFILE"]) ? null : (string)reader["IMAGEFILE"],
						Imageheight = Convert.IsDBNull(reader["IMAGEHEIGHT"]) ? new decimal() : (decimal)reader["IMAGEHEIGHT"],
						Imagewidth = Convert.IsDBNull(reader["IMAGEWIDTH"]) ? new decimal() : (decimal)reader["IMAGEWIDTH"]

					}); ;
				}
			}
			return list;
		}
	}
}
