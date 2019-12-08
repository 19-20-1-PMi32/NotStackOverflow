using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserAchievementsRepository: Repository<UserAchievements>, IUserAchievementsRepository
    {
        public UserAchievementsRepository(ApplicationContext applicationContext): base(applicationContext) 
        {
        }
    }
}
