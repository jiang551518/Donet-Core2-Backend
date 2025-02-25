using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class WeatherVM
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WeatherResultVM result { get; set; }
    }

    public class WeatherResultVM
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string week { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string weather { get; set; }

        /// <summary>
        /// 气温
        /// </summary>
        public string temp { get; set; }

        /// <summary>
        /// 最高气温
        /// </summary>
        public string temphigh { get; set; }

        /// <summary>
        /// 最低气温
        /// </summary>
        public string templow { get; set; }

        /// <summary>
        /// 图片数字
        /// </summary>
        public string img { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatetime { get; set; }
    }
}
