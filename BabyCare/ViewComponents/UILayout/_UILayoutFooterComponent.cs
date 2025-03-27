using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
