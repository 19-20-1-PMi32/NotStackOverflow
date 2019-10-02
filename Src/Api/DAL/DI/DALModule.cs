using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DAL.Context;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DI
{
    public class ConfigurerDAL
    {
        public static IContainer ConfigureDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<DALModule>();

            return builder.Build();
        }
    }

    public sealed class DALModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            builder.Populate(services);
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationContext>().InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
