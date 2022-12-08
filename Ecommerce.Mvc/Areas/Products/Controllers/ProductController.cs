using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
