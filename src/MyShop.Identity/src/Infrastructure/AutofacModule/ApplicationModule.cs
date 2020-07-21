using Autofac;
using MyShop.CommonUtility.EvenLogContext.Services;
using MyShop.EventBus.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.AutofacModule
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CatalogQueryRepository>()
            //       .As<ICatalogQueryRepository>()
            //       .InstancePerLifetimeScope();

            //builder.RegisterType<CatalogCommandRepository>()
            //       .As<ICatalogCommandRepository>()
            //       .InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(typeof(SignUpCommandHandler).GetTypeInfo().Assembly)
            //       .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
