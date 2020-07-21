using Autofac;
using MediatR;
using MyShop.EventBus.Intefaces;
using Payment.API.IntegrationEvents.EventHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyShop.Payment.AutofacModule
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(OrderStatusChangedToStockConfirmedIntegrationEventHandler).GetTypeInfo().Assembly)
                   .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
