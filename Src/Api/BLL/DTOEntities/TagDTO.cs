using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public class TagDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        //public ICollection<PostTagsDTO> PostTags { get; set; }

        //public TagDTO()
        //{
        //    PostTags = new HashSet<PostTagsDTO>();
        //}
    }
}