using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface ISettingService
    {
        Task<IEnumerable<SettingDto>> GetAll();
        Task<SettingDto> GetById(int id);
        Task<SettingDto> GetByKey(string key);
        Task<bool> Update(int id, string value);
    }
}