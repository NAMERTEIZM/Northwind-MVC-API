using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Mappers
{
    public class Mapper : Profile
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
                cfg.CreateMap<TSource, TDestination>().ReverseMap();
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
    }
}

