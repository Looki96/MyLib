using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? SName { get; set; }

        [Required]
        [EmailAddress]
        public string? EMail { get; set; }
    }
}
