using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public const string GetSmsUrl = "https://wgkk6r.api.infobip.com/sms/2/text/advanced";
        public const string AppCode = "b58acb361f2a4a5aa5c386a3e9d114df";
        public const string token = "App 88243c54253684ef21008f5db315f7d9-d786b9c2-3d90-477c-a7b8-ad13019f03c4";
        private static readonly HttpClient client = new HttpClient();
        protected IMapper _mapper { get; set; }

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
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

        public async Task<List<TestExportVM>> GetListExport()
        {
            var list = await _testRepository.GetList();
            var mapperList = _mapper.Map<List<TestExportVM>>(list.Tests);
            return mapperList;
        }

        /// <summary>
        /// 查看用户详情
        /// </summary>
        /// <param name="usermane"></param>
        /// <returns></returns>
        public async Task<User> GetUserDetail(string usermane)
        {
            var result = await _testRepository.GetUserDetail(usermane);
            return result;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> Sign(User user)
        {
            var userDetail = await _testRepository.GetUserDetail(user.Username);
            if (userDetail != null) { throw new Exception("用户名已存在"); };

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
        public async Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable, RoleType roleType)
        {
            var userDetail = await _testRepository.GetUserDetail(username);
            if (userDetail != null) { throw new Exception("用户名已存在"); };
            var isSuccess = await _testRepository.EditUser(id, username, pwd, isEnable, roleType);
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
