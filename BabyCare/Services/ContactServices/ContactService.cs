using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ContactDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;
        public ContactService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var about = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(about);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x=>x.ContactId==id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values); ;
        }

        public async Task<UpdateContactDto> GetContactAsync(string id)
        {
            var contact = await _contactCollection.Find(x => x.ContactId== id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateContactDto>(contact);
        }

        public async Task<ResultUIContactDto> GetFirstContactAsync()
        {
            var values = await _contactCollection.AsQueryable().FirstOrDefaultAsync();
            return _mapper.Map<ResultUIContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(X => X.ContactId == contact.ContactId, contact);
        }
    }
}
