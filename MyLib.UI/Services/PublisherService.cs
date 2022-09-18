using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient _httpClient;

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PublisherDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PublisherDto>>("api/publisher");
            return result;
        }

        public async Task<PublisherDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PublisherDto>($"api/publisher/{id}");
            return result;
        }

        public async Task Create(PublisherDto publisher)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/publisher", publisher);
            return;
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/publisher/{id}");
            return;
        }
    }
}
