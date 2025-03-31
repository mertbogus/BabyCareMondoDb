using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.EventDto;

namespace BabyCare.Mappings
{
    public class EventMapping:Profile
    {
        public EventMapping()
        {
            CreateMap<Event, ResultEventDto>().ReverseMap();
            CreateMap<Event, ResultUIEventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<Event, UpdateEventDto>().ReverseMap();
        }
    }
}
