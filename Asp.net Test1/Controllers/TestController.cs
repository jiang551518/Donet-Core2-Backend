using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using MiniExcelLibs;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        protected ITestService _testService { get; set; }
        public TestController(ITestService testService, Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration)
        {
            _testService = testService;
        }

        /// <summary>
        /// 测试列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public async Task<TestVM> GetList()
        {
            var result = await _testService.GetList();
            return result;
        }

        /// <summary>
        /// 测试列表导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListExport")]
        public async Task<IActionResult> GetListExport()
        {
            var exportData = await _testService.GetListExport();
            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(exportData);
            memoryStream.Seek(0, SeekOrigin.Begin);
            HttpContext.Response.Headers.Clear();
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            HttpContext.Response.Headers.Add("Content-Disposition", $"attachment;filename={DateTime.Now.ToString("yyyyMMddhhmmss")}.xlsx");
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        /// <summary>
        /// 查看天气
        /// </summary>
        /// <param name="city">城市</param>
        /// <returns></returns>
        [HttpGet("GetWeather")]
        public async Task<WeatherVM> GetWeather(string city)
        {
            var result = await _testService.GetWeather(city);
            if (result.showapi_res_code == 0)
            {
                var response = new WeatherVM()
                {
                    status = "0",
                    msg = "ok"
                };
                response.result = new WeatherResultVM()
                {
                    city = result.showapi_res_body.cityInfo.c3,
                    date = DateTime.Now.Date.ToString(),
                    week = DateTime.Now.DayOfWeek.ToString(),
                    weather = result.showapi_res_body.now.weather,
                    temp = result.showapi_res_body.now.temperature,
                    temphigh = result.showapi_res_body.f1.day_air_temperature,
                    templow = result.showapi_res_body.f1.night_air_temperature,
                    img = result.showapi_res_body.now.weather_pic,
                    updatetime = result.showapi_res_body.now.temperature_time,
                };
                return response;
            }
            else
                return null;
        }

        /// <summary>
        /// 发送短信（但api服务商试用不了）
        /// </summary>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<SmsVM> Post()
        {
            var result = await _testService.Post();
            return result;
        }
    }
}
