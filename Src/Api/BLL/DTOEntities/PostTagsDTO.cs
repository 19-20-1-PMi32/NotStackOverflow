﻿namespace BLL.DTOEntities
{
    public  class PostTagsDTO
    {
        public int PostId { get; set; }
        public PostDTO Post { get; set; }

        public int TagId { get; set; }
        public TagDTO Tag { get; set; }
    }
}