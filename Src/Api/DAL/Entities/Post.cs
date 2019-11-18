using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int PostNum { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int Viewed { get; set; }
        public DateTime DateOfPublish { get; set; }

        public ICollection<PostTags> PostTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Post()
        {
            PostTags = new HashSet<PostTags>();
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }
    }
}
