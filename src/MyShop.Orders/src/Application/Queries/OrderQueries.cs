using DShop.Common.Types;
using MyShop.Orders.Application.DTO;
using MyShop.Orders.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly OrderingContext _context;

        public OrderQueries(OrderingContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResultBase<OrderDto>> GetOrdersFromUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
