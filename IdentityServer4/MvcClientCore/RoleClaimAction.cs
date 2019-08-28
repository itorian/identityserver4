using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace MvcClientCore
{
    internal class RoleClaimAction : ClaimAction
    {
        public RoleClaimAction()
            : base("role", ClaimValueTypes.String)
        {
        }

        public override void Run(JObject userData, ClaimsIdentity identity, string issuer)
        {
            foreach (var token in userData.SelectTokens("role"))
            {
                IEnumerable<string> roles;

                if (token is JArray)
                {
                    var jarray = token as JArray;
                    roles = jarray.Values<string>();
                }
                else
                {
                    roles = new string[] { token.Value<string>() };
                }

                foreach (var role in roles)
                {
                    Claim claim = new Claim("role", role, ValueType, issuer);
                    if (!identity.HasClaim(c => c.Subject == claim.Subject && c.Value == claim.Value))
                    {
                        identity.AddClaim(claim);
                    }
                }
            }
        }
    }
}