using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IAccountService
    {
        Task<HttpResponseMessage> Login(LoginDto dto);
        Task Logout();
    }
}