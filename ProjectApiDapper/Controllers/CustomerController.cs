using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApiDapper.Data;
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
        public readonly DbContext _context;

        public CustomerController(DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            var customers = await _context.Connection.QueryAsync<Customer>("select * from customers;");

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _context.Connection.QueryFirstAsync<Customer>("select * from customers where Id = @id;",
                new { Id = id });

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerDto>> Create([FromBody] CreateCustomerDto customerDto)
        {
            await _context.Connection.ExecuteAsync("INSERT INTO customers (Name, FirstName, LastName, Place)" +
                "VALUES (@Name, @FirstName, @LastName, @Place);",
                 new { Name = customerDto.Name, FirstName = customerDto.FirstName, LastName = customerDto.LastName, Place = customerDto.Place }
                );

            return Ok(customerDto);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                await _context.Connection.QueryAsync("DELETE FROM customers WHERE Id = @id;",
                new { Id = id });
            }
            catch (Exception)
            {

                return NotFound(false);
            }

            return Ok(true);
        }

        [HttpPut("id")]
        public async Task<ActionResult<CreateCustomerDto>> Update(int id, [FromBody] CreateCustomerDto customerDto)
        {
            await _context.Connection.ExecuteAsync("UPDATE customers " +
                "SET Name = @name, FirstName = @firstName, LastName = @lastName, Place = @place " +
                "WHERE Id = @id;",
                new { Id = id, name = customerDto.Name, firstName = customerDto.FirstName, lastName = customerDto.LastName, place = customerDto.Place }
                );

            return Ok(customerDto);
        }
    }
}
