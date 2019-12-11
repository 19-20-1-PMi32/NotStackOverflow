using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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

        public string Title { get; set; }
        public int Viewed { get; set; }
        [Required]
        public DateTime DateOfPublish { get; set; }
        [JsonIgnore]
        public ICollection<int> Tags { get; set; }
        public ICollection<TagDTO> PostTags { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }

        [Required]
        [JsonIgnore]
        public int UserId { get; set; }
        public PreviewUserDTO User { get; set; }

        public PostDTO()
        {
            Tags = new HashSet<int>();
            PostTags = new HashSet<TagDTO>();
            Comments = new HashSet<CommentDTO>();
        }
        public bool ShouldSerializePostDTO()
        {
            return (UserId != 0);
        }
    }
}