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
    public class EmployeeQuery
    {
        public PetStoreContext Db { get; }

        public EmployeeQuery(PetStoreContext db)
        {
            Db = db;
        }

        public Employee Employees { get; set; }

        public async Task<Employee> FindEmployee(decimal employeeID)
        {
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM EMPLOYEE WHERE employeeID = @EMPLOYEEID";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@employeeID",
                DbType = DbType.Decimal,
                Value = employeeID,
            });

            List<Employee> list = new List<Employee>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        EmployeeID = reader.GetInt32(0),
                        LastName = reader["LASTNAME"].ToString(),
                        FirstName = reader["FIRSTNAME"].ToString(),
                        Phone = reader["PHONE"].ToString(),
                        Address = reader["ADDRESS"].ToString(),
                        ZipCode = reader["ZIPCODE"].ToString(),
                        CityID = reader.GetInt32(6),
                        TaxPayerID = reader["TAXPAYERID"].ToString(),
                        DateHired = Convert.IsDBNull(reader["DATEHIRED"]) ? null : (DateTime)reader["DATEHIRED"],
                        DateReleased = Convert.IsDBNull(reader["DATERELEASED"]) ? null : (DateTime)reader["DATERELEASED"],
                        ManagerID = reader.GetInt32(10),
                        EmployeeLevel = reader.GetInt32(11),
                        Title = reader["TITLE"].ToString(),



                    });
                }
            }

            return list.Count > 0 ? list[0] : null;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"SELECT * FROM EMPLOYEE;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        EmployeeID = reader.GetInt32(0),
                        LastName = reader["LASTNAME"].ToString(),
                        FirstName = reader["FIRSTNAME"].ToString(),
                        Phone = reader["PHONE"].ToString(),
                        Address = reader["ADDRESS"].ToString(),
                        ZipCode = reader["ZIPCODE"].ToString(),
                        CityID = reader.GetInt32(6),
                        TaxPayerID = reader["TAXPAYERID"].ToString(),
                        DateHired = Convert.IsDBNull(reader["DATEHIRED"]) ? null : (DateTime)reader["DATEHIRED"],
                        DateReleased = Convert.IsDBNull(reader["DATERELEASED"]) ? null : (DateTime)reader["DATERELEASED"],
                        ManagerID = reader.GetInt32(10),
                        EmployeeLevel = reader.GetInt32(11),
                        Title = reader["TITLE"].ToString(),



                    });
                }
            }

            return list;
        }

        public async Task<Employee> UpdateEmployee(decimal employeeID, string lastName, string firstName, string phone, string address,
                                                    string zipCode, decimal CityID, string taxPayerID, DateTime? dateHired, DateTime? dateReleased,
                                                    decimal managerID, decimal employeeLevel, string title)
        {
            using var cmd = Db.ConnectionString.CreateCommand();
            cmd.CommandText = @"UPDATE EMPLOYEE SET LASTNAME = @lastName, FIRSTNAME = @firstName, PHONE = @phone,
            ADDRESS = @address, ZIPCODE = @zipCOde, CITYID = @CityID, TAXPAYERID = @taxPayerID, DATEHIRED = @dateHired, DATERELEASED = @dateReleased,
            MANAGERID = @managerID, EMPLOYEELEVEL = @employeeLevel, TITLE = @title WHERE EMPLOYEEID = @employeeID;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@employeeID",
                DbType = DbType.Decimal,
                Value = employeeID
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@lastName",
                DbType = DbType.String,
                Value = lastName
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@firstName",
                DbType = DbType.String,
                Value = firstName
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@phone",
                DbType = DbType.String,
                Value = phone
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@address",
                DbType = DbType.String,
                Value = address
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@zipCode",
                DbType = DbType.String,
                Value = zipCode
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@CityID",
                DbType = DbType.Decimal,
                Value = CityID
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@taxPayerID",
                DbType = DbType.String,
                Value = taxPayerID
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dateHired",
                DbType = DbType.DateTime,
                Value = dateHired
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dateReleased",
                DbType = DbType.DateTime,
                Value = dateReleased
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@managerID",
                DbType = DbType.Decimal,
                Value = managerID
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@employeeLevel",
                DbType = DbType.Decimal,
                Value = employeeLevel
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@title",
                DbType = DbType.String,
                Value = title
            });
            await cmd.ExecuteNonQueryAsync();
            return null;
        }
    }
}
