using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class User
    {
        public Guid Id { get; set; }

        public string username { get;set; }

        public string pwd { get; set; }

        [JsonProperty("Enable")]
        public bool Enabled { get; set; }

        public DateTime Creationtime { get; set; }
    }
}
