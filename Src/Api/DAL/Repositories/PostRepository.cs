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
        public PostRepository(ApplicationContext applicationContext): base(applicationContext)
        { }

        public new Post GetById(int id)
        {
            return dbContext.Posts
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostsWithComments(int postId)
        {
            return dbContext.Posts
                .Where(p => p.PostId == postId)
                .Include(p => p.Comments)
                .ToList();
        }

        public IEnumerable<Post> GetPostList()
        {
            return dbContext.Posts.ToList();
        }
    }
}
