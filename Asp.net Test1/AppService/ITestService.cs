using System;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public interface ITestService
    {
        /// <summary>
        /// 测试列表
        /// </summary>
        /// <returns></returns>
        Task<TestVM> GetList();

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Task<User> GetUserDetail(string usermane, string pwd);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Sign(User user);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable);

        /// <summary>
        /// 天气
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<WeatherApiResponse<WeatherItem>> GetWeather(string city);
    }
}
