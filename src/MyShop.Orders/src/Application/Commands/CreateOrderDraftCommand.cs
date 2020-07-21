using MediatR;
using MyShop.Orders.Application.Models;
using System.Collections.Generic;

namespace MyShop.Orders.Application.Commands
{
    public class CreateOrderDraftCommand :  IRequest<OrderDraftDTO>
    {
       
        public string BuyerId { get;}

        public IEnumerable<BasketItem> Items { get;}

        public CreateOrderDraftCommand(string buyerId, IEnumerable<BasketItem> items)
        {
            BuyerId = buyerId;
            Items = items;
        }
    }

}
