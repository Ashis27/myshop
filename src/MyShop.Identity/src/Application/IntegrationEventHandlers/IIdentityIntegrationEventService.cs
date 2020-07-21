using MyShop.EventBus.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.IntegrationEventHandlers
{
    public interface IIdentityIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);

        Task AddAndSaveEventAsync(IntegrationEvent evt);

        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
