using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.ViewComponents
{
    public class _AdminHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
