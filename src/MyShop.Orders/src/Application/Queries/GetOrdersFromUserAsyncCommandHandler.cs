using DShop.Common.Types;
using MediatR;
using MyShop.Orders.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.Queries
{
    public class GetOrdersFromUserAsyncCommandHandler : IRequestHandler<GetOrdersFromUserAsyncCommand, PaginatedResultBase<OrderDto>>
    {
        private readonly IOrderQueries _orderQueries;

        public GetOrdersFromUserAsyncCommandHandler(IOrderQueries orderQueries)
        {
            _orderQueries = orderQueries;
        }
        public async Task<PaginatedResultBase<OrderDto>> Handle(GetOrdersFromUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderQueries.GetOrdersFromUserAsync(request.UserId);

            return result;
        }
    }
}
