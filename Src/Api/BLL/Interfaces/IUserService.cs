using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        
        UserDTO GetUserByEmailAndPass(string email, string password);

        UserDTO CreateUser(CreateUserDTO user);

        UserDTO UpdateUser(UserDTO user);

        void RemoveUser(int id);

        IEnumerable<UserDTO> GetAll();

        void SetAdmin(int id);

    }
}
