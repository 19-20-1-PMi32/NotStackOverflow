using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Api.Auth
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
