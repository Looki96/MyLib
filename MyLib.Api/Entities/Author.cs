using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}
