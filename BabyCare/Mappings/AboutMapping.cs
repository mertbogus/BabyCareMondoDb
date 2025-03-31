using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.AboutDto;

namespace BabyCare.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
              CreateMap<About, ResultAboutDto>().ReverseMap();
              CreateMap<About, CreateAboutDto>().ReverseMap();
              CreateMap<About, UpdateAboutDto>().ReverseMap();
              CreateMap<About, ResultUIAboutDto>().ReverseMap();
        }
    }
}
