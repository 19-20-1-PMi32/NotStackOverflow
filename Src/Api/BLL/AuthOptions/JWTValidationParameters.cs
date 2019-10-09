using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BLL.AuthOptions
{
    public class JWTValidationParameters
    {
        public static TokenValidationParameters TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,

            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,

            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,

            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

            ValidateIssuerSigningKey = true,
        };

        public static TokenValidationParameters ExpiredTokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,

            ValidateIssuer = false,

            ValidateIssuerSigningKey = true,

            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

            ValidateLifetime = false
        };
    };
}
