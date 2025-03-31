using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.EventDto;
using BabyCare.Dtos.InstructorDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMapper _mapper;

        public EventService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _eventCollection = database.GetCollection<Event>(databaseSettings.EventCollectionName);
        }
        public async Task CreateEventAsync(CreateEventDto createEventDto)
        {
            var events = _mapper.Map<Event>(createEventDto);
            await _eventCollection.InsertOneAsync(events);
        }

        public async Task DeleteEventAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(x=>x.EventId==id);
        }

        public async Task<UpdateEventDto> GetEventAsync(string id)
        {
            var events = await _eventCollection.Find(x => x.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateEventDto>(events);
        }

        public async Task<List<ResultEventDto>> GetAllEventAsync()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(values);
        }

        public async Task UpdateEventAsync(UpdateEventDto updateEventDto)
        {
            var events = _mapper.Map<Event>(updateEventDto);
            await _eventCollection.FindOneAndReplaceAsync(X => X.EventId == events.EventId, events);
        }

        public async Task<List<ResultUIEventDto>> GetEventUIAsync()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultUIEventDto>>(values);
        }
    }
}
