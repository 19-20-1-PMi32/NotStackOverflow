using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOEntities
{
    public class PreviewUserDTO
    {
        public int Id { get; set; }
        
        public string NickName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
