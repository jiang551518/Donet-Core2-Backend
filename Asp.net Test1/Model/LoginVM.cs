using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class LoginVM
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string JwtToken { get; set; }

        public bool Enable { get; set; }

    }
}