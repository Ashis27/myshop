using MediatR;
using MyShop.Basket.Application.Models;
using MyShop.Basket.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.CommandAndHandlers
{
    public class BasketCommandHandler : IRequestHandler<BasketCommand, BasketCommand>
    {
        private readonly IBasketRepository _repository;

        public BasketCommandHandler(IBasketRepository repository)
        {
            _repository = repository;
        }
        public async Task<BasketCommand> Handle(BasketCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateBasketAsync(request);
        }
    }
}
