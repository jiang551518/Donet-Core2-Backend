using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class SignVM
    {
        public Guid? Id { get; set; }

        public string Username { get; set; }

        public string Pwd { get; set; }

        public bool? IsEnable { get; set; }
    }
}
