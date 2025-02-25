using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class WeatherItem
    {
        /// <summary>
        /// 预报发布时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 查询城市基本资料
        /// </summary>
        public CityWeather cityInfo { get; set; }

        //所查询当天及包括当天往后一周的数据
        public NowDetail now { get; set; }
        public DayDetail f1 { get; set; }
        public DayDetail f2 { get; set; }
        public DayDetail f3 { get; set; }
        public DayDetail f4 { get; set; }
        public DayDetail f5 { get; set; }
        public DayDetail f6 { get; set; }
        public DayDetail f7 { get; set; }

        public int ret_code { get; set; }
    }

    public class CityWeather
    {
        /// <summary>
        /// 区域id
        /// </summary>
        public string c1 { get; set; }

        /// <summary>
        /// 城市英文名
        /// </summary>
        public string c2 { get; set; }

        /// <summary>
        /// 城市中文名
        /// </summary>
        public string c3 { get; set; }

        /// <summary>
        /// 城市所在市英文名
        /// </summary>
        public string c4 { get; set; }

        /// <summary>
        /// 城市所在市中文名
        /// </summary>
        public string c5 { get; set; }

        /// <summary>
        /// 城市所在省英文名
        /// </summary>
        public string c6 { get; set; }

        /// <summary>
        /// 城市所在省中文名
        /// </summary>
        public string c7 { get; set; }

        /// <summary>
        /// 城市所在国家英文名
        /// </summary>
        public string c8 { get; set; }

        /// <summary>
        /// 城市所在国家中文名
        /// </summary>
        public string c9 { get; set; }

        /// <summary>
        /// 城市级别
        /// </summary>
        public string c10 { get; set; }

        /// <summary>
        /// 城市区号
        /// </summary>
        public string c11 { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string c12 { get; set; }

        /// <summary>
        /// 海拔
        /// </summary>
        public string c15 { get; set; }

        /// <summary>
        /// 雷达站号
        /// </summary>
        public string c16 { get; set; }

        public string c17 { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public float latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public float longitude { get; set; }

    }

    public class NowDetail
    {
        /// <summary>
        /// 风向
        /// </summary>
        public string wind_direction { get; set; }

        /// <summary>
        /// 空气指数，越小越好
        /// </summary>
        public string aqi { get; set; }

        /// <summary>
        /// 天气小图标
        /// </summary>
        public string weather_pic { get; set; }

        /// <summary>
        /// 风力
        /// </summary>
        public string wind_power { get; set; }

        /// <summary>
        /// 获得气温的时间
        /// </summary>
        public string temperature_time { get; set; }

        /// <summary>
        /// 天气编码
        /// </summary>
        public string weather_code { get; set; }

        /// <summary>
        /// 气温
        /// </summary>
        public string temperature { get; set; }

        /// <summary>
        /// 空气湿度
        /// </summary>
        public string sd { get; set; }

        /// <summary>
        /// aqi明细数据
        /// </summary>
        public AqiDetail aqiDetail { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string weather { get; set; }
    }

    public class AqiDetail
    {
        /// <summary>
        /// 空气质量指数类别，有“优、良、轻度污染、中度污染、重度污染、严重污染”6类
        /// </summary>
        public string quality { get; set; }

        /// <summary>
        /// 空气质量指数，越小越好
        /// </summary>
        public string aqi { get; set; }

        /// <summary>
        /// 颗粒物（粒径小于等于10μm）1小时平均
        /// </summary>
        public string pm10 { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string area { get; set; }

        /// <summary>
        /// 一氧化碳一小时平均
        /// </summary>
        public string co { get; set; }

        /// <summary>
        /// 臭氧1小时平均
        /// </summary>
        public string o3 { get; set; }

        /// <summary>
        /// 二氧化硫1小时平均
        /// </summary>
        public string so2 { get; set; }

        /// <summary>
        /// 二氧化氮1小时平均
        /// </summary>
        public string no2 { get; set; }

        /// <summary>
        /// 首要污染物
        /// </summary>
        public string primary_pollutant { get; set; }

        /// <summary>
        /// 臭氧8小时平均
        /// </summary>
        public string o3_8h { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string num { get; set; }

        /// <summary>
        /// 颗粒物（粒径小于等于2.5μm）1小时平均
        /// </summary>
        public string pm2_5 { get; set; }
    }
    public class DayDetail
    {
        /// <summary>
        /// 白天风力编号
        /// </summary>
        public string day_wind_power { get; set; }

        /// <summary>
        /// 晚上风力编号
        /// </summary>
        public string night_wind_power { get; set; }

        /// <summary>
        /// 晚上的天气编码
        /// </summary>
        public string night_weather_code { get; set; }

        /// <summary>
        /// 白天天气
        /// </summary>
        public string day_weather { get; set; }

        /// <summary>
        /// 日出日落时间(中间用|分割)
        /// </summary>
        public string sun_begin_end { get; set; }

        /// <summary>
        /// 大气压
        /// </summary>
        public string air_press { get; set; }

        /// <summary>
        /// 白天的天气编码
        /// </summary>
        public string day_weather_code { get; set; }

        /// <summary>
        /// 降水概率
        /// </summary>
        public string jiangshui { get; set; }

        /// <summary>
        /// 晚上天气图标
        /// </summary>
        public string night_weather_pic { get; set; }

        /// <summary>
        /// 晚上天气
        /// </summary>
        public string night_weather { get; set; }

        /// <summary>
        /// 当前天
        /// </summary>
        public string day { get; set; }

        /// <summary>
        /// 白天风向
        /// </summary>
        public string day_wind_direction { get; set; }

        /// <summary>
        /// 晚上风向
        /// </summary>
        public string night_wind_direction { get; set; }

        /// <summary>
        /// 星期几
        /// </summary>
        public int weekday { get; set; }

        /// <summary>
        /// 紫外线强度
        /// </summary>
        public string ziwaixian { get; set; }

        /// <summary>
        /// 晚上天气温度(摄氏度)
        /// </summary>
        public string night_air_temperature { get; set; }

        /// <summary>
        /// 白天天气图标
        /// </summary>
        public string day_weather_pic { get; set; }

        /// <summary>
        /// 白天天气温度(摄氏度)
        /// </summary>
        public string day_air_temperature { get; set; }

        /// <summary>
        /// 指数数据
        /// </summary>
        public WeatherIndex index { get; set; }
    }

    public class WeatherIndex
    {
        /// <summary>
        /// 洗车指数
        /// </summary>
        public IndexDetail wash_car { get; set; }
    }

    public class IndexDetail
    {

        public string title { get; set; }

        public string desc { get; set; }
    }
}
