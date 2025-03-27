using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.DataAccess.Settings;
using BabyCare.Dtos.ProductDto;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCare.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            var product= _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAll()
        {
            var values = await _productCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<UpdateProductDto> GetById(string id)
        {
            var product = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateProductDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
           var products= _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId==products.ProductId, products);
        }
    }
}
