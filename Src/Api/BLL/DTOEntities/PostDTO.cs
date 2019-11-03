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

        public ICollection<int> Tags { get; set; }
        public ICollection<TagDTO> PostTags { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }

        [Required]
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public PostDTO()
        {
            Tags = new HashSet<int>();
            PostTags = new HashSet<TagDTO>();
            Comments = new HashSet<CommentDTO>();
        }
    }
}