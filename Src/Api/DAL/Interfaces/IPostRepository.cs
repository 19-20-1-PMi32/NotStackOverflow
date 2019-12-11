using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsWithComments(int postId);

        IEnumerable<Post> GetPostList(int amount);

        IEnumerable<Post> GetUsersPostsById(int userId);

        IEnumerable<Post> OrderByLike(int page);
        IEnumerable<Post> OrderByDislike(int page);
        IEnumerable<Post> OrderByDate(int page);

        int GetPostCount();
    }
}
