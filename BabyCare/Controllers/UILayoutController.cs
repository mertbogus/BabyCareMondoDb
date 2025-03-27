using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
