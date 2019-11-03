using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        string Authenticate(string email, string password);

        string RefreshToken(string token, string refreshToken);

    }
}
