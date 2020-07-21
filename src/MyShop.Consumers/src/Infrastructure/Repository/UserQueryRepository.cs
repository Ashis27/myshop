using Microsoft.EntityFrameworkCore;
using MyShop.Consumer.Application.Domain;
using MyShop.Consumer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.Repository
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly UserContext _context;

        public UserQueryRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<Address> GetUserAdressAsync(int id)
        {
            return await _context.Address.FindAsync(id);
        }

        public async Task<Application.Domain.User> GetUserAsync(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.UId == id);

            if(user != null)
            {
               await _context.Entry(user)
                      .Collection(i => i.Address).LoadAsync();
            }

            return user;
        }
    }
}
