using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
