using BabyCare.Dtos.HeroDto;
using BabyCare.Dtos.ProductDto;
using BabyCare.Services.IHeroServices;
using BabyCare.Services.IImageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroController(IHeroService _heroService, IImageService _ımageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _heroService.GetAllHeroAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteHero(string id)
        {
            await _heroService.DeleteHeroAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateHero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(CreateHeroDto createHeroDto)
        {
            if (createHeroDto.ImageFile != null)
            {
                try
                {
                    createHeroDto.ImageUrl = await _ımageService.SaveImage(createHeroDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(createHeroDto);
                }

            }
            await _heroService.CreateHeroAsync(createHeroDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateHero(string id)
        {
            var value = await _heroService.GetHeroAsync(id);
            return View(value);
           
        }

        [HttpPost]

        public async Task<IActionResult> UpdateHero(UpdateHeroDto updateHeroDto)
        {
            if (updateHeroDto.ImageFile != null)
            {
                try
                {
                    updateHeroDto.ImageUrl = await _ımageService.SaveImage(updateHeroDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateHeroDto);
                }

            }
            await _heroService.UpdateHeroAsync(updateHeroDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
