using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Services.Factory;
using System.Net.Http.Json;

namespace MyLib.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>($"api/user");
            return result;
        }

        public async Task<UserDto> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserDto>($"api/user/{id}");
            return result;
        }

        public async Task Create(CreateUserDto user, UserRoles userRole)
        {
            switch (userRole)
            {
                case UserRoles.Admin:
                    await _httpClient.PostAsJsonAsync($"api/user/admin", user);
                    break;

                case UserRoles.Librarrian:
                    await _httpClient.PostAsJsonAsync($"api/user/librarrian", user);
                    break;

                case UserRoles.Borrower:
                    await _httpClient.PostAsJsonAsync($"api/user/borrower", user);
                    break;
            }

            return;
        }

        public async Task Update(int id, UpdateUserDto user, UserRoles userRole)
        {
            switch (userRole)
            {
                case UserRoles.Admin:
                    await _httpClient.PutAsJsonAsync($"api/user/admin/{id}", user);
                    break;

                case UserRoles.Librarrian:
                    await _httpClient.PutAsJsonAsync($"api/user/librarrian/{id}", user);
                    break;

                case UserRoles.Borrower:
                    await _httpClient.PutAsJsonAsync($"api/user/borrower/{id}", user);
                    break;
            }

            return;
        }

        public async Task Delete(int id, UserRoles userRole)
        {
            switch (userRole)
            {
                case UserRoles.Admin:
                    await _httpClient.DeleteAsync($"api/user/admin/{id}");
                    break;

                case UserRoles.Librarrian:
                    await _httpClient.DeleteAsync($"api/user/librarrian/{id}");
                    break;

                case UserRoles.Borrower:
                    await _httpClient.DeleteAsync($"api/user/borrower/{id}");
                    break;
            }

            return;
        }
    }
}
