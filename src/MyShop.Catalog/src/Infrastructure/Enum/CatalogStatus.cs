using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Enum
{
    public enum CatalogStatus
    {
        Created = 1,
        Approved = 2,
        Declained = 3,
        Deleted = 4,
        PriceChanged = 5
    }
}
