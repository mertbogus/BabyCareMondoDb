using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.ContactDto;

namespace BabyCare.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
             CreateMap<Contact, ResultContactDto>().ReverseMap();
             CreateMap<Contact, ResultUIContactDto>().ReverseMap();
             CreateMap<Contact, CreateContactDto>().ReverseMap();
             CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
