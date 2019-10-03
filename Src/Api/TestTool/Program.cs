using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using System;
using Autofac;
using BLL;
using BLL.Module;
using BLL.Service;
using DAL.DI;
using DAL.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //var uof = new UnitOfWork(new ApplicationContext());
            using (var container = ConfigurerBLL.ConfigureDependencies())
            {
                var uof = container.Resolve<IUnitOfWork>();
                var userService = container.Resolve<IUserService>();

                var user = userService.GetUserById(1);
                Console.WriteLine($"{user.Email}  {user.Password}  {user.GetType()}");

                var x = userService.GetUserByEmailAndPass(user.Email, user.Password);

                Console.WriteLine(x.GetType());

                foreach (var userDto in userService.GetAll())
                {
                    Console.WriteLine($"{userDto.Name}  {userDto.Password}  {userDto.GetType()}");
                }
            }



        }
    }
}
