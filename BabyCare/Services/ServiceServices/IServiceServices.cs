using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ServiceDto;

namespace BabyCare.Services.ServiceServices
{
    public interface IServiceServices
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();

        Task<UpdateServiceDto> GetServiceAsync(string id);

        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);

        Task DeleteServiceAsync(string id);

        Task<List<ResultUIServiceDto>> GetServiceUItAsync();
    }
}
