using BabyCare.Dtos.HeroDto;
using BabyCare.Dtos.HeroDto;

namespace BabyCare.Services.IHeroServices
{
    public interface IHeroService
    {
        Task<List<ResultHeroDto>> GetAllHeroAsync();

        Task<UpdateHeroDto> GetHeroAsync(string id);

        Task CreateHeroAsync(CreateHeroDto createHeroDto);
        Task UpdateHeroAsync(UpdateHeroDto updateHeroDto);

        Task DeleteHeroAsync(string id);
    }
}
