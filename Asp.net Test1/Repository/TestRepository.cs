using Dapper;
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
        public TestRepository()
        {
            conn = "Data Source=127.0.0.1;port=3306;user id=root;password=root;Initial Catalog=test;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;sslmode=none;";
        }

        public async Task<TestVM> GetList()
        {
            var result = new TestVM();

            using (var connection = new MySqlConnection(conn))
            {
                result.Tests = (await connection.QueryAsync<Test>("SELECT * FROM Test;")).ToList();
            }

            return result;

        }

        public async Task<User> GetUserDetail(string usermane, string pwd)
        {
            var result = new User();
            using (var connection = new MySqlConnection(conn))
            {
                result = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM User WHERE username = @username AND pwd = @pwd;", new { username = usermane, pwd = pwd });
                
            }
            return result;
        }

        public async Task<bool> Sign(User user)
        {
            bool isSuccess = false;
            using (var connection = new MySqlConnection(conn))
            {
                var count = await connection.ExecuteAsync("INSERT INTO User VALUES (@id,@username,@pwd,@isEnable,@creationtime)", new { id = user.Id,username = user.username, pwd = user.pwd ,isEnable = user.Enabled , creationtime = user.Creationtime });
                if (count == 1)
                {
                    isSuccess = true;
                }

            }
            return isSuccess;
        }

        public async Task<bool> EditUser(Guid id, string usermane, string pwd, bool isEnable)
        {
            bool isSuccess = false;
            using (var connection = new MySqlConnection(conn))
            {
                var count = await connection.ExecuteAsync("UPDATE User Set username = @username ,pwd = @pwd,Enabled = @isEnable WHERE id = @id", new { id = id, username = usermane, pwd = pwd, isEnable = isEnable});
                if (count == 1)
                {
                    isSuccess = true;
                }

            }
            return isSuccess;
        }
    }
}
