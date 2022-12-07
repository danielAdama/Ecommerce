using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Accounts.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
