using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutEventsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
