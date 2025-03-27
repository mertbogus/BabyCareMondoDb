using Microsoft.AspNetCore.Mvc;

namespace BabyCare.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
