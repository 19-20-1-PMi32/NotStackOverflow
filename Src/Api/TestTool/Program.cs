using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using System;
using DAL.UnitOfWork;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var uof = new UnitOfWork(new ApplicationContext());
            foreach (var i in uof.Tags.GetAll())
            {
                Console.WriteLine(i.Description);
            }
        }
    }
}
