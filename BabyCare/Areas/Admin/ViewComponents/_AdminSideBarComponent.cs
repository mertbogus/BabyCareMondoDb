using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.ViewComponents
{
    public class _AdminSideBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
