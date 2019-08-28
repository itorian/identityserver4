// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Security.Claims;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "Allow the service access to your user roles.",
                    UserClaims = new[] { JwtClaimTypes.Role, ClaimTypes.Role },
                    ShowInDiscoveryDocument = true,
                    Required = true,
                    Emphasize = true
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvc-core",
                    ClientName = "MVC Core Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,

                    RequireConsent = false,

                    ClientSecrets = { new Secret("mvc-core-secret".Sha256()) },

                    RedirectUris = GetRedirectUris(),
                    PostLogoutRedirectUris = GetPostLogoutRedirectUris(),

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles"
                    },

                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "mvc-full",
                    ClientName = "MVC Full Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,

                    RequireConsent = false,
                    
                    ClientSecrets = { new Secret("mvc-full-secret".Sha256()) },

                    RedirectUris = GetRedirectUris(),
                    PostLogoutRedirectUris = GetPostLogoutRedirectUris(),

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles"
                    },

                    AllowOfflineAccess = true
                }
            };
        }

        private static ICollection<string> GetRedirectUris()
        {
            var uris = new List<string>();

            // asp.net core app
            uris.Add("http://localhost:5002/signin-oidc");

            // asp.net full framework apps
            uris.Add("http://localhost:5003");





            return uris;
        }

        private static ICollection<string> GetPostLogoutRedirectUris()
        {
            var uris = new List<string>();

            // asp.net core app
            uris.Add("http://localhost:5002/signout-callback-oidc");

            // asp.net full framework apps
            uris.Add("http://localhost:5003");





            return uris;
        }

    }
}