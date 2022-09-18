using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class UpdateBookDto
    {
        [Required]
        [MaxLength(200)]
        public string? Subtitle { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public string? URL { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
