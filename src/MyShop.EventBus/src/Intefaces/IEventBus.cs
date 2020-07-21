using System;
using System.Collections.Generic;
using System.Text;
using MyShop.EventBus.Integration;

namespace MyShop.EventBus.Intefaces
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
         where T : IntegrationEvent
         where TH : IIntegrationEventHandler<T>;
    }
}
