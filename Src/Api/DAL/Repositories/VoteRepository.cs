using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public Vote GetById(int postId, int userId)
        {
            return dbContext.Votes.Find(postId, userId);
        }
    }
}
