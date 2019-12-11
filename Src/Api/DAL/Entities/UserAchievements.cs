using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserAchievements
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }
    }
}
