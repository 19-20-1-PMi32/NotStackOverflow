using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOEntities
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Job { get; set; }
        [Required]
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
