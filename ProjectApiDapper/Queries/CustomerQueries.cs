using Microsoft.AspNetCore.Mvc;
using ProjectApiDapper.Models.Dtos;
using ProjectApiDapper.Models;
using System.Data.SqlClient;

namespace ProjectApiDapper.Queries
{
    public class CustomerQueries
    {
        public const string GetAllQuery =
            @"SELECT * 
              FROM customers;";

        public const string GetByIdQuery =
            @"SELECT * 
              FROM customers
              WHERE Id = @id;";

        public const string InsertQuery =
            @"INSERT INTO customers (
                Name, 
                FirstName,
                LastName, 
                Place)
              VALUES (@Name, 
                      @FirstName, 
                      @LastName,    
                      @Place);";

        public const string DeleteQuery =
            @"DELETE FROM customers 
              WHERE Id = @id;";

        public const string UpdateQuery =
            @"UPDATE customers SET 
              Name = @Name, 
              FirstName = @FirstName, 
              LastName = @LastName, 
              Place = @Place ";
    }
}
