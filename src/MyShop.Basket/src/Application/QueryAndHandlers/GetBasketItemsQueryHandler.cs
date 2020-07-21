using MediatR;
using MyShop.Basket.Application.CommandAndHandlers;
using MyShop.Basket.Application.Models;
using MyShop.Basket.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.QueryAndHandlers
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItems, BasketCommand>
    {
        private readonly IBasketRepository _repository;

        public GetBasketItemsQueryHandler(IBasketRepository repository)
        {
            _repository = repository;
        }
        public async Task<BasketCommand> Handle(GetBasketItems request, CancellationToken cancellationToken)
        {
            return await _repository.GetBasketAsync(request.Id);
        }
    }
}
