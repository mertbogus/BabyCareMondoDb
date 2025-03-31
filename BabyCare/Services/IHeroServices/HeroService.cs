using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.HeroDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.IHeroServices
{
    public class HeroService : IHeroService
    {
        private readonly IMongoCollection<Hero> _heroCollection;
        private readonly IMapper _mapper;

        public HeroService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _heroCollection = database.GetCollection<Hero>(databaseSettings.HeroCollectionName);
        }
        public async Task CreateHeroAsync(CreateHeroDto createHeroDto)
        {
            var hero = _mapper.Map<Hero>(createHeroDto);
            await _heroCollection.InsertOneAsync(hero);
        }

        public async Task DeleteHeroAsync(string id)
        {
            await _heroCollection.DeleteOneAsync(x=>x.HeroId==id);
        }

        public async Task<List<ResultHeroDto>> GetAllHeroAsync()
        {
            var values = await _heroCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultHeroDto>>(values);
        }

        public async Task<UpdateHeroDto> GetHeroAsync(string id)
        {
            var hero = await _heroCollection.Find(x =>x.HeroId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateHeroDto>(hero);
        }

        public async Task UpdateHeroAsync(UpdateHeroDto updateHeroDto)
        {
            var hero = _mapper.Map<Hero>(updateHeroDto);
            await _heroCollection.FindOneAndReplaceAsync(X => X.HeroId == hero.HeroId, hero);
        }
    }
}
