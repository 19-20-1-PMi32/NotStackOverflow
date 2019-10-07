using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BLL.Interfaces;
using BLL.Service;
using DAL.DI;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Module
{
    public class ConfigurerBLL
    {
        public static IContainer ConfigureDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<BLLModule>();

            return builder.Build();
        }
    }

    public sealed class BLLModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            builder.Populate(services);
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterModule<DALModule>();
            base.Load(builder);
        }
    }
}

