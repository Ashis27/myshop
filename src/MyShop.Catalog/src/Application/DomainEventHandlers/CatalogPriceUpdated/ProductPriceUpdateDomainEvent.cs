using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogPriceUpdated
{
    public class ProductPriceUpdateDomainEvent:INotification
    {
        public int ProductId { get; private set; }

        public decimal NewPrice { get; private set; }

        public decimal OldPrice { get; private set; }

        public int CatalogStatus { get; private set; }

        public ProductPriceUpdateDomainEvent(int id, decimal newPrice, decimal oldPrice, int status)
        {
            ProductId = id;
            NewPrice = newPrice;
            OldPrice = oldPrice;
            CatalogStatus = status;
        }
    }
}
