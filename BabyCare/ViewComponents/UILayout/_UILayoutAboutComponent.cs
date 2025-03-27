using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutAboutComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
