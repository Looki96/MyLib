using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/category");
            return result;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDto>($"api/category/{id}");
            return result;
        }

        public async Task Create(CategoryDto category)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/category", category);
            return;
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/category/{id}");
            return;
        }
    }
}
