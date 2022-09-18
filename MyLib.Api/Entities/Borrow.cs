using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class Borrow
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public virtual Book? Book { get; set; }

        public int LibrarianId { get; set; }

        public virtual User? Librarian { get; set; }

        public int BorrowerId { get; set; }

        public virtual User? Borrower { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
