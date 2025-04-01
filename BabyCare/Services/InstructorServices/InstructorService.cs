using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.InstructorDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.InstructorServices
{
    public class InstructorService : IInstructorService
    {
        private readonly IMongoCollection<Instructor> _instractorCollection;
        private readonly IMapper _mapper;

        public InstructorService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _instractorCollection = database.GetCollection<Instructor>(databaseSettings.InstructorCollectionName);
        }

        public async Task CreateInstructorAsync(CreateInstructorDto createInstructorDto)
        {
            var instructor=_mapper.Map<Instructor>(createInstructorDto);
            await _instractorCollection.InsertOneAsync(instructor);
        }

        public async Task DeleteInstructorAsync(string id)
        {
            await _instractorCollection.DeleteOneAsync(x=>x.InstructorId==id);
        }

        public async Task<List<ResultInstructorDto>> GetAllInstructorAsync()
        {
            var values= await _instractorCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultInstructorDto>>(values);
        }

  
        public async Task<UpdateInstructorDto> GetInstructorAsync(string id)
        {
            var instructor = await _instractorCollection.Find(x => x.InstructorId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateInstructorDto>(instructor);
            
        }

        public async Task UpdateInstructorAsync(UpdateInstructorDto updateInstructorDto)
        {
            var instructor=_mapper.Map<Instructor>(updateInstructorDto);
            await _instractorCollection.FindOneAndReplaceAsync(X => X.InstructorId == instructor.InstructorId, instructor);
        }

        async Task<List<ResultUIInstructorDto>> IInstructorService.GetAllUIInstructorAsync()
        {
            var values = await _instractorCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultUIInstructorDto>>(values);
        }
    }
}
