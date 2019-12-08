using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<PostTags> PostTags { get; set; }

        public Tag()
        {
          PostTags = new HashSet<PostTags>();
        }
    }
}
