using DShop.Common.Types;
using MediatR;
using MyShop.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Queries
{
    public class GetCatalogItems: PagedQueryBase,IRequest<PaginatedResultBase<CatalogDto>>
    {
        public string Name { get; protected set; }
        public GetCatalogItems(int pageIndex, int pageSize, string orderBy, string sortOrder, string name)
            : base(pageIndex, pageSize, orderBy, sortOrder)
        {
            Name = name;
        }
    }
}
