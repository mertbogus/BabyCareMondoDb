using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.ViewComponents
{
    public class _AdminNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
