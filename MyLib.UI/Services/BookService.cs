using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<BookDto>>("api/book");
            return result;
        }

        public async Task<BookDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<BookDto>($"api/book/{id}");
            return result;
        }

        public async Task Create(CreateBookDto book)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/book", book);
            return;
        }

        public async Task Update(int id, UpdateBookDto book)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/book/{id}", book);
            return;
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/book/{id}");
            return;
        }
    }
}
