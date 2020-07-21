using MyShop.Consumer.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.Interfaces
{
    public interface IUserQueryRepository
    {
        Task<Application.Domain.User> GetUserAsync(Guid id);

        Task<Address> GetUserAdressAsync(int id);
    }
}
