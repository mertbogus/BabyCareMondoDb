using BabyCare.Dtos.InstructorDto;

namespace BabyCare.Services.InstructorServices
{
    public interface IInstructorService
    {
        Task<List<ResultInstructorDto>> GetAllInstructorAsync();

        Task<UpdateInstructorDto> GetInstructorAsync(string id);

        Task CreateInstructorAsync(CreateInstructorDto createInstructorDto);
        Task UpdateInstructorAsync(UpdateInstructorDto updateInstructorDto);

        Task DeleteInstructorAsync(string id);

        Task<List<ResultUIInstructorDto>> GetAllUIInstructorAsync();
    }
}
