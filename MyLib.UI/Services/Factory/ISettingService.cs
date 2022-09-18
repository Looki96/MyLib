using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface ISettingService
    {
        Task<IEnumerable<SettingDto>> GetAll();
        Task<SettingDto> GetById(int id);
        Task<SettingDto> GetByKey(string key);
        Task Update(int id, string value);
    }
}