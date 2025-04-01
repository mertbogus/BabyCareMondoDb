using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.ServiceDto;
using BabyCare.Dtos.TestimonialDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
           _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(testimonial);
        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x=>x.TestimonialId==id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var values = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<UpdateTestimonialDto> GetTestimonialAsync(string id)
        {
            var service = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateTestimonialDto>(service);
        }

        public async Task<List<ResultUITestimonialDto>> GetAllUIAsync()
        {
            var values = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultUITestimonialDto>>(values);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(X => X.TestimonialId == testimonial.TestimonialId, testimonial);
        }
    }
}
