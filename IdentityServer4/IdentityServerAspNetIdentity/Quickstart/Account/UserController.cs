using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServerAspNetIdentity.Quickstart.Account
{
    public class UserController : Controller
    {
        public string Index()
        {
            return "index page";
        }

        [Authorize]
        public async Task<string> ChangePassword()
        {

            return "ok";
        }
    }
}