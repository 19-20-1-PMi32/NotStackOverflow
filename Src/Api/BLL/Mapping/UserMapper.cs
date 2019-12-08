using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;
using DAL.Entities;

namespace BLL.Mapping
{
    public static class UserMapper
    {
        public static PreviewUserDTO ToPreviewUserDTO(this User user)
        {
            if (user == null) return null;
            return new PreviewUserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
            };
        }

        public static User ToUser(this CreateUserDTO createUserDTO)
        {
            return new User
            {
                Name = createUserDTO.Name,
                NickName = createUserDTO.NickName,
                Surname = createUserDTO.Surname,
                Password = createUserDTO.Password,
                Email = createUserDTO.Email,
                Job = createUserDTO.Job
            };
        }
    }
}
