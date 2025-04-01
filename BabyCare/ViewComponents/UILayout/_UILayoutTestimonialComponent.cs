using BabyCare.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutTestimonialComponent(ITestimonialService _testimonialService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values= await _testimonialService.GetAllUIAsync();
            return View(values);
        }
    }
}
