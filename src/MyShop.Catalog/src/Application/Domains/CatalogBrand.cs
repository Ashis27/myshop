using MyShop.CommonUtility.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Domains
{
    public class CatalogBrand: BaseEntity
    {
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}
