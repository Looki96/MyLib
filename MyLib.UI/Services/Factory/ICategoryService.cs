using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface ICategoryService
    {
        Task Create(CategoryDto category);
        Task Delete(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
    }
}