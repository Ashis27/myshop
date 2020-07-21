using MyShop.EventBus.Integration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.IntegrationEvents.Events
{
    public class CreateUserIntegrationEvent:IntegrationEvent
    {
        public Guid UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Role { get; private set; }

        private CreateUserIntegrationEvent() { }

        [JsonConstructor]
        public CreateUserIntegrationEvent(Guid userId, string firstName, string lastName, string email, string role)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
    }
}
