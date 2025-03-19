using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public interface ITestRepository
    {
        Task<TestVM> GetList();

        Task<User> GetUserDetail(string usermane);

        Task<User> GetDetail(Guid id);

        Task<List<User>> GetUserList(string username, bool? enabled);

        Task<bool> Sign(User user);

        Task<bool> EditUser(Guid id,string username, string pwd, bool isEnable, RoleType roleType,User user ,string excelPasswd);

        Task UpdateLoginNowTime(Guid id);

        Task<bool> UpdateIsDelete(Guid id, User user);
    }
}
