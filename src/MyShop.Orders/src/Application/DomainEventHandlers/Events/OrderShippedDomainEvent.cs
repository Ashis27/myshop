using MediatR;
using MyShop.Orders.Application.Domain;

namespace MyShop.Orders.Application.DomainEventHandlers.Events
{
    public class OrderShippedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderShippedDomainEvent(Order order)
        {
            Order = order;           
        }
    }
}
