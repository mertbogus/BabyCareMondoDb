using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.EventDto;

namespace BabyCare.Services.EventServices
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetAllEventAsync();

        Task<UpdateEventDto> GetEventAsync(string id);

        Task CreateEventAsync(CreateEventDto createEventDto);
        Task UpdateEventAsync(UpdateEventDto updateEventDto);

        Task DeleteEventAsync(string id);

        Task<List<ResultUIEventDto>> GetEventUIAsync();
    }
}
