using AutoMapper;
using MediatR;
using MyShop.Catalog.Application.Commands;
using MyShop.Catalog.Application.Domains;
using MyShop.Catalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Handlers
{
    public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, bool>
    {
        private readonly ICatalogCommandRepository _repository;
        private readonly ICatalogQueryRepository _catalogQuery;
        private readonly IMapper _mapper;

        public UpdateCatalogItemCommandHandler(ICatalogCommandRepository repository, ICatalogQueryRepository catalogQuery,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _catalogQuery = catalogQuery ?? throw new ArgumentNullException(nameof(catalogQuery));
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogQuery.GetCatalogItemAsync(request.Id);

            if (request.Catalog.Price != catalogItem.Price)
            {
                catalogItem.SetNewPrice(request.Catalog.Price);
            }

            catalogItem = _mapper.Map<CatalogItemCommand, CatalogItem>(request.Catalog);
            _repository.UpdateItemAsync(catalogItem);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
