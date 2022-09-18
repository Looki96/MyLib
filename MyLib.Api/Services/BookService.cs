using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services
{
    public class BookService : IBookService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(MyLibContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _dbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .Include(b => b.Authors)
                .ToListAsync();

            var result = _mapper.Map<List<BookDto>>(books);

            return result;
        }

        public async Task<BookDto> GetById(int id)
        {
            var book = await _dbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.Id == id);

            var result = _mapper.Map<BookDto>(book);

            return result;
        }

        public async Task<int> Create(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);

            foreach(var id in dto.AuthorsId)
            {
                var author = _dbContext.Authors.FirstOrDefault(b => b.Id == id);
                if(author != null) book.Authors.Add(author);
            }

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Update(int id, UpdateBookDto dto)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return false;
            }

            book.Subtitle = dto.Subtitle;
            book.Quantity = dto.Quantity;
            book.Pages = dto.Pages;
            book.Description = dto.Description;
            book.URL = dto.URL;
            book.CategoryId = dto.CategoryId;
            book.PublisherId = dto.PublisherId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return false;
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
