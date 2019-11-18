using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Like
    {
        public Post Post { get; set; }

        public int PostId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
