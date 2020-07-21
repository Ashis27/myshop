using MediatR;
using MyShop.Orders.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Orders.Application.DomainEventHandlers.Events
{
    public class OrderCancelledDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderCancelledDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
