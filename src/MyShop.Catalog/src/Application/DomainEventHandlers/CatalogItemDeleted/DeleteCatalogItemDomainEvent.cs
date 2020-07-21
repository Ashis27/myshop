using MediatR;
using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.DomainEventHandlers.CatalogItemDeleted
{
    public class DeleteCatalogItemDomainEvent:INotification
    {
        public int ProductId { get; protected set; }
        public int CatalogStatus { get; private set; }

        public DeleteCatalogItemDomainEvent(int id, int status)
        {
            ProductId = id;
            CatalogStatus = status;
        }
    }
}
