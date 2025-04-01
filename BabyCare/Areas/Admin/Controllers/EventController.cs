using BabyCare.Dtos.EventDto;
using BabyCare.Services.EventServices;
using BabyCare.Services.IImageServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;

        public EventController(IEventService eventService, IImageService imageService)
        {
            _eventService = eventService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEventAsync();
            return View(events);
        }

        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(createEventDto);
            }

            if (createEventDto.ImageFile != null)
            {
                try
                {
                    createEventDto.ImageUrl = await _imageService.SaveImage(createEventDto.ImageFile);
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
            var eventDto = await _eventService.GetEventAsync(id);
            return View(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(updateEventDto);
            }

            // Eğer yeni bir resim seçilmişse, güncelleme yap
            if (updateEventDto.ImageFile != null)
            {
                try
                {
                    updateEventDto.ImageUrl = await _imageService.SaveImage(updateEventDto.ImageFile);
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError(string.Empty, exc.Message);
                    return View(updateEventDto);
                }
            }

            // Eğer yeni resim yüklenmemişse, eski resmi koru
            else
            {
                var existingEvent = await _eventService.GetEventAsync(updateEventDto.EventId);
                if (existingEvent != null)
                {
                    updateEventDto.ImageUrl = existingEvent.ImageUrl;
                }
            }

            await _eventService.UpdateEventAsync(updateEventDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
