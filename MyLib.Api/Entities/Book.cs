using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public string? ISBN { get; set; }

        public string? URL { get; set; }

        public int Pages { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public DateTime PublishDate { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public Book ()
        {
            Authors = new HashSet<Author>();
        }
    }
}
