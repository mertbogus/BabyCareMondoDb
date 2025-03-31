using BabyCare.Dtos.EventDto;
using BabyCare.Dtos.ProductDto;
using BabyCare.Services.EventServices;
using BabyCare.Services.IImageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController(IEventService _eventService, IImageService _ımageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _eventService.GetAllEventAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateEvent()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            if (createEventDto.ImageFile != null)
            {
                try
                {
                    createEventDto.ImageUrl = await _ımageService.SaveImage(createEventDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(createEventDto);
                }

            }
            await _eventService.CreateEventAsync(createEventDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateEvent(string id)
        {
           
            var value = await _eventService.GetEventAsync(id);
            return View(value);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            if (updateEventDto.ImageFile != null)
            {
                try
                {
                    updateEventDto.ImageUrl = await _ımageService.SaveImage(updateEventDto.ImageFile);
                }
                catch (Exception exc)
                {

                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateEventDto);
                }

            }
            await _eventService.UpdateEventAsync(updateEventDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
