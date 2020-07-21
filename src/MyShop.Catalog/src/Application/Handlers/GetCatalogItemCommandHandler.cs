using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Application.Dtos;
using MyShop.Catalog.Application.Queries;
using MyShop.Catalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Handlers
{
    public class GetCatalogItemCommandHandler : IRequestHandler<GetCatalogItem, CatalogDto>
    {
        private readonly ILogger<GetCatalogItemCommandHandler> _logger;
        private readonly ICatalogQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public GetCatalogItemCommandHandler(ILogger<GetCatalogItemCommandHandler> logger, 
            ICatalogQueryRepository queryRepository,IMapper mapper)
        {
            _logger = logger;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }
        public async Task<CatalogDto> Handle(GetCatalogItem request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CatalogItem, CatalogDto>(await _queryRepository.GetCatalogItemAsync(request.Id));

            return result;
        }
    }
}
