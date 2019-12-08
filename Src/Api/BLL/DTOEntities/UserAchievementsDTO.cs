using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public class UserAchievementsDTO
    {
        [Required]
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        
        [Required]
        public int AchievementId { get; set; }
        public AchievementDTO Achievement { get; set; }
    }
}