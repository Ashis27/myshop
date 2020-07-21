using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyShop.Identity.Configuration
{
    public class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("catalog", "catalog Service"),
                new ApiResource("basket", "Basket Service"),
            };
        }

        // Identity resources are data like user ID, name, or email address of a user
        // see: http://docs.identityserver.io/en/release/configuration/resources.html
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                new Client {
                    ClientId = "angular_spa",
                    ClientName = "Angular 4 Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "catalog",
                        "basket"
                    },
                    RedirectUris = { $"{clientsUrl["Spa"]}/auth-callback" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowAccessTokensViaBrowser = true
                },
                new Client {
                    ClientId = "myshop_spa",
                    ClientName = "MyShop App",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { $"{clientsUrl["Spa"]}/auth-callback" },
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    RequirePkce = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "catalog",
                        "basket"
                    },
                },
                new Client {
                    ClientId = "myshop_spa_app",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "MyShop Spa App",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = { $"{clientsUrl["Spa"]}/auth-callback" },
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    //AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowOfflineAccess =true,
                    AccessTokenType = AccessTokenType.Jwt,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly, // Or ReUse
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 360000,
                    SlidingRefreshTokenLifetime = 36000,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "catalog",
                        "basket"
                    }
                }
            };
        }
    }
}
