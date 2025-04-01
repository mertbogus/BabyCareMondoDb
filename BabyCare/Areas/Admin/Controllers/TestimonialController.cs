using AutoMapper;
using BabyCare.Dtos.ProductDto;
using BabyCare.Dtos.ServiceDto;
using BabyCare.Dtos.TestimonialDto;
using BabyCare.Services.IImageServices;
using BabyCare.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialService _testimonialService, IImageService _ımageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto.ImageFile != null)
            {
                try
                {
                    createTestimonialDto.CommenterImage = await _ımageService.SaveImage(createTestimonialDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(createTestimonialDto);
                }

            }
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonialAsync(id);
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            if (updateTestimonialDto.ImageFile != null)
            {
                try
                {
                    updateTestimonialDto.CommenterImage = await _ımageService.SaveImage(updateTestimonialDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateTestimonialDto);
                }

            }
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
