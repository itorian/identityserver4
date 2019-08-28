using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcClientCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        [Authorize(Roles = "Publisher")]
        public string Publisher()
        {
            return "This role is working file";
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}