namespace BLL.DTOEntities
{
    public class UserAchievementsDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int AchievementId { get; set; }
        public AchievementDTO Achievement { get; set; }
    }
}