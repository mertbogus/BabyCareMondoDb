using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.HeroDto;

namespace BabyCare.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();

        Task<UpdateAboutDto> GetAboutAsync(string id);

        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);

        Task DeleteAboutAsync(string id);

        Task<ResultUIAboutDto> GetFirstAboutAsync();
    }
}
