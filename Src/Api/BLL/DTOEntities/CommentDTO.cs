using System;

namespace BLL.DTOEntities
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PosNum { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string Text { get; set; }

        public int? UserId { get; set; }
        public UserDTO User { get; set; }

        public int PostId { get; set; }
        public PostDTO Post { get; set; }
    }
}