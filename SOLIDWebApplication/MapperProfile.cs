using System;
using AutoMapper;
using SOLIDWebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonDTO>();           
        }
    }
}
