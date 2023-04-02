using Dapper;
using ProjectApiDapper.Data;
using ProjectApiDapper.Models;

namespace ProjectApiDapper.Repository
{
    public class CustomerRepository
    {
        private readonly DbContext _context;
        private readonly DynamicParameters _param;

        public CustomerRepository(DbContext context)
        {
            _context = context;
            _param = new DynamicParameters();
        }

        //public async Task<IEnumerable<Customer>> GetAllAsync() =>
        //await _context.Connection.QueryAsync<Customer, Customer>(Queries.CustomerQueries.GetAllQuery, map: mapPropriedades, splitOn: "Id");

        /*
        private static Customer mapPropriedades(Customer customer)
        {
            return customer;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            _param.Add("@Id", id);

            return _context.Connection.Query<Customer, Product, Customer>(Queries.CustomerQueries.GetByIdQuery,
                map: mapPropriedades, splitOn: "Id", param: _param).FirstOrDefault();
        }


        public async Task CreateAsync(Customer customer)
        {

            _param.Add("@Name", customer.Name);
            _param.Add("@Email", customer.Email);
            _param.Add("@ProductId", customer.Products.Id);

            await _context.Connection.ExecuteScalarAsync(Queries.CustomerQueries.InsertQuery, _param);
        }

        public async Task DeleteAsync(int id)
        {
            _param.Add("@Id", id);

            await _context.Connection.ExecuteScalarAsync(Queries.CustomerQueries.DeleteQuery, _param);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _param.Add("@Name", customer.Name);
            _param.Add("@FistName", customer.FirstName);
            _param.Add("@LastName", customer.LastName);
            _param.Add("@Place", customer.Place);

            await _context.Connection.ExecuteScalarAsync(Queries.CustomerQueries.UpdateQuery, _param);
        }
        */
    }
}
