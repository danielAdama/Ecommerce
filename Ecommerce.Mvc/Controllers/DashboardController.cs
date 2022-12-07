using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Identity", new { Area = "Accounts" });
        }
    }
}
