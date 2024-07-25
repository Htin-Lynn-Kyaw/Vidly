using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(dest => dest.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MovieDto, Movie>().ForMember(dest => dest.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
        }
    }
}