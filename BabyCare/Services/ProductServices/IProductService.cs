using BabyCare.Dtos.ProductDto;

namespace BabyCare.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAll();

        Task<UpdateProductDto> GetById(string id);

        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);

        Task DeleteAsync(string id);
    }
}
