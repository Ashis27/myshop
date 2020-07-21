using AutoMapper;
using DShop.Common.Types;
using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Dtos;
using MyShop.Catalog.Application.Queries;
using MyShop.Catalog.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Handlers
{
    public class GetCatalogItemsCommandHandler : IRequestHandler<GetCatalogItems, PaginatedResultBase<CatalogDto>>
    {
        private readonly ICatalogQueryRepository _queryRepository;
        private readonly ILogger<GetCatalogItemsCommandHandler> _logger;

        public GetCatalogItemsCommandHandler(ICatalogQueryRepository queryRepository, ILogger<GetCatalogItemsCommandHandler> logger)
        {
            _queryRepository = queryRepository;
            _logger = logger;
        }
        public async Task<PaginatedResultBase<CatalogDto>> Handle(GetCatalogItems request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("----Initiated get catalog items with params: {@params}", request);
            
            var results = await _queryRepository.GetCatalogItemsAsync(request);

            var catalogDtos = new PaginatedResultBase<CatalogDto>(results.PageIndex, results.PageSize, results.Count, MapCatalogItems(results.Items));

            return catalogDtos;
        }

        private IEnumerable<CatalogDto> MapCatalogItems(IEnumerable<CatalogItem> result)
        {
            List<CatalogDto> catalogItem = new List<CatalogDto>();
            foreach (CatalogItem item in result)
            {
                var catalog = new CatalogDto
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    PictureUri = item.PictureFileName,
                    AvailableStock = item.AvailableStock
                };
                catalogItem.Add(catalog);
            }

            return catalogItem;
        }
    }
}
