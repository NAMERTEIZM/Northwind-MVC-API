using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategorySelectDTO>().ReverseMap();
            
        }
    }
}
