using MyShop.Identity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Interfaces
{
    public interface IJwtAuthServices
    {
        Task<Token> GenerateEncodedJWTAsync(string id, string userName, string role);
        Task<ClaimsPrincipal> ValidateTokenAsync(string accessToken);
    }
}
