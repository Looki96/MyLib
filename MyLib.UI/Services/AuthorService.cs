using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<AuthorDto>>("api/author");
            return result;
        }

        public async Task<AuthorDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AuthorDto>($"api/author/{id}");
            return result;
        }

        public async Task Create(CreateAuthorDto author)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/author", author);
            return;
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/author/{id}");
            return;
        }
    }
}
