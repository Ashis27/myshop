using MyShop.CommonUtility.SeedWork;
using MyShop.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Interfaces
{
    public interface IUserRepository: IRepository
    {
        Task AddAsync(User user);
        void UpdateAsync(User user);
    }
}
