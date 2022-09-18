using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyLib.UI.Services.Factory;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using MyLib.UI.Authentication;
using System.Linq;
using System.Text.Json.Serialization;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AccountService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<HttpResponseMessage> Login(LoginDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account/login", dto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                await _localStorage.SetItemAsync("authToken", result);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(dto.Login);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result);
            }

            return response;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
