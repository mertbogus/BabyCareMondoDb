using BabyCare.Dtos.ServiceDto;
using BabyCare.Dtos.TestimonialDto;

namespace BabyCare.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();

        Task<UpdateTestimonialDto> GetTestimonialAsync(string id);

        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);

        Task DeleteTestimonialAsync(string id);

        Task<List<ResultUITestimonialDto>> GetAllUIAsync();
    }
}
