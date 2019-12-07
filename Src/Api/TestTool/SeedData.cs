using Autofac;
using BLL.DTOEntities;
using BLL.Interfaces;
using BLL.Module;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestTool
{

    class SeedData
    {
        public static void Reset()
        {
            using (var container = ConfigurerBLL.ConfigureDependencies())
            {
                var uof = container.Resolve<IUnitOfWork>();
                var userService = container.Resolve<IUserService>();
                var postService = container.Resolve<IPostService>();


                foreach (var achievment in uof.Achievements.GetAll()) uof.Achievements.Remove(achievment);
                foreach (var authorizedUser in uof.AuthorizedUsers.GetAll()) uof.AuthorizedUsers.Remove(authorizedUser);
                foreach (var comment in uof.Comments.GetAll()) uof.Comments.Remove(comment);
                foreach (var post in uof.Posts.GetAll()) uof.Posts.Remove(post);
                foreach (var postTag in uof.PostTags.GetAll()) uof.PostTags.Remove(postTag);
                foreach (var tag in uof.Tags.GetAll()) uof.Tags.Remove(tag);
                foreach (var userAchievment in uof.UserAchievements.GetAll()) uof.UserAchievements.Remove(userAchievment);
                foreach (var user in uof.Users.GetAll()) uof.Users.Remove(user);
                foreach (var vote in uof.Votes.GetAll()) uof.Votes.Remove(vote);
                uof.Save();


                List<CreateUserDTO> usersData = new List<CreateUserDTO>()
                {
                    new CreateUserDTO()
                    {
                        Name = "Vitaliy",
                        Surname = "Petrenko",
                        Password = "qwerty123",
                        Role = "User",
                        Email = "vpetrenko@gmail.com"
                    },
                    new CreateUserDTO()
                    {
                        Name = "Bohdan",
                        Surname = "Polishchuk",
                        Password = "123456",
                        Role = "Admin",
                        Email = "bpolishchuk@gmail.com"
                    },
                    new CreateUserDTO()
                    {
                        Name = "Maks",
                        Surname = "Kurnosenko",
                        Password = "kirigiri7161",
                        Role = "User",
                        Email = "kmaksim@gmail.com"
                    }
                };
                foreach (var user in usersData) userService.CreateUser(user);

                List<CreatePostDTO> postsData = new List<CreatePostDTO>()
                {
                    new CreatePostDTO()
                    {
                        Text = "Test post created by Vitya",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("vpetrenko@gmail.com").Id
                    },
                    new CreatePostDTO()
                    {
                        Text = "Created by Bodya",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("bpolishchuk@gmail.com").Id
                    },
                    new CreatePostDTO()
                    {
                        Text = "First post created by Maks",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("kmaksim@gmail.com").Id
                    },
                    new CreatePostDTO()
                    {
                        Text = "Second post created by Maks",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("kmaksim@gmail.com").Id
                    }
                };
                foreach (var post in postsData) postService.CreatePost(post);

            }
        }
    }
}
