using MyShop.EventBus.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.IntegrationEvents.Events
{
    public class ProductPriceChangeIntegrationEvent:IntegrationEvent
    {
        public int ProductId { get; protected set; }

        public decimal NewPrice { get; protected set; }

        public decimal OldPrice { get; protected set; }

        public int CatalogStatus { get; protected set; }

        public ProductPriceChangeIntegrationEvent(int productId, decimal newPrice, decimal oldPrice, int status)
        {
            ProductId = productId;
            NewPrice = newPrice;
            OldPrice = oldPrice;
            CatalogStatus = status;
        }
    }
}
