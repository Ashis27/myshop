using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Commands.Address
{
    public class AddressCommand : IRequest<bool>
    {
        public Guid UserId { get; }

        public string Street { get; }

        public string City { get; }

        public string State { get; }

        public string Country { get; }

        public string ZipCode { get; }

        protected AddressCommand() { }

        [JsonConstructor]
        public AddressCommand(string street, string city, string state,
            string country, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
