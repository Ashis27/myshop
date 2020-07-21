using MyShop.EventBus.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.IntegrationEvents.Events
{
    public class DeleteCatalogItemIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; protected set; }

        public int CatalogStatus { get; protected set; }

        public DeleteCatalogItemIntegrationEvent(int id, int status)
        {
            ProductId = id;
            CatalogStatus = status;
        }
    }
}
