using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsWithComments(int postId, int startFrom, int amount);

        IEnumerable<Post> GetPostList(int startFrom, int amount);

        IEnumerable<Post> GetUsersPostsById(int userId);
    }
}
