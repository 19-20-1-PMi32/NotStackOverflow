using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity GetIdentity(string name, string email, string role);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        string Authenticate(string email, string password);

        (string, string) RefreshToken(string token, string refreshToken);

    }
}
