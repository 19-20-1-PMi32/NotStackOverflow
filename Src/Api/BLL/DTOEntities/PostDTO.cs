using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int PostNum { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        [Required]
        public string Text { get; set; }
        public int Viewed { get; set; }
        [Required]
        public DateTime DateOfPublish { get; set; }

        public ICollection<PostTagsDTO> PostTags { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }

        [Required]
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public PostDTO()
        {
            PostTags = new HashSet<PostTagsDTO>();
            Comments = new HashSet<CommentDTO>();
        }
    }
}