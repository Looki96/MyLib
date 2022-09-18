using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class BorrowDto
    {
        public int Id { get; set; }

        public virtual BookDto? Book { get; set; }

        public virtual UserDto? Librarian { get; set; }

        public virtual UserDto? Borrower { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
