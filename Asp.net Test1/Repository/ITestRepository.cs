using System;
using System.Data;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public interface ITestRepository
    {
        Task<TestVM> GetList();

        Task<User> GetUserDetail(string usermane, string pwd);

        Task<bool> Sign(User user);

        Task<bool> EditUser(Guid id,string username, string pwd, bool isEnable);
    }
}
