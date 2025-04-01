using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ContactDto;
using BabyCare.Dtos.EventDto;
using BabyCare.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(IContactService _contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values= await _contactService.GetAllContactAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateContact()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(createContactDto);
            }
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactService.GetContactAsync(id);
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(updateContactDto);
            }
            await _contactService.UpdateContactAsync(updateContactDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
