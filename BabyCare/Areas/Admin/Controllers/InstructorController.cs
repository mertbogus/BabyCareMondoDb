using BabyCare.Dtos.InstructorDto;
using BabyCare.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _ınstructorService) : Controller
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
            var value= await _ınstructorService.GetInstructorAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto updateInstructorDto)
        {
            await _ınstructorService.UpdateInstructorAsync(updateInstructorDto);
            return RedirectToAction("Index");
        }

    }
}
