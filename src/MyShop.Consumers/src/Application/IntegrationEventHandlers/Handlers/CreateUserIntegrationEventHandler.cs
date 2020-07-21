using Microsoft.Extensions.Logging;
using MyShop.Consumer.Application.Domain;
using MyShop.Consumer.Application.IntegrationEventHandlers.Events;
using MyShop.Consumer.Infrastructure.Interfaces;
using MyShop.EventBus.Intefaces;
using MyShop.EventBus.Integration;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.IntegrationEventHandlers.Handlers
{
    public class CreateUserIntegrationEventHandler : IIntegrationEventHandler<CreateUserIntegrationEvent>
    {
        private readonly ILogger<CreateUserIntegrationEventHandler> _logger;
        private readonly IUserRepository _repository;

        public CreateUserIntegrationEventHandler(ILogger<CreateUserIntegrationEventHandler> logger,IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task Handle(CreateUserIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                var user = new Domain.User(@event.UserId, @event.FirstName, @event.LastName);

                await _repository.AddUserAsync(user);
                await _repository.UnitOfWork.SaveEntitiesAsync();
            }
        }
    }
}
