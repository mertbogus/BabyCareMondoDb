using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.HeroDto;

namespace BabyCare.Mappings
{
    public class HeroMapping : Profile
    {
        public HeroMapping()
        {
            CreateMap<Hero, ResultHeroDto>().ReverseMap();
            CreateMap<Hero, CreateHeroDto>().ReverseMap();
            CreateMap<Hero, UpdateHeroDto>().ReverseMap();
            CreateMap<Hero, UIResultHeroDto>().ReverseMap();
        }
    }
}
