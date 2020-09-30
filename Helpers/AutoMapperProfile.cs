using System;
using AutoMapper;
using First.DTOs;
using First.Entities;

namespace First.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genre, GenreDTO>();
        }
    }
}
