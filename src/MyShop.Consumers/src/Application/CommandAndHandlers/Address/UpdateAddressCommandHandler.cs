using AutoMapper;
using MediatR;
using MyShop.Consumer.Application.Commands.Address;
using MyShop.Consumer.Application.Domain;
using MyShop.Consumer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Handlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUserQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IUserRepository repository, IUserQueryRepository queryRepository, IMapper mapper)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _queryRepository.GetUserAdressAsync(request.Id);

            if (address == null)
            {
                return false;
            }

            address = _mapper.Map<AddressCommand, Address>(request.Address);
            _repository.UpdateUserAddressAsync(address);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
