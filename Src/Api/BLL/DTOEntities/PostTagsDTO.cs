using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOEntities
{
    public  class PostTagsDTO
    {
        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}