using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class BaseResponse
    {
        public string errorMessage { get; set; }
        public string errorCode { get; set; }
        public bool success { get; set; }
        public object data { get; set; }
    }
}
