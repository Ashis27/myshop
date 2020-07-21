using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Identity.Application.IntegrationEventHandlers;
using MyShop.Identity.Application.IntegrationEventHandlers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.DomainEventHandlers.UserCreated
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IIdentityIntegrationEventService _identityIntegrationEventService;
        private readonly ILogger<UserCreatedDomainEventHandler> _logger;

        public UserCreatedDomainEventHandler(IIdentityIntegrationEventService identityIntegrationEventService,
            ILogger<UserCreatedDomainEventHandler> logger)
        {
            _identityIntegrationEventService = identityIntegrationEventService;
            _logger = logger;
        }

        public async Task Handle(UserCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Initiatted Created user event with id {id} and email {email}", @event.UserId, @event.User.Email);

            var createUserIntegrationEvent = new CreateUserIntegrationEvent(@event.UserId, @event.User.FirstName,
                    @event.User.LastName);

            await _identityIntegrationEventService.AddAndSaveEventAsync(createUserIntegrationEvent);
        }
    }
}
