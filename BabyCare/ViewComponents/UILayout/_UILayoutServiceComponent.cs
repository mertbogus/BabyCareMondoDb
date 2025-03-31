using BabyCare.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutServiceComponent(IServiceServices _serviceServices) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _serviceServices.GetAllServiceAsync();
            return View(services);
        }
    }
}
