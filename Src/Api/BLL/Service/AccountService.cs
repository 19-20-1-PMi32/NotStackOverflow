using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BLL.Service
{
    public class AccountService: IAccountService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork database)
        {
            _database = database;
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
        }

        public ClaimsIdentity GetIdentity(string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),

            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        
    }
}
