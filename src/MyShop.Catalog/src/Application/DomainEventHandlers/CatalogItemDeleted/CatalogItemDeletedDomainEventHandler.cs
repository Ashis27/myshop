using MediatR;
using MyShop.Catalog.Application.IntegrationEvents;
using MyShop.Catalog.Application.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogItemDeleted
{
    public class CatalogItemDeletedDomainEventHandler : INotificationHandler<DeleteCatalogItemDomainEvent>
    {
        private readonly ICatalogIntegrationEventService _eventService;

        public CatalogItemDeletedDomainEventHandler(ICatalogIntegrationEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(DeleteCatalogItemDomainEvent notification, CancellationToken cancellationToken)
        {
            var deleteCatalogItemIntegrationEvent = new DeleteCatalogItemIntegrationEvent(notification.ProductId,notification.CatalogStatus);
            await _eventService.AddAndSaveEventAsync(deleteCatalogItemIntegrationEvent);
        }
    }
}
