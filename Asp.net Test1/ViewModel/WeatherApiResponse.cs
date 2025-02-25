using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class WeatherApiResponse<T>
    {
        /// <summary>
        /// 错误内容
        /// </summary>
        public string showapi_res_error { get; set; }

        /// <summary>
        /// 错误Id
        /// </summary>
        public string showapi_res_id { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int showapi_res_code { get; set; }

        /// <summary>
        /// 返回对象
        /// </summary>
        public T showapi_res_body { get; set; }
    }
}
