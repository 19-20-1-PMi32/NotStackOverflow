using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using BLL.AuthOptions;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork database)
        {
            _database = database;
            //_mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
        }

        public ClaimsIdentity GetIdentity(string name, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, JWTValidationParameters.ExpiredTokenValidationParameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GetAccessToken(string username, string password)
        {
            var user = _database.Users.GetUserByEmailAndPass(username, password);

            var identity = GetIdentity(user.Name, user.Email, user.Role);

            return identity == null ? 
                "Invalid username or password." :
                GenerateToken(identity);
        }

        public string GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.AuthOptions.ISSUER,
                audience: AuthOptions.AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

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

        public (string, string) RefreshToken(string token, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            
            var email =  principal.Claims.FirstOrDefault(user => user.Type == ClaimTypes.Email);
            var role =  principal.Claims.FirstOrDefault(user => user.Type == ClaimTypes.Role);

            if (email == null || role == null)
            {
                throw new Exception("Bad Claims");
            }
               //var savedRefreshToken = GetRefreshToken(username); //retrieve the refresh token from a data store
            //if (savedRefreshToken != refreshToken)
            //    throw new SecurityTokenException("Invalid refresh token");
            // need to add implementation of logic that will get existing refresh token of user and check for it equality 

            var newAccessToken = GenerateToken(GetIdentity(principal.Identity.Name, email.Value, role.Value));
            var newRefreshToken = GenerateRefreshToken();

            //update new refresh token to user

            return (newAccessToken, newRefreshToken);

        }
    }
}