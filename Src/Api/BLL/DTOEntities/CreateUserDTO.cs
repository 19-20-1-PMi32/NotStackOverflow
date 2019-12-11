using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOEntities
{
    public class CreateUserDTO
    {
        public string NickName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Job { get; set; }

    }
}
