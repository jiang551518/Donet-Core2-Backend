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

        public async Task<TestVM> GetList()
        {
            var result = await _testRepository.GetList();

            return result;
        }

        public async Task<User> GetUserDetail(string usermane,string pwd)
        {
            var result = await _testRepository.GetUserDetail(usermane,pwd);
            return result;
        }

        public async Task<bool> Sign(User user)
        {
            user.Id = Guid.NewGuid();
            user.Creationtime = DateTime.Now;
            var isSuccess = await _testRepository.Sign(user);
            return isSuccess;
        }

        public async Task<bool> EditUser(Guid id, string username, string pwd, bool isEnable)
        {
            var isSuccess = await _testRepository.EditUser(id, username, pwd, isEnable);
            return isSuccess;
        }

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
