using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApiDapper.Models;
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
    }
}
