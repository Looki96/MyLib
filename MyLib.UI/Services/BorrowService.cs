using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly HttpClient _httpClient;

        public BorrowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BorrowDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<BorrowDto>>("api/borrow");
            return result;
        }
        public async Task<IEnumerable<BorrowDto>> GetOwn()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<BorrowDto>>($"api/borrow/my");
            return result;
        }

        public async Task<BorrowDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<BorrowDto>($"api/borrow/{id}");
            return result;
        }

        public async Task<HttpResponseMessage> Create(CreateBorrowDto borrow)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/borrow", borrow);
            return result;
        }

        public async Task GiveBack(int id)
        {
            var result = await _httpClient.PutAsync($"api/borrow/{id}", null);
            return;
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/borrow/{id}");
            return;
        }
    }
}
