using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            return View();
        }
    }
}
