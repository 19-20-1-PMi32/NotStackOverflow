﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IVoteRepository: IRepository<Vote>
    {
        Vote GetById(int postId, int userId);
    }
}
