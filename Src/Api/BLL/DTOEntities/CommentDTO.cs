using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PosNum { get; set; }
        [Required]
        public DateTime DateOfPublish { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}