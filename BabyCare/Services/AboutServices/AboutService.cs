using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.HeroDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(about);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<UpdateAboutDto> GetAboutAsync(string id)
        {
            var about = await _aboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateAboutDto>(about);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _aboutCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<ResultUIAboutDto> GetFirstAboutAsync()
        {
            var values = await _aboutCollection.AsQueryable().FirstOrDefaultAsync();
            return _mapper.Map<ResultUIAboutDto>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var About = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(X => X.AboutId == About.AboutId, About);
        }
    }
}
