using MediatR;
using MyShop.Basket.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.CommandAndHandlers
{
    public class BasketCommand : IRequest<BasketCommand>
    {
        public string BuyerId { get;}

        public List<BasketItem> BasketItems { get;}

        private BasketCommand() { }

        [JsonConstructorAttribute]
        public BasketCommand(string customerId, List<BasketItem> basketItems)
        {
            BuyerId = customerId;
            BasketItems = basketItems;
        }
    }
}
