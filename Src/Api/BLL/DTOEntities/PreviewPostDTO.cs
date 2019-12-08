using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOEntities
{
    public class PreviewPostDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public int Viewed { get; set; }
        public PreviewUserDTO PreviewUserDTO { get; set; }
    }
}
