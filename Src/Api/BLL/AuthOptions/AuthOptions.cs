using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BLL.AuthOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "NotStackOverflowServer";
        public const string AUDIENCE = "http://localhost:51884/";
        const string KEY = "mysuperpupersecret_key!400";
        public const int LIFETIME = 30;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
