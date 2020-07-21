using MyShop.Consumer.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicURL { get; set; }

        public IReadOnlyCollection<AddressDto> Address { get; set; }
    }
}
