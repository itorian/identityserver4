using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerAspNetIdentity.Quickstart.Account
{
    public class ProfileController : Controller
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