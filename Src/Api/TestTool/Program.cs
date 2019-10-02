using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using System;
using Autofac;
using DAL.DI;
using DAL.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using static BLL.DI.DI;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
           // var uof = new UnitOfWork(new ApplicationContext());
           using (var container = ConfigurerBLL.ConfigureDependencies())
           {
               var ouf = container.Resolve<IUnitOfWork>();
               foreach (var i in ouf.Tags.GetAll())
               {
                   Console.WriteLine(i.Description);
               }
            }
        }
    }
}
