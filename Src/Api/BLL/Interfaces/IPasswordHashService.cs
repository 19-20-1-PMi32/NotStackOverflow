using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IPasswordHashService
    {
        //string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
