using MyShop.EventBus.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.IntegrationEvents.Events
{
    public class VerifyCatalogItemIntegrationEvent : IntegrationEvent
    {
        public int UserId { get; }
        public int CatalogStatus { get; }
        public int CatalogId { get; }

        public VerifyCatalogItemIntegrationEvent(int userId, int catalogStatus, int catalogId)
        {
            UserId = userId;
            CatalogStatus = catalogStatus;
            CatalogId = catalogId;
        }
    }
}
