using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Identity.Application.Domain;
using MyShop.Identity.Domain;
using MyShop.Identity.Infrastructure;
using MyShop.Identity.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly UserContext _userContext;

        public UserQueries(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userContext.Users.Where(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
