using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.HeroDto;
using BabyCare.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.Controllers
{
     [Area("Admin")]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutService.GetAboutAsync(id);
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
