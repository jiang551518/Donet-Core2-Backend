using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class TestService : ITestService
    {
        protected ITestRepository _testRepository;
        public const string GetWeatherUrl = "https://saweather.market.alicloudapi.com/area-to-weather";
        public const string AppCode = "b58acb361f2a4a5aa5c386a3e9d114df";
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        /// <summary>
        /// 测试列表
        /// </summary>
        /// <returns></returns>
        public async Task<TestVM> GetList()
        {
            var result = await _testRepository.GetList();

            return result;
        }

        /// <summary>
        /// 查看用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<User> GetUserDetail(string usermane,string pwd)
        {
            var result = await _testRepository.GetUserDetail(usermane,pwd);
            return result;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> Sign(User user)
        {
            user.Id = Guid.NewGuid();
            user.Creationtime = DateTime.Now;
            var isSuccess = await _testRepository.Sign(user);
            return isSuccess;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public async Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable)
        {
            var isSuccess = await _testRepository.EditUser(id, username, pwd, isEnable);
            return isSuccess;
        }

        /// <summary>
        /// 天气
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherApiResponse<WeatherItem>> GetWeather(string city)
        {
            var result = new WeatherApiResponse<WeatherItem>();
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "APPCODE " + AppCode);
            int needIndex = 1;
            int needMoreDay = 1;
            var response = await http.GetAsync(GetWeatherUrl + $"?area={city}&needIndex={needIndex}&needMoreDay={needMoreDay}");
            if (response.IsSuccessStatusCode)
            {
                var ContentText = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<WeatherApiResponse<WeatherItem>>(ContentText);
            }
            return result;
        }
    }
}
