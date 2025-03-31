using BabyCare.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCare.ViewComponents.UILayout
{
    public class _UILayoutProgramsComponent(IProductService _productService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllUI();
            return View(products);
        }
    }
}
