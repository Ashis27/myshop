using MyShop.Catalog.Application.Domains;
using MyShop.CommonUtility.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Repositories
{
    public interface ICatalogCommandRepository : IRepository
    {
        void AddItemAsync(CatalogItem catalogItem);
        void UpdateItemAsync(CatalogItem catalogItem);
    }
}
