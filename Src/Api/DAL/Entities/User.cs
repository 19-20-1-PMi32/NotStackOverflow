using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public string Role { get; set; }
        public int Rating { get; set; }

        public ICollection<UserAchievements> UserAchievements { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Post> Posts { get; set; }
        

        public User()
        {
            UserAchievements = new HashSet<UserAchievements>();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }
    }
}
