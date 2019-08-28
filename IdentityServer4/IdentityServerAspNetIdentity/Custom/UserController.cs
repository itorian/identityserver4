using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServerAspNetIdentity.Custom
{
    public class UserController : Controller
    {
        public string Login()
        {

            return "login page";
        }

        public string Register()
        {

            return "register page";
        }

        [Authorize]
        public string ChangePassword()
        {

            return "change password page";
        }
    }
}