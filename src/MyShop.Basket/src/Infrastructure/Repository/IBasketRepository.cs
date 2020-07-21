using MyShop.Basket.Application.CommandAndHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Infrastructure.Repository
{
    public interface IBasketRepository
    {
        Task<BasketCommand> GetBasketAsync(string customerId);

        Task<BasketCommand> UpdateBasketAsync(BasketCommand basket);

        IEnumerable<string> GetUsers();

        Task<bool> DeleteBasketAsync(string id);
    }
}
