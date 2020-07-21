using MyShop.EventBus.Integration;
using MyShop.Orders.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.IntegrationEvents
{
    public interface IOrderingIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
