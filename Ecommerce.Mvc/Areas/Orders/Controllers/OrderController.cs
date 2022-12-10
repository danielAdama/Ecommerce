using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Orders.Controllers
{
    [Area("Orders")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
