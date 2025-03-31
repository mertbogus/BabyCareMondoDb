using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
