using MediatR;
using MyShop.Catalog.Application.IntegrationEvents;
using MyShop.Catalog.Application.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogPriceUpdated
{
    public class ProductPriceUpdatedDomainEventHandler : INotificationHandler<ProductPriceUpdateDomainEvent>
    {
        private readonly ICatalogIntegrationEventService _eventService;

        public ProductPriceUpdatedDomainEventHandler(ICatalogIntegrationEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task Handle(ProductPriceUpdateDomainEvent notification, CancellationToken cancellationToken)
        {
            var productPriceChangeIntegrationEvent = new ProductPriceChangeIntegrationEvent(notification.ProductId, notification.NewPrice, notification.OldPrice,notification.CatalogStatus);
            await _eventService.AddAndSaveEventAsync(productPriceChangeIntegrationEvent);
        }
    }
}
