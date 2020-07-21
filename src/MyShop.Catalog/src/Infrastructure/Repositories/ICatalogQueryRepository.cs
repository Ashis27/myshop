using DShop.Common.Types;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Repositories
{
    public interface ICatalogQueryRepository
    {
        Task<CatalogItem> GetCatalogItemAsync(int id);

        Task<PaginatedResultBase<CatalogItem>> GetCatalogItemsAsync(GetCatalogItems request);

        Task<PaginatedResultBase<CatalogBrand>> GetCatalogBrandsAsync(GetCatalogBrands request);

        Task<PaginatedResultBase<CatalogType>> GetCatalogTypesAsync(GetCatalogTypes request);
    }
}
