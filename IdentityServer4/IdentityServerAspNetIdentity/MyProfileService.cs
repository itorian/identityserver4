using System.Linq;
using IdentityModel;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public class MyProfileService : IProfileService
    {
        public MyProfileService()
        { }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            List<string> list = context.RequestedClaimTypes.ToList();
            context.IssuedClaims.AddRange(roleClaims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}