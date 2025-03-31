using BabyCare.Services.IHeroServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutHeroComponent(IHeroService _heroService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _heroService.GetAllHeroAsync();
            return View(values);
        }
    }
}
