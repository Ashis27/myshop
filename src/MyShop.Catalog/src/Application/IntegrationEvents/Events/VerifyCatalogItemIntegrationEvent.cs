using MyShop.EventBus.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.IntegrationEvents.Events
{
    public class VerifyCatalogItemIntegrationEvent : IntegrationEvent
    {
        public int UserId { get; protected set; }

        public int CatalogStatus { get; protected set; }

        public int CatalogId { get; protected set; }

        public VerifyCatalogItemIntegrationEvent(int userId, int catalogStatus, int catalogId)
        {
            UserId = userId;
            CatalogStatus = catalogStatus;
            CatalogId = catalogId;
        }
    }
}
