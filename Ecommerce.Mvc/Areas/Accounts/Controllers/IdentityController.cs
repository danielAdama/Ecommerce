using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }

}
