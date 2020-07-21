using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Dtos
{
    public class CatalogItemDto
    {
        public string Name { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }


        public string PictureFileName { get; set; }


        public string PictureUri { get; set; }


        public int CatalogBrandId { get; set; }


        public int CatalogTypeId { get; set; }


        public int AvailableStock { get; set; }
    }
}
