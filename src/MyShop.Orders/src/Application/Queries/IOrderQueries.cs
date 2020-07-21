using DShop.Common.Types;
using MyShop.Orders.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.Queries
{
    public interface IOrderQueries
    {
       // Task<OrderDto> GetOrderAsync(int id);

        Task<PaginatedResultBase<OrderDto>> GetOrdersFromUserAsync(Guid userId);

        //Task<IEnumerable<CardTypeDto>> GetCardTypesAsync();
    }
}
