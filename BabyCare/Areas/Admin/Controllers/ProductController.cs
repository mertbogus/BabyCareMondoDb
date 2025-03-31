using BabyCare.Dtos.InstructorDto;
using BabyCare.Dtos.ProductDto;
using BabyCare.Services.IImageServices;
using BabyCare.Services.InstructorServices;
using BabyCare.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService, IInstructorService _instructorService, IImageService _ımageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAll();
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateProduct()
        {
            var instructors = await _instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto.ImageFile != null)
            {
                try
                {
                    createProductDto.ImageUrl = await _ımageService.SaveImage(createProductDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(createProductDto);
                }

            }

            await _productService.CreateAsync(createProductDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            var instructors = await _instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();

            var value = await _productService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (updateProductDto.ImageFile != null)
            {
                try
                {
                    updateProductDto.ImageUrl = await _ımageService.SaveImage(updateProductDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateProductDto);
                }

            }
            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
