using System;
using System.Collections.Generic;
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

        Task<List<TestExportVM>> GetListExport();

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <returns></returns>
        Task<User> GetUserDetail(string usermane);

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

        Task<SmsVM> Post();
    }
}
