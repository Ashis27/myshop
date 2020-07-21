using MyShop.CommonUtility.SeedWork;
using MyShop.Consumer.Application.Domain;
using MyShop.Consumer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task AddUserAsync(Application.Domain.User user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(Application.Domain.User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task AddUserAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
        }

        public void UpdateUserAddressAsync(Address address)
        {
            _context.Address.Update(address);
        }
    }
}
