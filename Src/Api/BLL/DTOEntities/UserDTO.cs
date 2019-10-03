using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOEntities
{
    public class UserDTO
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

        public ICollection<UserAchievementsDTO> UserAchievements { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }

        public ICollection<PostDTO> Posts { get; set; }


        public UserDTO()
        {
            UserAchievements = new HashSet<UserAchievementsDTO>();
            Comments = new HashSet<CommentDTO>();
            Posts = new HashSet<PostDTO>();
        }
    }

 
}
