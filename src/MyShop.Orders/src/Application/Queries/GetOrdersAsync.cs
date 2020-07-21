using DShop.Common.Types;
using MediatR;
using MyShop.Orders.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.Queries
{
    public class GetOrdersFromUserAsyncCommand : IRequest<PaginatedResultBase<OrderDto>>
    {
        public Guid UserId { get; }

        public GetOrdersFromUserAsyncCommand(Guid id)
        {
            UserId = id; 
        }
    }
}
