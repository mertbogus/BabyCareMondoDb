using BabyCare.Dtos.AboutDto;
using BabyCare.Dtos.ServiceDto;
using BabyCare.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IServiceServices _serviceServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _serviceServices.GetAllServiceAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            await _serviceServices.DeleteServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceServices.CreateServiceAsync(createServiceDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateService(string id)
        {
            var value = await _serviceServices.GetServiceAsync(id);
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceServices.UpdateServiceAsync(updateServiceDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
