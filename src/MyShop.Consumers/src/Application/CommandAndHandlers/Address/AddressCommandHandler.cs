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
    public class AddressCommandHandler : IRequestHandler<AddressCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUserQueryRepository _queryRepository;

        public AddressCommandHandler(IUserRepository repository,IUserQueryRepository queryRepository)
        {
            _repository = repository;
            _queryRepository = queryRepository;
        }
        public async Task<bool> Handle(AddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _queryRepository.GetUserAsync(request.UserId);

            if (user == null)
            {
                return false;
            }

            var newAddress = new Address(request.UserId, request.Street, request.City, request.State, request.Country,
                request.ZipCode);

            await _repository.AddUserAddressAsync(newAddress);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
