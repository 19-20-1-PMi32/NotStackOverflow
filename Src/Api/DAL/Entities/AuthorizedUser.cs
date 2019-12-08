using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class AuthorizedUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string RefreshToken { get; set; }
    }
}
