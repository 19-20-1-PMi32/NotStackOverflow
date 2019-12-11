using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOEntities
{
    public class CreatePostDTO
    {
        
        public int PostId { get; set; }
        [Required]
        public int PostNum { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
        public int Viewed { get; set; }
        [Required]
        public DateTime DateOfPublish { get; set; }

        public ICollection<int> Tags { get; set; }

        [Required]
        public int UserId { get; set; }
        public CreatePostDTO()
        {
            Tags = new HashSet<int>();
        }
    }
}
