using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IBookService
    {
        Task Create(CreateBookDto book);
        Task Delete(int id);
        Task<IEnumerable<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task Update(int id, UpdateBookDto book);
    }
}