using MediatR;
using MyShop.Basket.Application.CommandAndHandlers;
using MyShop.Basket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.QueryAndHandlers
{
    public class GetBasketItems : IRequest<BasketCommand>
    {
        public string Id { get; }

        public GetBasketItems(string id)
        {
            Id = id;
        }
    }
}
