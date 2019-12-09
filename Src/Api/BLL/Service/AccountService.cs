using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using BLL.AuthOptions;
using DAL.Entities;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _database;

        public AccountService(IUnitOfWork database)
        {
            _database = database;
        }

        public string Authenticate(string username, string password)
        {
            var refreshToken = GenerateRefreshToken();

            var authorizedUser = new AuthorizedUser {Email = username, RefreshToken = refreshToken};
            _database.AuthorizedUsers.Add(authorizedUser);
            _database.Save();

            int userId;
            
            var accessToken = GetAccessToken(authorizedUser.Id,username, password, out userId);

            var response = new
            {
                Id = userId,
                access_token = accessToken,
                refresh_token = refreshToken
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }

        public string RefreshToken(string token, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(token);

            var email =  principal.Claims.FirstOrDefault(user => user.Type == ClaimTypes.Email);
            var role =  principal.Claims.FirstOrDefault(user => user.Type == ClaimTypes.Role);
            var tokenId = principal.Claims.FirstOrDefault(user => user.Type == "tokenId");
            var userId = principal.Claims.FirstOrDefault(user => user.Type == "Id");

            if (email == null || role == null || tokenId == null)
            {
                throw new System.Exception("Bad Claims");
            }

            var authorizedUser = _database.AuthorizedUsers.GetById(Convert.ToInt32(tokenId.Value)); //retrieve the refresh token from a data store
            if (authorizedUser.RefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newAccessToken = GenerateToken(GetIdentity(principal.Identity.Name, email.Value, role.Value,
                Convert.ToInt32(tokenId.Value), Convert.ToInt32(userId)));
            var newRefreshToken = GenerateRefreshToken();

            authorizedUser.RefreshToken = newRefreshToken;
            _database.AuthorizedUsers.Update(authorizedUser);

            _database.Save();

            var response = new
            {
                access_token = newAccessToken,
                refresh_token = newRefreshToken
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }

        private ClaimsIdentity GetIdentity(string name, string email, string role, int tokenId, int userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                new Claim("tokenId", tokenId.ToString()),
                new Claim("Id", userId.ToString())
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, JWTValidationParameters.ExpiredTokenValidationParameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string GenerateToken(ClaimsIdentity identity)
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

            return encodedJwt;
        }

        private string GetAccessToken(int tokenId, string username, string password, out int userId)
        {
            var user = _database.Users.GetUserByEmail(username);

            userId = user.Id;
            
            //var userHashPass = PasswordHashService.Hash(password);

            if (!PasswordHashService.Check(user.Password, password).Verified)
            {
                throw new SecurityException("Invalid email or password");
            }

            var identity = GetIdentity(user.Name, user.Email, user.Role, tokenId, userId);

            return identity == null ?
                "Invalid username or password." :
                GenerateToken(identity);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}