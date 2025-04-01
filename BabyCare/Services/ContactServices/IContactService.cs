using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ContactDto;

namespace BabyCare.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();

        Task<UpdateContactDto> GetContactAsync(string id);

        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);

        Task DeleteContactAsync(string id);

        Task<ResultUIContactDto> GetFirstContactAsync();
    }
}
