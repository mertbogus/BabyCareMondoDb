using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutNavbarComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
