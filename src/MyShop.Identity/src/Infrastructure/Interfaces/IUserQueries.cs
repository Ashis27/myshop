using Microsoft.AspNetCore.Authentication;
using MyShop.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Interfaces
{
    public interface IUserQueries
    {
        //Task<bool> ValidateCredentials(T user, string password);

        //Task<T> FindByUserName(string user);

        //Task SignIn(T user);

        //Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);

        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);
    }
}
