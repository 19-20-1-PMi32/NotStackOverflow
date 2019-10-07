using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Api.Auth;
using BLL;
using BLL.Interfaces;
using BLL.Service;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Api.JwtGenerator
{
    public class JwtGenerator
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public JwtGenerator(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public JwtGenerator(IUserService userService)
        {
            _userService = userService;
        }

        public string GetToken(string username, string password)
        {
            var user = _userService.GetUserByEmailAndPass(username, password);

            var identity = _accountService.GetIdentity(user.Email, user.Role);
            if (identity == null)
            {
                return "Invalid username or password.";
            }

            var now = DateTime.UtcNow;


            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
        }
    }
}
