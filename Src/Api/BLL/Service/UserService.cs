using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using BLL.Mapping;
using BLL.Options;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Options;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork database)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<PostDTO, Post>();
            }).CreateMapper();

            var hspass = new PasswordHashService();
        }

        public UserDTO GetUserById(int id)
        {
            
            var user = _database.Users.GetById(id);

            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO GetUserByEmailAndPass(string email, string password)
        {
            var pass = PasswordHashService.Hash(password);
            var res = PasswordHashService.Check(pass, password);
            var user = _database.Users.GetUserByEmail(email);

            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO CreateUser(CreateUserDTO userDTO)
        {
            var pass = PasswordHashService.Hash(userDTO.Password);

            var user = userDTO.ToUser();
            
            user.Role = "User";
            user.Password = pass;

            _database.Users.Add(user);
            _database.Save();

            return _mapper.Map<User, UserDTO>(user);
            //return userDTO;
        }

        public UserDTO UpdateUser(UserDTO userDTO)
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

        public void SetAdmin(int id)
        {
            var user = _database.Users.GetById(id);
            user.Role = "Admin";
            _database.Save();
        }
    }
}
