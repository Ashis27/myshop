using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.IntegrationEvents;
using MyShop.Catalog.Application.IntegrationEvents.Events;
using MyShop.Catalog.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogItemCreated
{
    public class CatalogItemCreatedDomainEventHandler : INotificationHandler<CatalogItemCreatedDomainEvent>
    {
        private readonly ILogger<CatalogItemCreatedDomainEventHandler> _logger;
        private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

        public CatalogItemCreatedDomainEventHandler(
            ILogger<CatalogItemCreatedDomainEventHandler> logger,
            ICatalogIntegrationEventService catalogIntegrationEventService)
        {
            _logger = logger;
            _catalogIntegrationEventService = catalogIntegrationEventService;
        }
        public async Task Handle(CatalogItemCreatedDomainEvent message, CancellationToken cancellationToken)
        {
            var verifyCatalogItemEvent = new VerifyCatalogItemIntegrationEvent(message.UserID, (int)CatalogStatus.Created, message.CatalogItem.Id);
            await _catalogIntegrationEventService.AddAndSaveEventAsync(verifyCatalogItemEvent);
        }
    }
}
