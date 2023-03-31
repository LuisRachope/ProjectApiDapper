using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApiDapper.Models;
using ProjectApiDapper.Models.Dtos;
using System.Data.SqlClient;

//https://www.youtube.com/watch?v=n0zkkoL8eNs
namespace ProjectApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly IConfiguration _config;

        public CustomerController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var customers = await connection.QueryAsync<Customer>("select * from customers;");
            return Ok(customers);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var customer = await connection.QueryFirstAsync<Customer>("select * from customers where Id = @id;",
                new { Id = id });

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromBody] CreateCustomerDto customerDto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.QueryAsync("INSERT INTO customers (Name, FirstName, LastName, Place)" +
                "VALUES (@Name, @FirstName, @LastName, @Place);", 
                new { Name = customerDto.Name, FirstName = customerDto.FirstName, LastName = customerDto.LastName, Place = customerDto.Place }
                );

            return Ok(customerDto);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            try
            {
                await connection.QueryAsync("DELETE FROM customers WHERE Id = @id;",
                new { Id = id });
            }
            catch (Exception)
            {

                return NotFound(false);
            }

            return Ok(true);
        }
    }
}
