using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AchievementRepository: Repository<Achievement>, IAchievementsRepository
    {
        public AchievementRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
