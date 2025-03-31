using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.ServiceDto;

namespace BabyCare.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
               CreateMap<Service, ResultServiceDto>().ReverseMap();
               CreateMap<Service, ResultUIServiceDto>().ReverseMap();
               CreateMap<Service, CreateServiceDto>().ReverseMap();
               CreateMap<Service, UpdateServiceDto>().ReverseMap();
        }
    }
}
