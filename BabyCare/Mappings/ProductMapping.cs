using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.ProductDto;

namespace BabyCare.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultUIProductDto>().ReverseMap();

        }
    }
}
