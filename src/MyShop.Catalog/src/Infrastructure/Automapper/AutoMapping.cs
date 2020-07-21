using AutoMapper;
using MyShop.Catalog.Application.Commands;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Automapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<CatalogItem, CatalogDto>();
            CreateMap<CatalogItemCommand, CatalogItem>();
        }
    }
}
