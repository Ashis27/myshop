using Microsoft.EntityFrameworkCore;
using MyShop.CommonUtility.SeedWork;
using MyShop.Identity.Domain;
using MyShop.Identity.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }
        public IUnitOfWork UnitOfWork {
            get
            {
                return _userContext;
            }
        }

        public async Task AddAsync(User user)
        {
           await _userContext.Users.AddAsync(user);
        }

        public void UpdateAsync(User user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
        }
    }
}
