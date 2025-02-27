using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class TestRepository : ITestRepository
    {
        private string conn;
        private MySqlConnection connection;
        public IConfiguration _configuration { get; set; }

        public TestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = _configuration["MysqlConnection"];
            connection = new MySqlConnection(conn);
        }


        public async Task<TestVM> GetList()
        {
            var result = new TestVM();

            result.Tests = (await connection.QueryAsync<Test>("SELECT * FROM Test;")).ToList();

            return result;

        }

        public async Task<User> GetUserDetail(string usermane)
        {
            var result = new User();

            result = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM User WHERE username = @username ;", new { username = usermane });

            return result;
        }

        public async Task<bool> Sign(User user)
        {
            bool isSuccess = false;
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", user.Id);
            param.Add("@Username", user.Username);
            param.Add("@Realname", user.Realname);
            param.Add("@pwd", user.Pwd);
            param.Add("@Enabled", user.Enabled);
            param.Add("@Creationtime", user.Creationtime);
            param.Add("@RoleType", user.RoleType);
            var count = await connection.ExecuteAsync("INSERT INTO User VALUES (@Id,@Username,@Realname,@pwd,@Enabled,@Creationtime,@RoleType)", param);
            if (count == 1)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public async Task<bool> EditUser(Guid id, string usermane, string pwd, bool isEnable, RoleType roleType)
        {
            bool isSuccess = false;
            var count = await connection.ExecuteAsync("UPDATE User Set username = @username ,pwd = @pwd,Enabled = @isEnable ,RoleType = @roleType WHERE id = @id",
                new { id = id, username = usermane, pwd = pwd, isEnable = isEnable , roleType = roleType });
            if (count == 1)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
