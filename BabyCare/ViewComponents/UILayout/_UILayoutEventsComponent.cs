using BabyCare.Services.EventServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutEventsComponent(IEventService _eventService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _eventService.GetEventUIAsync();
            return View(values);
        }
    }
}
