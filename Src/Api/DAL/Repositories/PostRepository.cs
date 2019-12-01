using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private const int pageSize = 10;
        public PostRepository(ApplicationContext applicationContext): base(applicationContext)
        { }

        public new Post GetById(int id)
        {
            return dbContext.Posts
                .Include(p => p.Comments)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostsWithComments(int postId, int page = 1)
        {
            return dbContext.Posts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Where(p => p.PostId == postId)
                .Include(p => p.Comments)
                .Include(p => p.User)
                .ToList();
        }

        public IEnumerable<Post> GetPostList(int page = 1)
        {
            return dbContext.Posts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.User)
                .ToList();
        }

        public IEnumerable<Post> GetUsersPostsById(int userId)
        {
            return dbContext.Posts
                .Where(p => p.UserId == userId)
                .ToList();
        }
    }
}
