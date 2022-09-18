using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class CreateBookDto
    {
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Subtitle { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string? ISBN { get; set; }

        [Url]
        public string? URL { get; set; }

        public int Pages { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? Description { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PublisherId { get; set; }

        public virtual ICollection<int> AuthorsId { get; set; }

        public CreateBookDto()
        {
            AuthorsId = new HashSet<int>();
        }
    }
}
