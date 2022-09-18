using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IAuthorService
    {
        Task<int> Create(CreateAuthorDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(int id);
    }
}