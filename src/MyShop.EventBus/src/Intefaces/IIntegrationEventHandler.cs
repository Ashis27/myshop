﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyShop.EventBus.Integration;

namespace MyShop.EventBus.Intefaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
