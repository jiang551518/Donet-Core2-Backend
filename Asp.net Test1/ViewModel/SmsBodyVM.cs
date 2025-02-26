using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class SmsBodyVM
    {
        public List<MessageBody> Messages { get; set; }
    }

    public class MessageBody
    {
        public List<Destination> Destinations { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
    }

    public class Destination
    {
        public string To { get; set; }
    }
}
