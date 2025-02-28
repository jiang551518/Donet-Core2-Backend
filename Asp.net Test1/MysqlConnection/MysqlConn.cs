using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    /// <summary>
    /// 连接mysql
    /// </summary>
    public class MysqlConn
    {
        protected MySqlConnection connection;
        public IConfiguration _configuration { get; set; }
        public MysqlConn(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new MySqlConnection(_configuration["MysqlConnection"]);
        }
    }
}
