using Owin;
using System.Net;
using System.Linq;
using Microsoft.Owin;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

[assembly: OwinStartup(typeof(MvcClientFull.Startup))]
namespace MvcClientFull
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc-full",
                ClientSecret = "mvc-full-secret",
                Authority = "http://localhost:5000",
                SignInAsAuthenticationType = "Cookies",
                RequireHttpsMetadata = false,

                ResponseType = "code id_token token",
                Scope = "openid profile offline_access roles",

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    SecurityTokenValidated = async n =>
                    {
                        var userData = await CallUserInfoEndpoint(n.ProtocolMessage.AccessToken, n.Options.Authority);
                        var identity = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType, ClaimTypes.GivenName, ClaimTypes.Role);

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
                                Claim claim = new Claim(ClaimTypes.Role, role.ToString());
                                if (!identity.HasClaim(c => c.Subject == claim.Subject && c.Value == claim.Value))
                                {
                                    identity.AddClaim(claim);
                                }
                            }
                        }

                        identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        identity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                        n.AuthenticationTicket = new AuthenticationTicket(identity, n.AuthenticationTicket.Properties);
                    },

                    RedirectToIdentityProvider = n =>
                    {
                        n.ProtocolMessage.RedirectUri = n.Request.Scheme + "://" + n.Request.Host;
                        n.ProtocolMessage.PostLogoutRedirectUri = n.Request.Scheme + "://" + n.Request.Host;

                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
                        {
                            n.ProtocolMessage.AcrValues = "tenant:clientId1"; // get this from session

                            var tenant = System.Web.HttpContext.Current.Items["Tenant"];
                            var request = System.Web.HttpContext.Current.Request;
                        }

                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
                        {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }

                        return Task.FromResult(0);
                    }
                }
            });
        }

        public async static Task<JObject> CallUserInfoEndpoint(string accessToken, string authority)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(authority + "/connect/userinfo");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json);
            }
            else
            {
                return null;
            }
        }
    }
}