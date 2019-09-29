using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using System;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationContext();

            var postRep = new PostRepository(context);
            var tagRep = new TagRepository(context);

            var tag = new Tag()
            {
                Description = "description2",
                Title = "Title2"
            };

            tagRep.Add(tag);

            Console.WriteLine(tag.Id);

            //context.SaveChanges();

            //var a =  tagRep.GetById(1);
           
           // postRep.Add(post);
            context.SaveChanges();

            Console.WriteLine(tag.Id);

        }
    }
}
