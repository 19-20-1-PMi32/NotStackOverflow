using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public  class PostTagsDTO
    {
        [Required]
        public int PostId { get; set; }
        public PostDTO Post { get; set; }

        [Required]
        public int TagId { get; set; }
        public TagDTO Tag { get; set; }
    }
}