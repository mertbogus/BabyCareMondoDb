using BabyCare.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutFooterComponent(IContactService _contactService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactService.GetFirstContactAsync();
            return View(values);
        }
    }
}
