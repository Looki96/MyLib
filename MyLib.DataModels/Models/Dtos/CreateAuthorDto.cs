using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class CreateAuthorDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? SName { get; set; }
    }
}
