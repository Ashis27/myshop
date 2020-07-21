using MyShop.CommonUtility.SeedWork;
using MyShop.Consumer.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task AddUserAsync(Application.Domain.User user);

        Task UpdateUserAsync(Application.Domain.User user);

        Task DeleteUser(Guid id);

        Task AddUserAddressAsync(Address address);

        void UpdateUserAddressAsync(Address address);
    }
}
