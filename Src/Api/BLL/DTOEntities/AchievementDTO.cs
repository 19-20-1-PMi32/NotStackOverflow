using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public class AchievementDTO
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<UserAchievementsDTO> UserAchievements { get; set; }

        public AchievementDTO()
        {
            UserAchievements = new HashSet<UserAchievementsDTO>();
        }
    }
}