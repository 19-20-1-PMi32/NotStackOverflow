using DAL.UnitOfWork;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace TestTool
{

    class SeedData
    {
        public static void Reset()
        {
            var uof = new UnitOfWork(new ApplicationContext());


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


            List<User> usersData = new List<User>()
                {
                    new User()
                    {
                        Name = "Vitaliy",
                        Surname = "Petrenko",
                        Password = "qwerty123",
                        Role = "User",
                        Email = "vpetrenko@gmail.com"
                    },
                    new User()
                    {
                        Name = "Bohdan",
                        Surname = "Polishchuk",
                        Password = "123456",
                        Role = "Admin",
                        Email = "bpolishchuk@gmail.com"
                    },
                    new User()
                    {
                        Name = "Maks",
                        Surname = "Kurnosenko",
                        Password = "kirigiri7161",
                        Role = "User",
                        Email = "kmaksim@gmail.com"
                    }
                };
            foreach (var user in usersData) uof.Users.Add(user);
            uof.Save();


            List<Post> postsData = new List<Post>()
                {
                    new Post()
                    {
                        Text = "Test post created by Vitya",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("vpetrenko@gmail.com").Id
                    },
                    new Post()
                    {
                        Text = "Created by Bodya",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("bpolishchuk@gmail.com").Id
                    },
                    new Post()
                    {
                        Text = "First post created by Maks",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("kmaksim@gmail.com").Id
                    },
                    new Post()
                    {
                        Text = "Second post created by Maks",
                        DateOfPublish = DateTime.Now,
                        UserId = uof.Users.GetUserByEmail("kmaksim@gmail.com").Id
                    }
                };
            foreach (var post in postsData) uof.Posts.Add(post);
            uof.Save();


            List<int> postIds = new List<int>();
            foreach (var post in uof.Posts.GetAll()) postIds.Add(post.Id);


            List<Comment> commentData = new List<Comment>()
                {
                    new Comment()
                    {
                        DateOfPublish = DateTime.Now,
                        Text = "Good post",
                        UserId = uof.Users.GetUserByEmail("kmaksim@gmail.com").Id,
                        PostId = postIds[0]
                    },
                    new Comment()
                    {
                        DateOfPublish = DateTime.Now,
                        Text = "Very good post",
                        UserId = uof.Users.GetUserByEmail("bpolishchuk@gmail.com").Id,
                        PostId = postIds[0]
                    },
                    new Comment()
                    {
                        DateOfPublish = DateTime.Now,
                        Text = "Bad post",
                        UserId = uof.Users.GetUserByEmail("bpolishchuk@gmail.com").Id,
                        PostId = postIds[1]
                    }
                };
            foreach (var comment in commentData) uof.Comments.Add(comment);
            uof.Save();


            List<Tag> tagData = new List<Tag>()
            {
                new Tag()
                {
                    Title = "C++",
                    Description = "This post includes C++"
                },
                new Tag()
                {
                    Title = "C#",
                    Description = "This post includes C#"
                },
                new Tag()
                {
                    Title = "Python",
                    Description = "This post includes Python"
                },
                new Tag()
                {
                    Title = "Java",
                    Description = "This post includes Jaba"
                }
            };
            foreach (var tag in tagData) uof.Tags.Add(tag);
            uof.Save();


            List<int> tagIds = new List<int>();
            foreach (var tag in uof.Tags.GetAll()) tagIds.Add(tag.Id);


            List<PostTags> postTagsData = new List<PostTags>()
            {
                new PostTags()
                {
                    PostId = postIds[0],
                    TagId = tagIds[1]
                },
                new PostTags()
                {
                    PostId = postIds[0],
                    TagId = tagIds[0]
                },
                new PostTags()
                {
                    PostId = postIds[1],
                    TagId = tagIds[3]
                }
            };
            foreach (var postTag in postTagsData) uof.PostTags.Add(postTag);
            uof.Save();
        }
    }
}
