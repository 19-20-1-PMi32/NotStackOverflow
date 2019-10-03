using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL
{
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        
        UserDTO GetUserByEmailAndPass(string email, string password);

        UserDTO CreateUser(UserDTO user);

        UserDTO UpdateUserDTO(UserDTO user);

        void RemoveUser(int id);

        IEnumerable<UserDTO> GetAll();

    }
}
