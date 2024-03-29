﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {

        User GetUserByEmail(string email);

    }
}
