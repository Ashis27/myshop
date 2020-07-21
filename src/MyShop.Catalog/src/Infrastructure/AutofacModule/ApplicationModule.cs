using Autofac;
using MyShop.Catalog.Application.Commands;
using MyShop.Catalog.Application.Handlers;
using MyShop.Catalog.Application.IntegrationEvents;
using MyShop.Catalog.Infrastructure.Repositories;
using MyShop.CommonUtility.EvenLogContext.Services;
using MyShop.EventBus.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.AutofacModule
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogQueryRepository>()
                   .As<ICatalogQueryRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<CatalogCommandRepository>()
                   .As<ICatalogCommandRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateCatalogItemCommandHandler).GetTypeInfo().Assembly)
                   .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
