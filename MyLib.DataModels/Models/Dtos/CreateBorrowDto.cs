using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class CreateBorrowDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Book is Required")]
        public int BookId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Borrow is Required")]
        public int BorrowerId { get; set; }

        [Required]
        public DateTime? ReturnDate { get; set; }
    }
}
