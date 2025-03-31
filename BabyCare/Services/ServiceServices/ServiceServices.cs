using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ServiceDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.ServiceServices
{
    public class ServiceServices : IServiceServices
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        private readonly IMapper _mapper;

        public ServiceServices(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var service = _mapper.Map<Service>(createServiceDto);
             await _serviceCollection.InsertOneAsync(service);
        }

        public async Task DeleteServiceAsync(string id)
        {
            await _serviceCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            var values = await _serviceCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<UpdateServiceDto> GetServiceAsync(string id)
        {
            var service = await _serviceCollection.Find(x => x.ServiceId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateServiceDto>(service);
        }

        public async Task<List<ResultUIServiceDto>> GetServiceUItAsync()
        {
            var values = await _serviceCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultUIServiceDto>>(values);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            var service = _mapper.Map<Service>(updateServiceDto);
            await _serviceCollection.FindOneAndReplaceAsync(X => X.ServiceId == service.ServiceId, service);
        }
    }
}
