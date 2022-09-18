using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IUserService
    {
        Task Create(CreateUserDto user, UserRoles userRole);
        Task Delete(int id, UserRoles userRole);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task Update(int id, UpdateUserDto user, UserRoles userRole);
    }
}