using MediatR;
using MyShop.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Queries
{
    public class GetCatalogItem: IRequest<CatalogDto>
    {
        public int Id { get; protected set; }

        public GetCatalogItem(int id)
        {
            Id = id;  
        }
    }
}
