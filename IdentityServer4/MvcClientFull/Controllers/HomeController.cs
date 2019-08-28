using System.Web;
using System.Web.Mvc;

namespace MvcClientFull.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Secure()
        {
            return View();
        }

        [Authorize(Roles = "Publisher")]
        public string Publisher()
        {
            return "This role is working file";
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}