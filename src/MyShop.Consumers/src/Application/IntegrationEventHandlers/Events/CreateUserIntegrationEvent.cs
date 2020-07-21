using MyShop.EventBus.Integration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.IntegrationEventHandlers.Events
{
    public class CreateUserIntegrationEvent:IntegrationEvent
    {
        public Guid UserId { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        private CreateUserIntegrationEvent() { }

        [JsonConstructor]
        public CreateUserIntegrationEvent(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
