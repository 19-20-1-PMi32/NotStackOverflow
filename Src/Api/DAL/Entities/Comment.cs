using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PosNum { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string Text { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
