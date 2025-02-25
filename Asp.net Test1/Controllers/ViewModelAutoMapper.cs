using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class ViewModelAutoMapper : Profile
    {
        public ViewModelAutoMapper()
        {
            CreateMap<SignVM, User>();
        }
    }
}
