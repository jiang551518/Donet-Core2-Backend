using System;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public interface ITestService
    {
        Task<TestVM> GetList();

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Task<User> GetUserDetail(string usermane, string pwd);

        Task<bool> Sign(User user);

        Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable);

        Task<WeatherApiResponse<WeatherItem>> GetWeather(string city);
    }
}
