namespace MyLib.DataModels.Models.Dtos
{
    public class BookDto
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

        public virtual CategoryDto? Category { get; set; }

        public int PublisherId { get; set; }

        public virtual PublisherDto? Publisher { get; set; }

        public virtual ICollection<AuthorDto> Authors { get; set; }

        public BookDto()
        {
            Authors = new HashSet<AuthorDto>();
        }
    }
}
