using System.Data;
using System.Data.SqlClient;

namespace ProjectApiDapper.Data
{
    public class DbContext

    {
        public readonly IConfiguration _config;
        public IDbConnection Connection;

        public DbContext(IConfiguration config)
        {
            _config = config;
            Connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
