
using DAL.Entities;

namespace BLL.DTOEntities
{
    public  class PostTagsDTO
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}