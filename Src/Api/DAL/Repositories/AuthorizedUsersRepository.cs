using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AuthorizedUsersRepository: Repository<AuthorizedUser>, IAuthorizedUsersRepository
    {
        public AuthorizedUsersRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public AuthorizedUser GetAuthorizedUser(string email)
        {
            return dbContext.AuthorizedUsers.FirstOrDefault(e => e.Email == email);
        }
    }
}
