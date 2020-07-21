using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Commands.Address
{
    public class UpdateAddressCommand : IRequest<bool>
    {
        public int Id { get; }

        public AddressCommand Address { get; }

        public UpdateAddressCommand(int id, AddressCommand address)
        {
            Id = id;
            Address = address;
        }
    }
}
