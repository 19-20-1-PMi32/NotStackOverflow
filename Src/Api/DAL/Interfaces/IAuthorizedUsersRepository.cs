using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IAuthorizedUsersRepository : IRepository<AuthorizedUser>
    {
        AuthorizedUser GetAuthorizedUser(string email);
    }
}
