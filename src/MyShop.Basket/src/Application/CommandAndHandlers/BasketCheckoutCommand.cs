using MediatR;
using MyShop.Basket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.CommandAndHandlers
{
    public class BasketCheckoutCommand : IRequest<bool>
    {
        public string BuyerId { get; }

        public string UserName { get;}

        public Guid RequestId { get;}

        public Address Address { get; }

        public PaymentMethod PaymentMethod { get; }

        public BasketCheckoutCommand(string id, Address address, PaymentMethod paymentMethod, string userName,Guid reqId)
        {
            BuyerId = id;
            Address = address;
            PaymentMethod = paymentMethod;
            UserName = userName;
            RequestId = reqId;
        }
    }
}
