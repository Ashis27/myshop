using DShop.Common.Types;
using Microsoft.EntityFrameworkCore;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Repositories
{
    public class CatalogQueryRepository : ICatalogQueryRepository
    {
        private readonly CatalogContext _context;

        public CatalogQueryRepository(CatalogContext context)
        {
            _context = context;
        }
        public Task<PaginatedResultBase<CatalogBrand>> GetCatalogBrandsAsync(GetCatalogBrands request)
        {
            throw new NotImplementedException();
        }

        public async Task<CatalogItem> GetCatalogItemAsync(int id)
        {
            return await _context.CatalogItems.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PaginatedResultBase<CatalogItem>> GetCatalogItemsAsync(GetCatalogItems request)
        {
            var totalRecords = await _context.CatalogItems.LongCountAsync();
            var itemsOnPage = _context.CatalogItems.Skip(request.PageSize * request.PageIndex)
                                               .Take(request.PageSize);


            return new PaginatedResultBase<CatalogItem>(request.PageIndex, request.PageSize, totalRecords, itemsOnPage);
        }

        public Task<PaginatedResultBase<CatalogType>> GetCatalogTypesAsync(GetCatalogTypes request)
        {
            throw new NotImplementedException();
        }
    }
}
