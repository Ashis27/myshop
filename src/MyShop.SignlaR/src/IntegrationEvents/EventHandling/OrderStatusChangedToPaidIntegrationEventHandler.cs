﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MyShop.EventBus.Intefaces;
using MyShop.SignalR;
using MyShop.SignalR.IntegrationEvents.Events;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace MyShop.SignalR.IntegrationEvents.EventHandling
{
    public class OrderStatusChangedToPaidIntegrationEventHandler : IIntegrationEventHandler<OrderStatusChangedToPaidIntegrationEvent>
    {
        private readonly IHubContext<NotificationsHub> _hubContext;
        private readonly ILogger<OrderStatusChangedToPaidIntegrationEventHandler> _logger;

        public OrderStatusChangedToPaidIntegrationEventHandler(
            IHubContext<NotificationsHub> hubContext,
            ILogger<OrderStatusChangedToPaidIntegrationEventHandler> logger)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task Handle(OrderStatusChangedToPaidIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                await _hubContext.Clients
                    .Group(@event.BuyerName)
                    .SendAsync("UpdatedOrderState", new { OrderId = @event.OrderId, Status = @event.OrderStatus });
            }
        }
    }
}
