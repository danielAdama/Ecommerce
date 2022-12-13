using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display1()
        {
            return View();
        }

		public IActionResult Display2()
		{
			return View();
		}

		public IActionResult Display3()
		{
			return View();
		}
	}
}
