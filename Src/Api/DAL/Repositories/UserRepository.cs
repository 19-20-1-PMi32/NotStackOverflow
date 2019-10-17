using System.Linq;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationcontext): base(applicationcontext)
        {
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
