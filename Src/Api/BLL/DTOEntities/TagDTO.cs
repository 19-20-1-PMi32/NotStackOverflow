using System.Collections.Generic;

namespace BLL.DTOEntities
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<PostTagsDTO> PostTags { get; set; }

        public TagDTO()
        {
            PostTags = new HashSet<PostTagsDTO>();
        }
    }
}