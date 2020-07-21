using MediatR;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Commands
{

    //Immutable
    public class CatalogItemCommand : IRequest<bool>
    {
        [DataMember]
        public string Name { get; }

        [DataMember]
        public string Description { get; }

        [DataMember]
        public decimal Price { get; }

        [DataMember]
        public string PictureFileName { get; }

        [DataMember]
        public string PictureUri { get; }

        [DataMember]
        public int CatalogBrandId { get; }

        [DataMember]
        public int CatalogTypeId { get; }

        [DataMember]
        public int AvailableStock { get; }

        private CatalogItemCommand() { }

        [JsonConstructor]
        public CatalogItemCommand(string name, string description, decimal price, string pictureFileName, int catalogBrandId,
            int catalogTypeId, int availableStock)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureFileName = pictureFileName;
            CatalogBrandId = catalogBrandId;
            CatalogTypeId = catalogTypeId;
            AvailableStock = availableStock;
        }
    }
}
