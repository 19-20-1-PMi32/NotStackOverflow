using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<UserAchievements> UserAchievements { get; set; }

        public Achievement()
        {
            UserAchievements = new HashSet<UserAchievements>();
        }
    }
}
