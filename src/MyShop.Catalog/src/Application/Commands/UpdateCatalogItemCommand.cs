using MediatR;
using MyShop.Catalog.Application.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Commands
{
    public class UpdateCatalogItemCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public CatalogItemCommand Catalog { get; private set; }

        private UpdateCatalogItemCommand() { }

        [JsonConstructor]
        public UpdateCatalogItemCommand(int id, CatalogItemCommand catalog)
        {
            Id = id;
            Catalog = catalog;
        }
    }
}
