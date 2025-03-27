using BabyCare.Dtos.InstructorDto;
using BabyCare.Dtos.ProductDto;
using BabyCare.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.Controllers
{
    public class ProductController(IProductService _productService) : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            var values=_productService.GetAll();
            return View(values);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateAsync(createProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = await _productService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
