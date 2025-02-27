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
        /// 通过用户名获取用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <returns></returns>
        Task<User> GetUserDetail(string usermane);

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetDetail(Guid id);

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
        Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable, RoleType roleType,User user);

        /// <summary>
        /// 天气
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<WeatherApiResponse<WeatherItem>> GetWeather(string city);

        /// <summary>
        /// 更新登录时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateLoginNowTime(Guid id);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateIsDelete(Guid id, User user);
    }
}
