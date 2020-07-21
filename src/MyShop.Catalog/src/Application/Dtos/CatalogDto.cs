using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Dtos
{
    public class CatalogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUri { get; set; }

        public CatalogType CatalogType { get; set; }

        public CatalogBrand CatalogBrand { get; set; }

        public int AvailableStock { get; set; }
    }
}
