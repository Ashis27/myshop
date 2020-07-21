using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Orders.Application.Domain;
using MyShop.Orders.Application.DomainEventHandlers.Events;
using MyShop.Orders.Application.IntegrationEvents;
using MyShop.Orders.Infrastructure.Repositories;
using MyShop.Orders.IntegrationEvents.Events;
using Ordering.API.Application.IntegrationEvents;
using Ordering.API.Application.IntegrationEvents.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.DomainEventHandlers.OrderShipped
{
    public class OrderShippedDomainEventHandler
                   : INotificationHandler<OrderShippedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBuyerRepository _buyerRepository;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        private readonly ILoggerFactory _logger;

        public OrderShippedDomainEventHandler(
            IOrderRepository orderRepository, 
            ILoggerFactory logger,
            IBuyerRepository buyerRepository,
            IOrderingIntegrationEventService orderingIntegrationEventService)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _orderingIntegrationEventService = orderingIntegrationEventService;
        }

        public async Task Handle(OrderShippedDomainEvent orderShippedDomainEvent, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<OrderShippedDomainEvent>()
                .LogTrace("Order with Id: {OrderId} has been successfully updated to status {Status} ({Id})",
                    orderShippedDomainEvent.Order.Id, nameof(OrderStatus.Shipped), OrderStatus.Shipped.Id);

            var order = await _orderRepository.GetAsync(orderShippedDomainEvent.Order.Id);
            var buyer = await _buyerRepository.FindByIdAsync(order.GetBuyerId.Value.ToString());

            var orderStatusChangedToShippedIntegrationEvent = new OrderStatusChangedToShippedIntegrationEvent(order.Id, order.OrderStatus.Name, buyer.Name);
            await _orderingIntegrationEventService.AddAndSaveEventAsync(orderStatusChangedToShippedIntegrationEvent);
        }
    }
}
