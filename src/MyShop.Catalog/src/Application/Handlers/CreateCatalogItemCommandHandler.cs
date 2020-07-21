using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.Commands;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Infrastructure.Enum;
using MyShop.Catalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Handlers
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CatalogItemCommand, bool>
    {
        private readonly ICatalogCommandRepository _catalogCommandRepository;
        private readonly ILogger<CreateCatalogItemCommandHandler> _logger;

        public CreateCatalogItemCommandHandler(ICatalogCommandRepository catalogCommandRepository, ILogger<CreateCatalogItemCommandHandler> logger)
        {
            _catalogCommandRepository = catalogCommandRepository ?? throw new ArgumentNullException(nameof(catalogCommandRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> Handle(CatalogItemCommand request, CancellationToken cancellationToken)
        {
            CatalogItem _catalogItem = new CatalogItem(request.Name, request.Description, request.Price, request.PictureFileName,
                                                        request.PictureUri, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId);

            _catalogCommandRepository.AddItemAsync(_catalogItem);
            await _catalogCommandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
