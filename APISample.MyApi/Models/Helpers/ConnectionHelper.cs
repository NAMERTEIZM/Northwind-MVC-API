using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Helpers
{
    public class ConnectionHelper
    {
        private readonly IConfiguration _conf;

        public ConnectionHelper(IConfiguration conf)
        {
            _conf = conf;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_conf.GetConnectionString("dapperConn"));
    }
}
