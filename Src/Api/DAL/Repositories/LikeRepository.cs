using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public Like GetById(int postId, int userId)
        {
            return dbContext.Likes.Find(postId, userId);
        }
    }
}
