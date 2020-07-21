using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.CommandHandlers.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Role { get; private set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public bool IsVerify { get; private set; }

        private CreateUserCommand() { }

        [JsonConstructor]
        public CreateUserCommand(string firstName, string lastName, string email, string password, string role,
            string street,string city, string state, string country, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            IsVerify = false;
        }
    }
}
