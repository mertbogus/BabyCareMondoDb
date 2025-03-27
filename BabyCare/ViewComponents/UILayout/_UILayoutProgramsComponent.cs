using Microsoft.AspNetCore.Mvc;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutProgramsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
