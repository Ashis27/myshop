using MyShop.Catalog.Application.Domains;
using MyShop.CommonUtility.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Repositories
{
    public class CatalogCommandRepository : ICatalogCommandRepository
    {
        private readonly CatalogContext _catalogContext;

        public CatalogCommandRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public IUnitOfWork UnitOfWork => _catalogContext;

        public void AddItemAsync(CatalogItem catalogItem)
        {
            _catalogContext.CatalogItems.AddAsync(catalogItem);
        }

        public void UpdateItemAsync(CatalogItem catalogItem)
        {
            _catalogContext.CatalogItems.Update(catalogItem);
        }
    }
}
