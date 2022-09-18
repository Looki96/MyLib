using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IAuthorService
    {
        Task Create(CreateAuthorDto author);
        Task Delete(int id);
        Task<IEnumerable<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(int id);
    }
}