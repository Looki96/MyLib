using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IBookService
    {
        Task<int> Create(CreateBookDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task<bool> Update(int id, UpdateBookDto dto);
    }
}