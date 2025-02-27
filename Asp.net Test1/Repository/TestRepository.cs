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

        public async Task<User> GetDetail(Guid id)
        {
            var result = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM User WHERE Id = @id AND IsDeleted = false ;", new { id = id });
            
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
            param.Add("@ExcelPasswd", user.ExcelPasswd);
            var count = await connection.ExecuteAsync("INSERT INTO User VALUES (@Id,@Username,@Realname,@pwd,@Enabled,@Creationtime,@RoleType,@ExcelPasswd)", param);
            if (count == 1)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public async Task<bool> EditUser(Guid id, string usermane, string pwd, bool isEnable, RoleType roleType,User user,string excelPasswd)
        {
            bool isSuccess = false;
            var LastModificationTime = DateTime.Now;
            var count = await connection.ExecuteAsync("UPDATE User Set username = @username ,pwd = @pwd,Enabled = @isEnable ,RoleType = @roleType,LastModificationTime = @LastModificationTime ,LastModifierUserId = @LastModifierUserId ,ExcelPasswd = @excelPasswd WHERE id = @id",
                new { id = id, username = usermane, pwd = pwd, isEnable = isEnable , roleType = roleType , LastModificationTime = LastModificationTime , LastModifierUserId = user.Id , excelPasswd = excelPasswd});
            if (count == 1)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public async Task UpdateLoginNowTime(Guid id)
        {
            var LoginNowTime = DateTime.Now;
            await connection.ExecuteAsync("UPDATE User SET LoginNowTime = @loginNowTime WHERE Id = @Id", new { id = id , loginNowTime = LoginNowTime });
        }

        public async Task<bool> UpdateIsDelete(Guid id, User user)
        {
            bool isSuccess = false;
            var IsDeleted = true;
            var DeletedTime = DateTime.Now;
            var count = await connection.ExecuteAsync("UPDATE User SET IsDeleted = @isDeleted ,DeletedTime = @deletedTime,DeleterUserId = @deleterUserId WHERE Id = @Id",
                new { id = id, isDeleted = IsDeleted, deletedTime = DeletedTime , deleterUserId = user.Id });
            if (count == 1)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
