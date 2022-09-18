using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IUserService
    {
        Task<int> Create(CreateUserDto dto, UserRoles userRole);
        Task<bool> Delete(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<bool> Update(int id, UpdateUserDto dto);
    }
}