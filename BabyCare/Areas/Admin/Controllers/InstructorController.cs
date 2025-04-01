using BabyCare.Dtos.EventDto;
using BabyCare.Dtos.InstructorDto;
using BabyCare.Dtos.ProductDto;
using BabyCare.Services.IImageServices;
using BabyCare.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _ınstructorService, IImageService _imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _ınstructorService.GetAllInstructorAsync();
            return View(values);
        }

        public IActionResult CreateInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor(CreateInstructorDto createInstructorDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(createInstructorDto);
            }
            if (createInstructorDto.ImageFile != null)
            {
                try
                {
                    createInstructorDto.ImageUrl = await _imageService.SaveImage(createInstructorDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(createInstructorDto);
                }

            }
            await _ınstructorService.CreateInstructorAsync(createInstructorDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await _ınstructorService.DeleteInstructorAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateInstructor(string id)
        {

            var value = await _ınstructorService.GetInstructorAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto updateInstructorDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(updateInstructorDto);
            }

            // Eğer yeni bir resim seçilmişse, resim işlemi yapılacak
            if (updateInstructorDto.ImageFile != null)
            {
                try
                {
                    // Yeni resmi kaydet ve URL'yi güncelle
                    updateInstructorDto.ImageUrl = await _imageService.SaveImage(updateInstructorDto.ImageFile);
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateInstructorDto);
                }
            }
            // Eğer yeni bir resim seçilmemişse, mevcut resmi koruyalım
            else
            {
                // Mevcut ImageUrl'i koruyarak sadece diğer bilgileri güncelle
                var existingInstructor = await _ınstructorService.GetInstructorAsync(updateInstructorDto.InstructorId);
                if (existingInstructor != null)
                {
                    updateInstructorDto.ImageUrl = existingInstructor.ImageUrl;
                }
            }

            await _ınstructorService.UpdateInstructorAsync(updateInstructorDto);
            return RedirectToAction("Index");
        }
    }
}