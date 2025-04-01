using BabyCare.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutTeamComponent(IInstructorService _instructorService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await  _instructorService.GetAllUIInstructorAsync();
            return View(values);
        }
    }
}
