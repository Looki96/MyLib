using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IAccountService
    {
        Task<string> Login(LoginDto loginDto);
    }
}