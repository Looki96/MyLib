using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface ICategoryService
    {
        Task<int> Create(CreateCategoryDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
    }
}