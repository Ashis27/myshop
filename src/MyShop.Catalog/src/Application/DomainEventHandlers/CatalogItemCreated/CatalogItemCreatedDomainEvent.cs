using MediatR;
using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogItemCreated
{
    public class CatalogItemCreatedDomainEvent : INotification
    {
        public int UserID { get; private set; }
        public CatalogItem CatalogItem { get; private set; }

        public CatalogItemCreatedDomainEvent(CatalogItem catalogItem)
        {
            UserID = catalogItem.CreatedBy;
            CatalogItem = catalogItem;
        }
    }
}
