using MediatR;
using MyShop.Orders.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.DomainEventHandlers.BuyerAndPaymentMethodVerified
{
    public class VerifyOrAddCardTypeDomainEvent:INotification
    {
        public string Type { get; private set; }

        public string Name { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public VerifyOrAddCardTypeDomainEvent(PaymentMethod paymentMethod,string type, string name)
        {
            PaymentMethod = paymentMethod;
            Type = type;
            Name = name;
        }
    }
}
