using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class SmsVM
    {
        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        public string MessageId { get; set; }

        // status 改为单个对象，而不是列表
        public Status Status { get; set; }

        public string To { get; set; }
    }

    public class Status
    {
        public string Description { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }

}
