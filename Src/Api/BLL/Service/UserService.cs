using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork database)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
        }

        public UserDTO GetUserById(int id)
        {
            
            var user = _database.Users.GetById(id);

            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO GetUserByEmailAndPass(string email, string password)
        {
            var user = _database.Users.GetUserByEmailAndPass(email, password);

            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);

            _database.Users.Add(user);
            _database.Save();

            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO UpdateUserDTO(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);

            _database.Users.Update(user);
            _database.Save();

            return _mapper.Map<User, UserDTO>(user);
        }

        public void RemoveUser(int id)
        {
            var user = _database.Users.GetById(id);

            _database.Users.Remove(user);
            _database.Save();

        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<User>, ICollection<UserDTO>>(_database.Users.GetAll());
        }

    }
}
