using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MyShop.Identity.Application.Domain;
using MyShop.Identity.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Interfaces
{
    public interface ILoginService<T>
    {
        Task<bool> ValidateCredentials(T user, string password);

        Task<T> FindByUserName(string user);

        Task<IdentityResult> SignUpAsync(RegisterViewModel model);

        Task SignIn(T user);

        Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
