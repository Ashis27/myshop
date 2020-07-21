using MyShop.CommonUtility.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Domain
{
    public class Address : BaseEntity
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        private Address() { }

        [JsonConstructor]
        public Address(Guid userId, string street, string city, string state,
            string country, string zipCode)
        {
            UId = userId;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
