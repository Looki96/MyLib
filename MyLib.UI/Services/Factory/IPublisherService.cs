using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IPublisherService
    {
        Task Create(PublisherDto publisher);
        Task Delete(int id);
        Task<IEnumerable<PublisherDto>> GetAll();
        Task<PublisherDto> GetById(int id);
    }
}