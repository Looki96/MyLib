using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class SettingService : ISettingService
    {
        private readonly HttpClient _httpClient;

        public SettingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SettingDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SettingDto>>("api/setting");
            return result;
        }

        public async Task<SettingDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SettingDto>($"api/setting/{id}");
            return result;
        }

        public async Task<SettingDto> GetByKey(string key)
        {
            var result = await _httpClient.GetFromJsonAsync<SettingDto>($"api/setting/GetByKey/{key}");
            return result;
        }

        public async Task Update(int id, string value)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/setting/{id}", value);
            return;
        }
    }
}
