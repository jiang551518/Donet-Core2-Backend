using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class TestVM
    {
        public List<Test> Tests { get; set; }
    }

    public class Test
    {
        /// <summary>
        /// 积分
        /// </summary>
       public int Integral { get; set; }

        /// <summary>
        /// 获取时间
        /// </summary>
       public DateTime IntTime { get; set; }

    }
}
